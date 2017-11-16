unit ByteArrayHandler;

interface

uses
    Windows, Avl;

const
     maxDArrSize = 10000;

type
  TBytes = array[0..MaxInt - 1] of Byte;

  procedure RandArray(var InArray; length: integer);
  procedure ReverseByteArray(var InArray; length: integer);

  procedure Add2byteArr(in_byte: byte; var mod_arr; var offs: integer);overload;
  procedure Add2byteArr(in_word: word; var mod_arr; var offs: integer);overload;
  procedure Add2byteArr(in_int: integer; var mod_arr; var offs: integer);overload;
  procedure Add2byteArr(in_dword: dword; var mod_arr; var offs: integer);overload;
  procedure Add2byteArr(in_int64: int64; var mod_arr; var offs: integer);overload;
  procedure Add2byteArr(in_single: single; var mod_arr; var offs: integer);overload;
  procedure Add2byteArr(in_double: double; var mod_arr; var offs: integer);overload;
  procedure Add2byteArr(in_byte_arr: TBytes; var mod_arr; var offs: integer; count: integer);overload;
  procedure Add2byteArr(in_str: string; var mod_arr; var offs: integer);overload;

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

  procedure GetFromByteArr(out result: byte; const const_arr; var offs: integer);overload;
  procedure GetFromByteArr(out result: word; const const_arr; var offs: integer);overload;
  procedure GetFromByteArr(out result: integer; const const_arr; var offs: integer);overload;
  procedure GetFromByteArr(out result: dword; const const_arr; var offs: integer);overload;
  procedure GetFromByteArr(out result: int64; const const_arr; var offs: integer);overload;
  procedure GetFromByteArr(out result: single; const const_arr; var offs: integer);overload;
  procedure GetFromByteArr(out result: double; const const_arr; var offs: integer);overload;
  procedure GetFromByteArr(out result: TBytes; const const_arr; var offs: integer; count: integer);overload;
  procedure GetFromByteArr(out result: array of byte; const const_arr; var offs: integer; count: integer);overload;
  procedure GetFromByteArr(out result: string; const const_arr; var offs: integer);overload;

  procedure GetFromDByteArr(out result: byte; const const_arr: array of byte; var offs: integer);overload;
  procedure GetFromDByteArr(out result: word; const const_arr: array of byte; var offs: integer);overload;
  procedure GetFromDByteArr(out result: integer; const const_arr: array of byte; var offs: integer);overload;
  procedure GetFromDByteArr(out result: dword; const const_arr: array of byte; var offs: integer);overload;
  procedure GetFromDByteArr(out result: int64; const const_arr: array of byte; var offs: integer);overload;
  procedure GetFromDByteArr(out result: single; const const_arr: array of byte; var offs: integer);overload;
  procedure GetFromDByteArr(out result: double; const const_arr: array of byte; var offs: integer);overload;
  procedure GetFromDByteArr(out result: TBytes; const const_arr: array of byte; var offs: integer; count: integer);overload;
  procedure GetFromDByteArr(out result: array of byte; const const_arr: array of byte; var offs: integer; count: integer);overload;
  procedure GetFromDByteArr(out result: string; const const_arr: array of byte; var offs: integer);overload;

  function FillIntArrWithStrData(InString,delim: string; var data: array of integer):integer;

implementation

uses UnitMain;

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

procedure Add2byteArr(in_byte: byte; var mod_arr; var offs: integer);overload;
begin
   try
     TBytes(mod_arr)[offs]:=in_byte;
     inc(offs);
   except AddToLog('Add2byteArr exception, arg byte='+IntToHex(in_byte,2)+' offset='+IntToStr(offs));
   end;
end;

procedure Add2byteArr(in_word: word; var mod_arr; var offs: integer);overload;
begin
   try
     move((@in_word)^,(@TBytes(mod_arr)[offs])^,2);
     inc(offs,2);
   except AddToLog('Add2byteArr exception, arg word='+IntToHex(in_word,2)+' offset='+IntToStr(offs));
   end;
