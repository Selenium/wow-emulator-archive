unit DbcHandler;

interface

uses
    Windows, Classes, SysUtils, Dialogs, AcedContainers, Variants, IniFiles, StrUtils;

type
  TKeyType = (ktIntArray,ktStringHT,ktIntHT);
  TOutStringArray=record
    OutString: string;
    offset: integer;
  end;
  TFieldTypesRecord=record
    name,kind: string;
    kind_int: string;
    hex: boolean;
  end;
  TDbcHandler = class
  private
    FName: string;
    FFieldCount,FRowCount,FTextLength,FRowLength,FKeyFieldNumber,FKeyFieldNumber2,
       max_ID,toReplaceCount,iter: integer;
    KeyType: TKeyType;
    int_values_arr: array of integer;                   //value array
    str_values_arr: array of char;
    link_recordNumber2offset_arr: array of integer;     //links to values from string HT
    link_Id2offset_arr: array of integer;               //links by ID to array position for ktIntArray only
    link2replace: array of integer;
    str_fields_numbers: array of integer;
    procedure Add2ReplaceArr(offs: integer);
    procedure GetIniSettings(DbcIniFName: string);
  public
    DbcHT: TIntegerHashtable;                           //offsets by integer key
    DbcStrHT: TStringHashtable;                         //offsets by string key
    property FieldCount: integer read FFieldCount;
    property RowCount: integer read FRowCount;
    property RowLength: integer read FRowLength;
    function GetStringByOffset(offset: integer): string;
    procedure LoadDbcArray(DbcFileName: string; KeyFieldNumber,KeyFieldNumber2: integer; ktType: TKeyType);
    procedure SaveDbc;
    function AddString(value: string):integer; //return new offset
    function ContainStrKey(value: string): boolean;
    function GetPointerPRValueByStrKey(key: string):pointer;
    function GetPointerPRValueByIntKey(key: integer):pointer;
    function AddRecord(data: pointer):integer;
    procedure RemoveRecordIntKey(key: integer);
    procedure RemoveRecordStrKey(key: string);
    procedure Add2arrayWholeWithStrings(key, first_column: integer; var mod_arr; var offs: integer);
    procedure ResetIterator;
    function GetNextIteratorPointerPRValue: pointer;
  published
    property MaxID: integer read max_ID;
  end;

var
  CharBuffer: array[0..4095]of char;
const
     maxlinkarr_size = $100000;

implementation

uses UnitMain, ByteArrayHandler;

function TDbcHandler.GetStringByOffset(offset: integer): string;  //ready offset in strings
var
   presult: PChar;
begin
   try
     presult:=@str_values_arr[offset];
     result:=strpas(presult);
   except AddToLog('GetStringByOffset exception, offset='+IntToStr(offset));
   end;
end;

procedure TDbcHandler.GetIniSettings(DbcIniFName: string);
var
   DbcIni: TIniFile;
   i,rec_count,str_f_count: integer;
   promTString: TStringList;
   field_kind,iniFName: string;
begin
     iniFName:=AnsiReplaceStr(DbcIniFName,'.dbc','.ini');
     DbcIni:=TIniFile.Create(iniFName);
     promTString:=TStringList.Create;
     try
        DbcIni.ReadSectionValues('Field name',promTString);
        rec_count:=promTString.Count;
        str_f_count:=0;
        for i:=0 to pred(rec_count) do
        begin
             field_kind:=DbcIni.ReadString('Field kind','Field '+IntToStr(i),'ftInteger');
             if field_kind='ftString' then
             begin
                  inc(str_f_count);
                  setlength(str_fields_numbers,str_f_count);
                  str_fields_numbers[str_f_count-1]:=i;
             end;
        end;
     finally DbcIni.Free;
             promTString.Free;
     end;
end;

