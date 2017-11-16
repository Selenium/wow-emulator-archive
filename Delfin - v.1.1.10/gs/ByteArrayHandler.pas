unit ByteArrayHandler;

interface

uses
    Windows, StrUtils, SysUtils;

type
  TBytes = array[0..MaxInt - 1] of Byte;
  TSendOpcodeArr = class
  private
    //arr_size: integer;
  public
    data: array[0..maxword] of byte;
    offs: integer;
    property data_len: integer read offs;
    procedure SetOpcode(OpCode: word);
    procedure Init(OpCode: word);
    procedure Add(in_param: byte); overload;
    procedure Add(in_param: word); overload;
    procedure Add(in_param: integer); overload;
    procedure Add(in_param: dword); overload;
    procedure Add(in_param: int64); overload;
    procedure Add(in_param: uint64); overload;
    procedure Add(in_param: single); overload;
    procedure Add(in_param: double); overload;
    procedure Add(in_param: pointer; add_size: integer); overload;
    procedure Add(in_param: string); overload;
    procedure AddPackedGUID(in_param: int64); overload;
    procedure AddPackedGUID(in_param: uint64); overload;
  end;
  TReceiveOpcodeArr = class
  private
    //arr_size: integer;
    //procedure Send(Sender: TObject);
  public
    data: array[0..maxword] of byte;
    offs: integer;
    property data_len: integer read offs;
    procedure Init;
    procedure Get(var result: byte); overload;
    procedure Get(var result: word); overload;
    procedure Get(var result: integer); overload;
    procedure Get(var result: dword); overload;
    procedure Get(var result: int64); overload;
    procedure Get(var result: single); overload;
    procedure Get(var result: double); overload;
    procedure Get(result: pointer; out_size: integer); overload;
    procedure Get(var result: string); overload;
  end;

  procedure RandArray(var InArray; length: integer);
  procedure ReverseByteArray(var InArray; length: integer);
  
  procedure Add2DbyteArr(in_byte: byte; var mod_arr: array of byte; var offs: integer);overload;
  procedure Add2DbyteArr(in_word: word; var mod_arr: array of byte; var offs: integer);overload;
  procedure Add2DbyteArr(in_int: integer; var mod_arr: array of byte; var offs: integer);overload;
  procedure Add2DbyteArr(in_dword: dword; var mod_arr: array of byte; var offs: integer);overload;
  procedure Add2DbyteArr(in_int64: int64; var mod_arr: array of byte; var offs: integer);overload;
  procedure Add2DbyteArr(in_single: single; var mod_arr: array of byte; var offs: integer);overload;
  procedure Add2DbyteArr(in_double: double; var mod_arr: array of byte; var offs: integer);overload;
  procedure Add2DbyteArr(in_byte_arr: TBytes; var mod_arr: array of byte; var offs: integer; count: integer);overload;
  procedure Add2DbyteArr(in_byte_arr: array of byte; var mod_arr: array of byte; var offs: integer; count: integer);overload;
  procedure Add2DbyteArr(in_str: string; var mod_arr: array of byte; var offs: integer);overload;
  procedure GetFromDByteArr(out result: TBytes; const const_arr: array of byte; var offs: integer; count: integer);overload;
  procedure GetFromDByteArr(out result: array of byte; const const_arr: array of byte; var offs: integer; count: integer);overload;
  procedure Add2byteArr(in_str: string; var mod_arr; var offs: integer);


  function FillIntArrWithStrData(InString,delim: string; var data: array of integer):integer;

implementation

uses UnitMain,OpcodeHandler,OpConst;

{ Simple arrays }

procedure RandArray(var InArray; length: integer);
var
   i: integer;
begin
     for i:=0 to pred(length) do TBytes(InArray)[i]:=Random(maxbyte);
end;

procedure ReverseByteArray(var InArray; length: integer);
var
   i,up_to: integer;
   prom: byte;
begin
     up_to:=(length shr 1)-1;
     for i:=0 to up_to do
     begin
          prom:=TBytes(InArray)[i];
          TBytes(InArray)[i]:=TBytes(InArray)[length-i-1];
          TBytes(InArray)[length-i-1]:=prom;
     end;
end;


{ "Split" analog, string to array }

function FillIntArrWithStrData(InString,delim: string; var data: array of integer):integer;
var
   offs,nextoffs: integer;
   buff: array of integer;
procedure GetStr2Int;
var
   promstr: string;
   i: integer;
begin
     promstr:='';
     for i:=offs to pred(nextoffs) do promstr:=promstr+InString[i];
     try
        setlength(buff,result+1);
        buff[result]:=StrToInt(Trim(promstr));
        inc(result);
     except;
     end;