end;

procedure Add2byteArr(in_int: integer; var mod_arr; var offs: integer);overload;
begin
   try
     move((@in_int)^,(@TBytes(mod_arr)[offs])^,4);
     inc(offs,4);
   except AddToLog('Add2byteArr exception, arg integer='+IntToStr(in_int)+' offset='+IntToStr(offs));
   end;
end;

procedure Add2byteArr(in_dword: dword; var mod_arr; var offs: integer);overload;
begin
   try
     move((@in_dword)^,(@TBytes(mod_arr)[offs])^,4);
     inc(offs,4);
   except AddToLog('Add2byteArr exception, arg dword='+IntToStr(in_dword)+' offset='+IntToStr(offs));
   end;
end;

procedure Add2byteArr(in_int64: int64; var mod_arr; var offs: integer);overload;
begin
   try
     move((@in_int64)^,(@TBytes(mod_arr)[offs])^,8);
     inc(offs,8);
   except AddToLog('Add2byteArr exception, arg int64='+IntToStr(in_int64)+' offset='+IntToStr(offs));
   end;
end;

procedure Add2byteArr(in_single: single; var mod_arr; var offs: integer);overload;
begin
   try
     move((@in_single)^,(@TBytes(mod_arr)[offs])^,4);
     inc(offs,4);
   except AddToLog('Add2byteArr exception, arg single='+FloatToStr(in_single)+' offset='+IntToStr(offs));
   end;
end;

procedure Add2byteArr(in_double: double; var mod_arr; var offs: integer);overload;
begin
   try
     move((@in_double)^,(@TBytes(mod_arr)[offs])^,8);
     inc(offs,8);
   except AddToLog('Add2byteArr exception, arg double='+FloatToStr(in_double)+' offset='+IntToStr(offs));
   end;
end;

procedure Add2byteArr(in_byte_arr: TBytes; var mod_arr; var offs: integer; count: integer);overload;
begin
   try
     move(in_byte_arr,(@TBytes(mod_arr)[offs])^,count);
     inc(offs,count);
   except AddToLog('Add2byteArr exception, arg TBytes offset='+IntToStr(offs));
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

{ Simple arrays get }

procedure GetFromByteArr(out result: byte; const const_arr; var offs: integer);overload;
begin
   try
     result:=TBytes(const_arr)[offs];
     inc(offs);
   except AddToLog('GetFromByteArr exception, result byte offset='+IntToStr(offs));
   end;
end;

procedure GetFromByteArr(out result: word; const const_arr; var offs: integer);overload;
begin
   try
     move((@TBytes(const_arr)[offs])^,(@result)^,2);
     inc(offs,2);
   except AddToLog('GetFromByteArr exception, result word offset='+IntToStr(offs));
   end;
end;

procedure GetFromByteArr(out result: integer; const const_arr; var offs: integer);overload;
begin
   try
     move((@TBytes(const_arr)[offs])^,(@result)^,4);
     inc(offs,4);
   except AddToLog('GetFromByteArr exception, result integer offset='+IntToStr(offs));
   end;
end;

procedure GetFromByteArr(out result: dword; const const_arr; var offs: integer);overload;
begin
   try
     move((@TBytes(const_arr)[offs])^,(@result)^,4);
     inc(offs,4);
   except AddToLog('GetFromByteArr exception, result integer offset='+IntToStr(offs));
   end;
end;

procedure GetFromByteArr(out result: int64; const const_arr; var offs: integer);overload;
begin
   try
     move((@TBytes(const_arr)[offs])^,(@result)^,8);
     inc(offs,8);
   except AddToLog('GetFromByteArr exception, result int64 offset='+IntToStr(offs));
   end;
end;

procedure GetFromByteArr(out result: single; const const_arr; var offs: integer);overload;
begin
   try
     move((@TBytes(const_arr)[offs])^,(@result)^,4);
     inc(offs,4);
   except AddToLog('GetFromByteArr exception, result single offset='+IntToStr(offs));
   end;