procedure TDbcHandler.Add2ReplaceArr(offs: integer);
begin
     inc(toReplaceCount);
     setlength(link2replace,toReplaceCount);
     link2replace[toReplaceCount-1]:=offs;
end;

procedure TDbcHandler.LoadDbcArray(DbcFileName: string; KeyFieldNumber,KeyFieldNumber2: integer; ktType: TKeyType); //KeyFieldNumber for HT only
var
   i: integer;
   InFile: TFileStream;
   HeaderDbc: array[0..4]of integer;
   row_count,field_count,row_length,text_length,
      HeaderSizeInBytes,curr_max_ID,offs,promint: integer;
   key_name: string;
function CheckAdd2Replace(curr_offs,curr_row: integer):boolean;
var
   j: integer;
   all_zero: boolean;
begin
     j:=1;all_zero:=true;
     while (j < field_count)and(all_zero) do
     begin
          if (int_values_arr[curr_offs+j] <> 0) then all_zero:=false;
          inc(j);
     end;
     if all_zero then Add2ReplaceArr(curr_offs);
     result:=all_zero;
end;
begin
     FName:=DbcFileName;
     GetIniSettings(DbcFileName);
     InFile:=TFileStream.Create(DbcFileName,fmOpenRead);

     try
        //try
           KeyType:=ktType;
           HeaderSizeInBytes:=sizeof(HeaderDbc);
           InFile.Read(HeaderDbc,HeaderSizeInBytes);
           if HeaderDbc[0]=$43424457 then
           begin
                row_count:=HeaderDbc[1];
                field_count:=HeaderDbc[2];
                row_length:=HeaderDbc[3];
                text_length:=HeaderDbc[4];
                FRowCount:=row_count;
                FFieldCount:=field_count;
                FRowLength:=row_length;
                FTextLength:=text_length;
                FKeyFieldNumber:=KeyFieldNumber;
                FKeyFieldNumber2:=KeyFieldNumber2;

                if (KeyFieldNumber >= field_count)or(KeyFieldNumber2 >= field_count) then
                   raise Exception.Create('KeyFieldNumber not in field count');

                setlength(int_values_arr,row_count*field_count);
                InFile.Seek(20,soFromBeginning);
                InFile.Read(int_values_arr[0],row_count*row_length);

                setlength(str_values_arr,text_length);
                InFile.Seek(-text_length,soFromEnd);
                InFile.Read(str_values_arr[0],text_length);

                max_ID:=0;toReplaceCount:=0;
                if ktType=ktIntArray then
                begin
                     setlength(link_recordNumber2offset_arr,row_count);
                     setlength(link_Id2offset_arr,maxlinkarr_size);
                     for i:=0 to pred(maxlinkarr_size) do link_Id2offset_arr[i]:=-1;
                     for i:=0 to pred(row_count) do
                     begin
                          offs:=i*field_count;
                          curr_max_ID:=int_values_arr[offs]; //ID
                          if (curr_max_ID > max_ID) then max_ID:=curr_max_ID;
                          link_recordNumber2offset_arr[i]:=offs;

                          if not(CheckAdd2Replace(offs,i))then
                             link_Id2offset_arr[int_values_arr[offs]]:=offs;
                     end;
                     setlength(link_Id2offset_arr,max_ID+1);
                end
                else if ktType=ktStringHT then begin
                     setlength(link_recordNumber2offset_arr,row_count);
                     DbcStrHT:=TStringHashtable.Create(false,row_count);
                     for i:=0 to pred(row_count) do
                     begin
                          offs:=i*field_count;
                          curr_max_ID:=int_values_arr[offs]; //ID
                          if (curr_max_ID > max_ID) then max_ID:=curr_max_ID;
                          link_recordNumber2offset_arr[i]:=offs;

                          if not(CheckAdd2Replace(offs,i))then
                          try
                             key_name:=GetStringByOffset(int_values_arr[offs+KeyFieldNumber]);
                             if (key_name <> '') then DbcStrHT.Add(AnsiUpperCase(key_name),@int_values_arr[offs]);
                          except;
                          end;
                     end;
                end
                else begin   //integer HT
                     setlength(link_recordNumber2offset_arr,row_count);
                     DbcHT:=TIntegerHashtable.Create(row_count);
                     for i:=0 to pred(row_count) do
                     begin
                          offs:=i*field_count;
                          curr_max_ID:=int_values_arr[offs]; //ID
                          if (curr_max_ID > max_ID) then max_ID:=curr_max_ID;
                          link_recordNumber2offset_arr[i]:=offs;

                          if not(CheckAdd2Replace(offs,i))then
                          try
                             if FKeyFieldNumber2 >= 0 then
                                promint:=(int_values_arr[offs+FKeyFieldNumber] shl 16)or(int_values_arr[offs+FKeyFieldNumber2] and $FFFF)
                             else promint:=int_values_arr[offs+FKeyFieldNumber];
                             DbcHT.Add(promint,@int_values_arr[offs]);
                          except;
                          end;
                     end;
                end;
           end;
        //except ShowMessage('Some problems with '+DbcFileName+' or not found');
        //end;
     finally InFile.Free;
     end;