end;
begin
   result:=0;
   try
     offs:=1;
     while (offs > 0) do
     begin
          nextoffs:=posEx(delim,InString,offs);
          if (nextoffs > 0) then
          begin
               GetStr2Int;
               offs:=nextoffs+1;
          end
          else begin
               if offs<length(InString) then GetStr2Int;
               offs:=0;
          end;
     end;
     move(buff[0],data[0],result shl 2);     //for i:=0 to pred(result) do
   except AddToLog('FillIntArrWithStrData exception arg='+InString);
   end;
end;

{ TSendOpcodeArr }

procedure TSendOpcodeArr.SetOpcode(OpCode: word);
begin
		 data[2]:= byte(OpCode);
		 data[3]:= byte(OpCode shr 8);
end;

procedure TSendOpcodeArr.Init(OpCode: word);
begin
		 SetOpcode(OpCode);
     offs:=4;
end;

procedure TSendOpcodeArr.Add(in_param: byte);
begin
     if offs > maxword then exit;  //AddToLog('Add2byteArr exception, arg byte='+IntToHex(in_param,2)+' offset='+IntToStr(offs));
     data[offs]:=in_param;
     inc(offs);
end;

procedure TSendOpcodeArr.Add(in_param: word);
begin
     if (offs+1) > maxword then exit;  //AddToLog('Add2byteArr exception, arg word='+IntToHex(in_param,2)+' offset='+IntToStr(offs));
     move((@in_param)^,data[offs],2);
     inc(offs,2);
end;

procedure TSendOpcodeArr.Add(in_param: integer);
begin
     if (offs+3) > maxword then exit;  //AddToLog('Add2byteArr exception, arg integer='+IntToHex(in_param,2)+' offset='+IntToStr(offs));
     move((@in_param)^,data[offs],4);
     inc(offs,4);
end;

procedure TSendOpcodeArr.Add(in_param: dword);
begin
     if (offs+3) > maxword then exit;  //AddToLog('Add2byteArr exception, arg dword='+IntToHex(in_param,2)+' offset='+IntToStr(offs));
     move((@in_param)^,data[offs],4);
     inc(offs,4);
end;

procedure TSendOpcodeArr.Add(in_param: int64);
begin
     if (offs+7) > maxword then exit;  //AddToLog('Add2byteArr exception, arg int64='+IntToHex(in_param,2)+' offset='+IntToStr(offs));
     move((@in_param)^,data[offs],8);
     inc(offs,8);
end;

procedure TSendOpcodeArr.Add(in_param: uint64);
begin
     if (offs+7) > maxword then exit;  //AddToLog('Add2byteArr exception, arg int64='+IntToHex(in_param,2)+' offset='+IntToStr(offs));
     move((@in_param)^,data[offs],8);
     inc(offs,8);
end;

procedure TSendOpcodeArr.Add(in_param: single);
begin
     if (offs+3) > maxword then exit;  //AddToLog('Add2byteArr exception, arg single='+IntToHex(in_param,2)+' offset='+IntToStr(offs));
     move((@in_param)^,data[offs],4);
     inc(offs,4);
end;

procedure TSendOpcodeArr.Add(in_param: double);
begin
     if (offs+7) > maxword then exit;  //AddToLog('Add2byteArr exception, arg double='+IntToHex(in_param,2)+' offset='+IntToStr(offs));
     move((@in_param)^,data[offs],8);
     inc(offs,8);
end;

procedure TSendOpcodeArr.Add(in_param: string);
var
   str_len: integer;
begin
     str_len:=length(in_param);
     if (offs+str_len) > maxword then exit;  //AddToLog('Add2byteArr exception, arg string='+IntToHex(in_param,2)+' offset='+IntToStr(offs));
     if str_len=0 then begin
        data[offs]:=0;inc(offs);
     end
     else begin
       inc(str_len);
       move((@in_param[1])^,data[offs],str_len);
       inc(offs,str_len);
     end;
end;

procedure TSendOpcodeArr.Add(in_param: pointer; add_size: integer);
begin
     if (offs+add_size) > maxword then exit;  //AddToLog('Add2byteArr exception, arg pointer='+IntToHex(in_param,2)+' offset='+IntToStr(offs));
     move(in_param^,data[offs],add_size);
     inc(offs,add_size);
end;

{function GetActiveCount(temp_guid: int64; var byte_mask: byte): integer;
var
   i: integer;
begin
     result:=0;byte_mask:=0;
     for i:=0 to 7 do
     begin
          if byte(temp_guid)<>0 then
          begin
               inc(result);
               byte_mask:=byte_mask or (1 shl i);
          end;
          temp_guid:=temp_guid shr 8;
     end;
end;}