end;

procedure GetFromByteArr(out result: double; const const_arr; var offs: integer);overload;
begin
   try
     move((@TBytes(const_arr)[offs])^,(@result)^,8);
     inc(offs,8);
   except AddToLog('GetFromByteArr exception, result double offset='+IntToStr(offs));
   end;
end;

procedure GetFromByteArr(out result: TBytes; const const_arr; var offs: integer; count: integer);overload;
begin
   try
     move((@TBytes(const_arr)[offs])^,result,count);
     inc(offs,count);
   except AddToLog('GetFromByteArr exception, result TBytes offset='+IntToStr(offs));
   end;
end;

procedure GetFromByteArr(out result: array of byte; const const_arr; var offs: integer; count: integer);overload;
begin
   try
     move((@TBytes(const_arr)[offs])^,result[0],count);
     inc(offs,count);
   except AddToLog('GetFromByteArr exception, result array of byte offset='+IntToStr(offs));
   end;
end;

procedure GetFromByteArr(out result: string; const const_arr; var offs: integer);overload;
var
   presult: PChar;
begin
   try
     presult:=@TBytes(const_arr)[offs];
     result:=strpas(presult);
     inc(offs,length(result)+1);
   except AddToLog('GetFromByteArr exception, result string offset='+IntToStr(offs));
   end;
end;

{ Dynamic arrays get }

procedure GetFromDByteArr(out result: byte; const const_arr: array of byte; var offs: integer);overload;
begin
   try
     result:=const_arr[offs];
     inc(offs);
   except AddToLog('GetFromDByteArr exception, result byte offset='+IntToStr(offs));
   end;
end;

procedure GetFromDByteArr(out result: word; const const_arr: array of byte; var offs: integer);overload;
begin
   try
     move(const_arr[offs],(@result)^,2);
     inc(offs,2);
   except AddToLog('GetFromDByteArr exception, result word offset='+IntToStr(offs));
   end;
end;

procedure GetFromDByteArr(out result: integer; const const_arr: array of byte; var offs: integer);overload;
begin
   try
     move(const_arr[offs],(@result)^,4);
     inc(offs,4);
   except AddToLog('GetFromDByteArr exception, result integer offset='+IntToStr(offs));
   end;
end;

procedure GetFromDByteArr(out result: dword; const const_arr: array of byte; var offs: integer);overload;
begin
   try
     move(const_arr[offs],(@result)^,4);
     inc(offs,4);
   except AddToLog('GetFromDByteArr exception, result dword offset='+IntToStr(offs));
   end;
end;

procedure GetFromDByteArr(out result: int64; const const_arr: array of byte; var offs: integer);overload;
begin
   try
     move(const_arr[offs],(@result)^,8);
     inc(offs,8);
   except AddToLog('GetFromDByteArr exception, result int64 offset='+IntToStr(offs));
   end;
end;

procedure GetFromDByteArr(out result: single; const const_arr: array of byte; var offs: integer);overload;
begin
   try
     move(const_arr[offs],(@result)^,4);
     inc(offs,4);
   except AddToLog('GetFromDByteArr exception, result single offset='+IntToStr(offs));
   end;
end;

procedure GetFromDByteArr(out result: double; const const_arr: array of byte; var offs: integer);overload;
begin
   try
     move(const_arr[offs],(@result)^,8);
     inc(offs,8);
   except AddToLog('GetFromDByteArr exception, result double offset='+IntToStr(offs));
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

procedure GetFromDByteArr(out result: string; const const_arr: array of byte; var offs: integer);overload;
var
   presult: PChar;
begin
   try
     presult:=@const_arr[offs];
     result:=strpas(presult);
     inc(offs,length(result)+1);
   except AddToLog('GetFromDByteArr exception, result string offset='+IntToStr(offs));
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

end.