end;

procedure TDbcHandler.SaveDbc;
var
   OutFile: TFileStream;
   HeaderDbc: array[0..4]of integer;
   i,j,str_fields_numbers_last,HeaderSizeInBytes,
      max_string_number,loffs,promstrlen: integer;
   OutStringArray: array of char;
   StringHT: TStringHashtable;
   string_offsets: array of integer;
   promstr: string;
   pinteger: ^integer;
begin
   try
     //rebuild strings
     if (str_fields_numbers<>nil)and(length(str_fields_numbers)<>0)then
     begin
          setlength(string_offsets,$1000000);
          max_string_number:=1;
          string_offsets[max_string_number]:=1;
          setlength(OutStringArray,length(str_values_arr));
          str_fields_numbers_last:=length(str_fields_numbers)-1;
          StringHT:= TStringHashtable.Create(true,FRowCount);
          for i:=0 to pred(FRowCount)do
          begin
               for j:=0 to str_fields_numbers_last do
               begin
                    loffs:=link_recordNumber2offset_arr[i]+str_fields_numbers[j];
                    promstr:=trim(GetStringByOffset(int_values_arr[loffs]));
                    if promstr='' then int_values_arr[loffs]:=0
                    else if (StringHT.Contains(promstr))then
                    begin
                         pinteger:=StringHT[promstr];
                         int_values_arr[loffs]:=pinteger^;
                    end
                    else begin
                         int_values_arr[loffs]:=string_offsets[max_string_number];
                         StringHT.Add(promstr,@string_offsets[max_string_number]);
                         promstrlen:=length(promstr);
                         move((@promstr[1])^,(@OutStringArray[string_offsets[max_string_number]])^,promstrlen);
                         inc(max_string_number);
                         string_offsets[max_string_number]:=string_offsets[max_string_number-1]+promstrlen+1;
                    end;
               end;
          end;
          move(OutStringArray[0],str_values_arr[0],string_offsets[max_string_number]);
          setlength(str_values_arr,string_offsets[max_string_number]);
          StringHT.Free;
     end;

     if (int_values_arr <> nil)then
     begin
          OutFile:=TFileStream.Create(FName,fmCreate);
          try
             HeaderSizeInBytes:=sizeof(HeaderDbc);
             HeaderDbc[0]:=$43424457;
             HeaderDbc[1]:=FRowCount;
             HeaderDbc[2]:=FFieldCount;
             HeaderDbc[3]:=FRowLength;
             HeaderDbc[4]:=length(str_values_arr);
             OutFile.Write(HeaderDbc,HeaderSizeInBytes);

             OutFile.Write(int_values_arr[0],FRowCount*FRowLength);

             OutFile.Write(str_values_arr[0],length(str_values_arr));
          except;
          end;
          OutFile.Free;
     end;
     OutStringArray:=nil;
     string_offsets:=nil;
   except AddToLog('SveDbc exception, file='+FName);
   end;