procedure TSendOpcodeArr.AddPackedGUID(in_param: int64);
var
   j,mask_offs: integer;
   mask: byte;
begin
     //add_size:=GetActiveCount(in_param,mask);
     if (offs+9) > maxword then exit;  //AddToLog('Add2byteArr exception, arg pointer='+IntToHex(in_param,2)+' offset='+IntToStr(offs));
     mask_offs:=offs;inc(offs);mask:=0;
     for j := 0 to 7 do
     begin
          if byte(in_param)<>0 then
          begin
               data[offs]:=byte(in_param);inc(offs);
               mask:=mask or (1 shl j);
          end;
          in_param:=in_param shr 8;
     end;
     data[mask_offs]:=mask;
end;

procedure TSendOpcodeArr.AddPackedGUID(in_param: uint64);
var
   j,mask_offs: integer;
   mask: byte;
begin
     //add_size:=GetActiveCount(in_param,mask);
     if (offs+9) > maxword then exit;  //AddToLog('Add2byteArr exception, arg pointer='+IntToHex(in_param,2)+' offset='+IntToStr(offs));
     mask_offs:=offs;inc(offs);mask:=0;
     for j := 0 to 7 do
     begin
          if byte(in_param)<>0 then
          begin
               data[offs]:=byte(in_param);inc(offs);
               mask:=mask or (1 shl j);
          end;
          in_param:=in_param shr 8;
     end;
     data[mask_offs]:=mask;
end;

{ TReceiveOpcodeArr }

procedure TReceiveOpcodeArr.Init;
begin
     offs:=0;
end;

procedure TReceiveOpcodeArr.Get(var result: byte);
begin
     if offs > maxword then exit;  //AddToLog('GetFromByteArr exception, arg byte='+IntToHex(out result,2)+' offset='+IntToStr(offs));
     result:=data[offs];
     inc(offs);
end;

procedure TReceiveOpcodeArr.Get(var result: word);
begin
     if (offs+1) > maxword then exit;  //AddToLog('GetFromByteArr exception, arg word='+IntToHex(out result,2)+' offset='+IntToStr(offs));
     move(data[offs],(@result)^,2);
     inc(offs,2);
end;

procedure TReceiveOpcodeArr.Get(var result: integer);
begin
     if (offs+3) > maxword then exit;  //AddToLog('GetFromByteArr exception, arg integer='+IntToHex(out result,2)+' offset='+IntToStr(offs));
     move(data[offs],(@result)^,4);
     inc(offs,4);
end;

procedure TReceiveOpcodeArr.Get(var result: dword);
begin
     if (offs+3) > maxword then exit;  //AddToLog('GetFromByteArr exception, arg dword='+IntToHex(out result,2)+' offset='+IntToStr(offs));
     move(data[offs],(@result)^,4);
     inc(offs,4);
end;

procedure TReceiveOpcodeArr.Get(var result: int64);
begin
     if (offs+7) > maxword then exit;  //AddToLog('GetFromByteArr exception, arg int64='+IntToHex(out result,2)+' offset='+IntToStr(offs));
     move(data[offs],(@result)^,8);
     inc(offs,8);
end;

procedure TReceiveOpcodeArr.Get(var result: single);
begin
     if (offs+3) > maxword then exit;  //AddToLog('GetFromByteArr exception, arg single='+IntToHex(out result,2)+' offset='+IntToStr(offs));
     move(data[offs],(@result)^,4);
     inc(offs,4);
end;

procedure TReceiveOpcodeArr.Get(var result: double);
begin
     if (offs+7) > maxword then exit;  //AddToLog('GetFromByteArr exception, arg double='+IntToHex(out result,2)+' offset='+IntToStr(offs));
     move(data[offs],(@result)^,8);
     inc(offs,8);
end;

procedure TReceiveOpcodeArr.Get(var result: string);
var
   presult: PChar;
begin
     presult:=@data[offs];
     result:=strpas(presult);
     inc(offs,length(result)+1);
end;

procedure TReceiveOpcodeArr.Get(result: pointer; out_size: integer);
begin
     if (offs+out_size) > maxword then exit;  //AddToLog('GetFromByteArr exception, arg pointer='+IntToHex(out result,2)+' offset='+IntToStr(offs));
     move(data[offs],result^,out_size);
     inc(offs,out_size);
end;

{ Dynamic arrays }