end;

function TDbcHandler.ContainStrKey(value: string):boolean;
begin
     result:=false;
     if (KeyType=ktStringHT) then result:=DbcStrHT.Contains(value);
end;

{ pointers to Packed Records }

function TDbcHandler.GetPointerPRValueByStrKey(key: string):pointer;
begin
   result:=nil;
   try
     if (KeyType=ktStringHT) then
     begin
          result:=DbcStrHT[key];
     end;
   except AddToLog('GetPointerPRValueByStrKey exception, key='+key);
   end;
end;

function TDbcHandler.GetPointerPRValueByIntKey(key: integer):pointer;
var
   link: integer;
begin
   result:=nil;
   try
     if (KeyType=ktIntHT)then
     begin
          result:=DbcHT[key];
     end
     else if (KeyType=ktIntArray)and(key >= 0)and(key <= max_ID) then
     begin
          link:=link_Id2offset_arr[key];
          if link>=0 then result:=@int_values_arr[link];
     end;
   except AddToLog('GetPointerPRValueByIntKey exception, key='+IntToStr(key));
   end;
end;

function TDbcHandler.AddString(value: string):integer; //return offset
var
   promstr: string;
begin
     result:=0;
     promstr:=trim(value);
     if (promstr <> '') then
     begin
          result:=length(str_values_arr);
          setlength(str_values_arr,result+succ(length(promstr)));
          move(promstr[1],str_values_arr[result],length(promstr));
     end;
end;

function TDbcHandler.AddRecord(data: pointer):integer;
var
   new_int_offset,insert2row: integer;
   key_name: string;
begin
   result:=0;
   try
     new_int_offset:=length(int_values_arr);
     insert2row:=FRowCount;
     if toReplaceCount > 0 then
     begin
          new_int_offset:=link2replace[toReplaceCount-1];
          dec(toReplaceCount);
          setlength(link2replace,toReplaceCount);
          insert2row:=new_int_offset div FFieldCount;
     end
     else begin
          setlength(int_values_arr,new_int_offset+FFieldCount);
          inc(FRowCount);
     end;

     inc(max_ID);
     move(data^,int_values_arr[new_int_offset],FRowLength);
     int_values_arr[new_int_offset]:=max_ID;
     result:=max_ID;

     if KeyType=ktIntArray then
     begin
          setlength(link_Id2offset_arr,max_ID+1);
          link_Id2offset_arr[max_ID]:=new_int_offset;
          setlength(link_recordNumber2offset_arr,FRowCount);
          link_recordNumber2offset_arr[insert2row]:=new_int_offset;
     end
     else if KeyType=ktStringHT then begin
          setlength(link_recordNumber2offset_arr,FRowCount);
          link_recordNumber2offset_arr[insert2row]:=new_int_offset;
          try
             key_name:=GetStringByOffset(int_values_arr[new_int_offset+FKeyFieldNumber]);
             if (key_name <> '') then DbcStrHT.Add(AnsiUpperCase(key_name),@int_values_arr[new_int_offset]);
          except;
          end;
     end
     else begin
          setlength(link_recordNumber2offset_arr,FRowCount);
          link_recordNumber2offset_arr[insert2row]:=new_int_offset;
          try
             DbcHT.Add(int_values_arr[new_int_offset+FKeyFieldNumber],@int_values_arr[new_int_offset]);
          except;
          end;
     end;
     FTextLength:=length(str_values_arr);
   except AddToLog('AddRecord exception, variants');
   end;
end;

procedure TDbcHandler.RemoveRecordStrKey(key: string);
var
   record_offs: integer;
   ppos,parr_pos: ^integer;
begin
   try
     if (KeyType=ktStringHT) then
     begin
          ppos:=DbcStrHT[key];
          if ppos=nil then exit;
          parr_pos:=@int_values_arr[0];
          asm
             mov eax,ppos
             sub eax,parr_pos
             shr eax,2
             mov record_offs,eax
          end;
          inc(ppos^,sizeof(integer));
          FillChar(ppos^,FRowLength-sizeof(integer),0);
          Add2ReplaceArr(record_offs);
          DbcStrHT.Remove(key);
     end;
   except AddToLog('RemoveRecordStrKey exception, key='+key);
   end;
end;

procedure TDbcHandler.RemoveRecordIntKey(key: integer);
var
   i, record_offs: integer;
   ppos,parr_pos: ^integer;
begin
   try
     if (KeyType=ktIntHT)then
     begin
          ppos:=DbcHT[key];
          if ppos=nil then exit;
          parr_pos:=@int_values_arr[0];
          asm
             mov eax,ppos
             sub eax,parr_pos
             shr eax,2
             mov record_offs,eax
          end;
          inc(ppos^,sizeof(integer));
          FillChar(ppos^,FRowLength-sizeof(integer),0);
          Add2ReplaceArr(record_offs);
          DbcHT.Remove(key);
     end
     else if (KeyType=ktIntArray)and(key >= 0)and(key <= max_ID) then
     begin
          Add2ReplaceArr(link_Id2offset_arr[key]);
          for i:=1 to pred(FFieldCount)do
              int_values_arr[link_Id2offset_arr[key]+i]:=0;
     end;
   except AddToLog('RemoveRecordIntKey exception, key='+IntToStr(key));
   end;
end;

//integer keys only
procedure TDbcHandler.Add2arrayWholeWithStrings(key, first_column: integer; var mod_arr; var offs: integer);
var
   i,str_offs,key_offs,next_string_column,curr_column,move_count: integer;
   ppos: ^integer;
begin
     key_offs:=0;
     if (KeyType=ktIntHT) then     
     begin
          ppos:=DbcHT[key];
          if ppos<>nil then
             key_offs:=ppos^;
     end
     else if (KeyType=ktIntArray)and(key >= 0)and(key <= max_ID) then
          key_offs:=link_Id2offset_arr[key];

     if key_offs>=0 then
     begin
          curr_column:=first_column;
          for i:=0 to pred(length(str_fields_numbers)) do
          begin
               next_string_column:=str_fields_numbers[i];
               if next_string_column < curr_column then continue
               else if next_string_column = curr_column then
               begin
                    str_offs:=int_values_arr[key_offs+next_string_column];
                    Add2byteArr(GetStringByOffset(str_offs),mod_arr,offs);
                    inc(curr_column);
               end
               else begin //next_string_column > curr_column
                    move_count:=(next_string_column - curr_column) shl 2;
                    move(int_values_arr[key_offs+curr_column],(@TBytes(mod_arr)[offs])^,move_count);
                    inc(offs,move_count);
                    curr_column:=next_string_column;
                    //now string
                    str_offs:=int_values_arr[key_offs+next_string_column];
                    Add2byteArr(GetStringByOffset(str_offs),mod_arr,offs);
                    inc(curr_column);
               end;
          end;
          //fill rest
          move_count:=pred(FFieldCount) - curr_column;
          if move_count > 0 then
          begin
               move_count:=move_count shl 2;
               move(int_values_arr[key_offs+curr_column],(@TBytes(mod_arr)[offs])^,move_count);
               inc(offs,move_count);
          end;
     end;
end;

procedure TDbcHandler.ResetIterator;
begin
     iter:=0;
end;

function TDbcHandler.GetNextIteratorPointerPRValue: pointer;
begin
     if iter < length(int_values_arr) then
        result:=@int_values_arr[iter]
     else result:=nil;
     inc(iter,FFieldCount);
end;

end.