procedure Add2DbyteArr(in_byte: byte; var mod_arr: array of byte; var offs: integer);overload;
begin
   try
     mod_arr[offs]:=in_byte;
     inc(offs);
   except AddToLog('Add2DbyteArr exception, arg byte='+IntToHex(in_byte,2)+' offset='+IntToStr(offs));
   end;
end;

procedure Add2DbyteArr(in_word: word; var mod_arr: array of byte; var offs: integer);overload;
begin
   try
     move((@in_word)^,mod_arr[offs],2);
     inc(offs,2);
   except AddToLog('Add2DbyteArr exception, arg word='+IntToHex(in_word,2)+' offset='+IntToStr(offs));
   end;
end;

procedure Add2DbyteArr(in_int: integer; var mod_arr: array of byte; var offs: integer);overload;
begin
   try
     move((@in_int)^,mod_arr[offs],4);
     inc(offs,4);
   except AddToLog('Add2DbyteArr exception, arg integer='+IntToStr(in_int)+' offset='+IntToStr(offs));
   end;
end;

procedure Add2DbyteArr(in_dword: dword; var mod_arr: array of byte; var offs: integer);overload;
begin
   try
     move((@in_dword)^,mod_arr[offs],4);
     inc(offs,4);
   except AddToLog('Add2DbyteArr exception, arg dword='+IntToStr(in_dword)+' offset='+IntToStr(offs));
   end;
end;

procedure Add2DbyteArr(in_int64: int64; var mod_arr: array of byte; var offs: integer);overload;
begin
   try
     move((@in_int64)^,mod_arr[offs],8);
     inc(offs,8);
   except AddToLog('Add2DbyteArr exception, arg int64='+IntToStr(in_int64)+' offset='+IntToStr(offs));
   end;
end;

procedure Add2DbyteArr(in_single: single; var mod_arr: array of byte; var offs: integer);overload;
begin
   try
     move((@in_single)^,mod_arr[offs],4);
     inc(offs,4);
   except AddToLog('Add2DbyteArr exception, arg single='+FloatToStr(in_single)+' offset='+IntToStr(offs));
   end;
end;

procedure Add2DbyteArr(in_double: double; var mod_arr: array of byte; var offs: integer);overload;
begin
   try
     move((@in_double)^,mod_arr[offs],8);
     inc(offs,8);
   except AddToLog('Add2DbyteArr exception, arg double='+FloatToStr(in_double)+' offset='+IntToStr(offs));
   end;
end;

procedure Add2DbyteArr(in_byte_arr: TBytes; var mod_arr: array of byte; var offs: integer; count: integer);overload;
begin
   try
     move(in_byte_arr,mod_arr[offs],count);
     inc(offs,count);
   except AddToLog('Add2DbyteArr exception, arg TBytes offset='+IntToStr(offs));
   end;
end;

procedure Add2DbyteArr(in_byte_arr: array of byte; var mod_arr: array of byte; var offs: integer; count: integer);overload;
begin
   try
     move(in_byte_arr[0],mod_arr[offs],count);
     inc(offs,count);
   except AddToLog('Add2DbyteArr exception, arg array of byte offset='+IntToStr(offs));
   end;
end;

procedure Add2DbyteArr(in_str: string; var mod_arr: array of byte; var offs: integer);overload;
begin
   try
     if in_str<>'' then
        move((@in_str[1])^,mod_arr[offs],length(in_str)+1)
     else mod_arr[offs]:=0;
     inc(offs,length(in_str)+1);
   except AddToLog('Add2DbyteArr exception, arg string='+in_str+' offset='+IntToStr(offs));
   end;
end;

procedure GetFromDByteArr(out result: TBytes; const const_arr: array of byte; var offs: integer; count: integer);overload;
begin
   try
     move(const_arr[offs],result,count);
     inc(offs,count);
   except AddToLog('GetFromDByteArr exception, result TBytes offset='+IntToStr(offs));
   end;
end;

procedure GetFromDByteArr(out result: array of byte; const const_arr: array of byte; var offs: integer; count: integer);overload;
begin
   try
     move(const_arr[offs],result[0],count);
     inc(offs,count);
   except AddToLog('GetFromDByteArr exception, result array of byte offset='+IntToStr(offs));
   end;
end;

procedure Add2byteArr(in_str: string; var mod_arr; var offs: integer);overload;
begin
   try
     if in_str<>'' then
          move((@in_str[1])^,(@TBytes(mod_arr)[offs])^,length(in_str)+1)
     else TBytes(mod_arr)[offs]:=0;
     inc(offs,length(in_str)+1);
   except AddToLog('Add2byteArr exception, arg string='+in_str+' offset='+IntToStr(offs));
   end;
end;

end.
