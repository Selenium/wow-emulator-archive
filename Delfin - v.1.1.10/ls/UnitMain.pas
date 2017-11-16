unit UnitMain;

//{$define debug}


interface

uses
  Windows, WinSock, Messages, Avl, SysUtils, Classes, AcedContainers, LbBigInt,
  uMySqlVio, uMysqlCT, uMysqlClient, uMysqlHelpers;

const
  WM_AuthSocketEvent = WM_User + 1; //Наше событие для логин сокета

  Th20arraySize=$20;
  Th20arrayEnd=$1F;
  T20arraySize=20;
  T20arrayEnd=19;

  COLOR_ERR = FOREGROUND_RED or FOREGROUND_INTENSITY;

const  //Challenge Error
  CE_SUCCESS              = $00;
	CE_IPBAN                = $01; //2bd -- unable to connect (some internal problem)
  CE_ACCOUNT_CLOSED       = $03; // "This account has been closed and is no longer in service -- Please check the registered email address of this account for further information.";
  CE_NO_ACCOUNT           = $04; //(5)The information you have entered is not valid.  Please check the spelling of the account name and password.  If you need help in retrieving a lost or stolen password and account
  CE_ACCOUNT_IN_USE       = $06; //This account is already logged in.  Please check the spelling and try again.
  CE_PREORDER_TIME_LIMIT  = $07;
	CE_SERVER_FULL          = $08; //Could not log in at this time.  Please try again later.
	CE_WRONG_BUILD_NUMBER   = $09; //Unable to validate game version.  This may be caused by file corruption or the interference of another program.
	CE_UPDATE_CLIENT        = $0a;
  CE_ACCOUNT_FREEZED      = $0c;

type
  TPlayer = class(TObject)
  public
    acc_name, password: string;
    Access: Byte;
    timezone_bias: dword;
    Sockt: integer;
    SS_Hash: array[0..39]of byte;
    salt: array[0..31]of byte;
    bi_B,bi_N,bi_v,bi_R : TLbBigInt;
    constructor Create(name: string);
  end;

  AuthProcs = procedure(Sock: TSocket;const ByteBuff: array of byte; rec_len: integer);
  Th20array = array[0..Th20arrayEnd]of byte;
  T20array = array[0..T20arrayEnd]of byte;
  
  TForm1 = class(TForm)
    mmLog: TMemo;
    procedure FormCreate(Sender: TObject);
  private
    AuthSock: TSocket;
    procedure WMAuthSocketEventHandler(var Msg:TMessage);message WM_AuthSocketEvent;
    procedure ReadFromAuthSocket(Sock:TSocket);
  end;

procedure AddToLog(LogString: string);
procedure EmpyOffset(Sock: TSocket;const ByteBuff: array of byte; rec_len: integer);
procedure LRChallenge(Sock: TSocket;const ByteBuff: array of byte; rec_len: integer);
procedure LRProof(Sock: TSocket;const ByteBuff: array of byte; rec_len: integer);
procedure LRRealmList(Sock: TSocket; const ByteBuff: array of byte; rec_len: integer);

var
  Form1: TForm1;
  player_count: integer;

  AuthPlayersHT: TStringHashtable;
  AuthPlayersAccBySockHT: TIntegerHashtable;

  AppPath, ConfigFileName: string;
  AuthProcTable : Array [0..$11] of AuthProcs;

  LoginIP: String;
  LoginPort: Integer;
  RealmPort: Integer;
  
  MinVersionBuild,
  MaxVersionBuild: Integer; //Версия клиента разрешенная для игры

//База
  ms: TMySQLClient;
  mr: TMysqlResult;

  ConsoleColor: Word;

implementation

uses LbCipher, LbClass, ByteArrayHandler;

procedure AddToLog(LogString: string);
var
  FormatLogString: String;
  LogFile: Textfile ;
  {$IFDEF CONSOLE}
    hConsole: THandle;
    ConsoleScreenBufferInfo: TConsoleScreenBufferInfo ;
  {$ENDIF}
begin
  FormatLogString := '['+TimeToStr(Now)+'] ' + LogString;
  {$IFDEF CONSOLE}
    hConsole := GetStdHandle(STD_OUTPUT_HANDLE);
    GetConsoleScreenBufferInfo(hConsole, ConsoleScreenBufferInfo);
    SetConsoleTextAttribute(hConsole, ConsoleColor);
    WriteLn(FormatLogString);
    ConsoleColor := ConsoleScreenBufferInfo.wAttributes ; //Востанавливаем стандартный цвет консоли
    SetConsoleTextAttribute(hConsole, ConsoleColor);
  {$ELSE}
    if Form1 <> nil then Form1.mmLog.LineAdd(FormatLogString);
  {$ENDIF}
  try
    AssignFile(LogFile, AppPath + 'logs\loginserver.log');
    {$I-}
    Append(LogFile);
    {$I+}
    if IOResult<>0 then Rewrite(LogFile);
    {$I-}
    writeln(LogFile, FormatLogString);
    {$I+}
    if IOResult<>0 then;
    Flush(LogFile);
    CloseFile(LogFile);
  except;
  end;
end;

constructor TPlayer.Create(name: String);   
begin
  if name <> 'nil' then
    acc_name := AnsiUpperCase(name);
end;

procedure TForm1.ReadFromAuthSocket(Sock: TSocket);
var
   cmd: byte;
   lmsg,lstr: string;
   received_len,i: integer;    //len,
   //ByteBuff: array of byte;
   ByteBuff: array[0..maxword] of byte;
   Addr:TSockAddr;
begin
  try
    //AddToLog('1');
    i := SizeOf(Addr);
    getsockname(sock, addr, i);
    //AddToLog('2');
    //setlength(ByteBuff,$4000);
    //AddToLog('3');
    received_len:=Recv(Sock,ByteBuff[0],length(ByteBuff),0);
    //AddToLog('4');
    //setlength(ByteBuff,received_len);
    //AddToLog('5');
    if received_len>0 then begin
      lmsg:='';lstr:='';
      for i:=0 to pred(received_len) do lmsg:=lmsg+IntToHex(ByteBuff[i],2)+' ';
      for i:=0 to pred(received_len) do if ByteBuff[i]<>0 then lstr:=lstr+char(ByteBuff[i])+' ';
      {$ifdef debug}
      AddToLog('['+inet_ntoa(Addr.sin_addr)+'] receive auth socket ='+IntToStr(Sock));
      AddToLog('['+inet_ntoa(Addr.sin_addr)+'] Msg='+lmsg+' ('+lstr+')'+#$d#$a);
      {$endif}
    end;
    //AddToLog('6');
    cmd:=ByteBuff[0];
    if (cmd < $12) then
      AuthProcTable[cmd](Sock,ByteBuff,received_len);
    //AddToLog('7');      
  except
    ConsoleColor := COLOR_ERR;
    AddToLog('['+inet_ntoa(Addr.sin_addr)+'] ERROR ReadFromAuthSocket');
  end;
end;

procedure TForm1.WMAuthSocketEventHandler(var Msg: TMessage);
var
  Sock:TSocket;
  SockError,AcceptResult:Integer;
  Addr:TSockAddr;
  Len:Integer;
begin
  try
   Sock:=TSocket(Msg.WParam);
   SockError:=WSAGetSelectError(Msg.lParam);
   if SockError<>0 then
    begin
     // Здесь должен быть анализ ошибки
     CloseSocket(Sock);
     Exit
    end;
   case WSAGetSelectEvent(Msg.lParam) of
    FD_Read:
     begin
      // Пришёл запрос от клиента. Необходимо прочитать данные,
      // сформировать ответ и отправить его.
      ReadFromAuthSocket(Sock);
     end;
    FD_Accept:
     begin
      // Просто вызываем функцию Accept. Её результат нигде не
      // сохраняется, потому что вновь созданный сокет автоматически
      // начинает работать в асинхронном режиме, и его дескриптор при
      // необходимости будет передан через Msg.wParam при возникновении
      // события
      AcceptResult:=Accept(Sock,@Addr,@Len);    //
      //Sleep(20);
      AddToLog('['+inet_ntoa(Addr.sin_addr)+'] *** AcceptResult='+IntToStr(AcceptResult));
     end;
    FD_Close:
     begin
      // Получив от клиента сигнал завершения, сервер, в принципе,
      // может попытаться отправить ему данные. После этого сервер
      // также должен соединение со своей стороны
      Shutdown(Sock,1);
      CloseSocket(Sock);
     end
   end
  except
   ConsoleColor := COLOR_ERR;
   AddToLog('['+inet_ntoa(Addr.sin_addr)+'] ERROR WMAuthSocketEventHandler');
  end;
end;

procedure Query(s: String);
var
  ok: Boolean;
begin
  try
    if ms.Connected then mr := ms.query(s, True, ok);
    if not ok then AddToLog('DB: ' + ms.LastError);
  except
    ConsoleColor := COLOR_ERR;
    AddToLog('DB: ERROR Query'); 
  end;
end;

procedure TForm1.FormCreate(Sender: TObject);
var
  Data:TWSAData;
  Addr:TSockAddr;
  i: Integer;
begin
  player_count:=0;
  Randomize;

  AppPath := ExtractFilePath(ExeName);
  ConfigFileName := AppPath + 'config\loginserver.conf';

  //Читаем конфиг

  ms := TMySQLClient.Create;
  ms.Host := IniGetStr(ConfigFileName, 'db', 'dbhost', 'localhost');
  ms.Port := IniGetInt(ConfigFileName, 'db', 'dbport', 3306);
  ms.Db := IniGetStr(ConfigFileName, 'db', 'dbname', 'wowext');
  ms.User := IniGetStr(ConfigFileName, 'db', 'dbuser', 'root');
  ms.Password := IniGetStr(ConfigFileName, 'db', 'dbpwd', '');

  LoginIP := IniGetStr(ConfigFileName, 'main', 'LoginIP', '127.0.0.1');
  LoginPort := IniGetInt(ConfigFileName, 'main', 'LoginPort', 3724);
  MinVersionBuild := IniGetInt(ConfigFileName, 'main', 'MinVersionBuild', 0);
  MaxVersionBuild := IniGetInt(ConfigFileName, 'main', 'MaxVersionBuild', 10000);
  AddToLog('Config loaded');
 
  if not ms.Connect then begin
    ConsoleColor := COLOR_ERR;
    AddToLog('DB: ' + ms.LastError) ;
    {$IFDEF CONSOLE} ReadLn ; {$ENDIF}
    ExitProcess(0);
  end;
  AddToLog('DB: Initilized');

  //Получаем кол-во акков
  Query('select * from `accounts`');
  AddToLog('Accounts loaded ('+IntToStr(mr.RowsCount)+')');  

  AuthPlayersHT:=TStringHashtable.Create(false);
  AuthPlayersAccBySockHT:=TIntegerHashtable.Create(0);

  //Загрузка списка реалмов (пока тока один - статичный)
  Query('select * from `realms`');
  for i := 0 to mr.RowsCount - 1 do begin
    AddToLog('Realm added: ' + mr.FieldValueByName('name') + ' ('+mr.FieldValueByName('ip')+':'+mr.FieldValueByName('port')+')');
    mr.Next ;
  end;

  //Сетевая инициализация
  WSAStartup($101,Data);

  AuthSock:=Socket(AF_Inet,Sock_stream,0);
  Addr.sin_family:=PF_Inet;
  Addr.sin_addr.S_addr:=Inet_addr(PChar(LoginIP));
  Addr.sin_port := HToNS(LoginPort);
  FillChar(Addr.sin_zero,SizeOf(Addr.sin_zero),0);
  Bind(AuthSock,Addr,SizeOf(Addr));
  Listen(AuthSock,SOMaxConn);
  WSAAsyncSelect(AuthSock,Handle, WM_AuthSocketEvent,FD_Read or FD_Accept or FD_Close);
  AddToLog('Listen on port ' + IntToStr(LoginPort)+', IP ' + LoginIP);
end;

procedure SendError(Sock: TSocket; ErrorCode: Byte);
var
  out_buff: array of Byte;
begin
  SetLength(out_buff, 2);
  out_buff[0] := 1;
  out_buff[1] := ErrorCode ;
  Send(Sock,out_buff[0],2,0);
end;

procedure EmpyOffset(Sock: TSocket;const ByteBuff: array of byte; rec_len: integer);
var
  i: Integer;
  Addr: TSockAddr;
begin
  i := SizeOf(Addr);
  getsockname(sock, addr, i);
  AddToLog('['+inet_ntoa(Addr.sin_addr)+'] EmptyOffset');
end;
                                                                       
{ CMD_AUTH_LOGON_CHALLENGE
    uint8   cmd;
    uint8   error;
    uint16  size;                                 
    uint8   gamename[4];                          
    uint8   version1;                             
    uint8   version2;                             
    uint8   version3;                             
    uint16  build;                                
    uint8   platform[4];                          
    uint8   os[4];                                
    uint8   country[4];                           
    uint32  timezone_bias;                        
    uint32  ip;                                   
    uint8   I_len;                                
    uint8   I[1];
}
procedure LRChallenge(Sock: TSocket;const ByteBuff: array of byte; rec_len: integer);
var
   acc_len, version, version_major, version_minor: byte;
   {pkt_size,}version_build: word;
   ltimezone_bias,lrem_ip: dword;
   lacc_name,namepasstsr: string;
   i,digest_len,offs: integer;
   pword: ^word;
   pdword: ^dword;
   lip_addr: in_addr;
   Digest,Digest2: TSHA1Digest;
   x,gmod : TLbBigInt;
   res_array,out_buff: array of byte;
   prom_byte_array,N_array: Th20array;
   CurrPlayer: TPlayer;
   LbSHA11: TLbSHA1;

   Addr:TSockAddr;
begin
  try
    i := SizeOf(Addr);
    getsockname(sock, addr, i);
    CurrPlayer := nil;
    if rec_len>$22 then
      with Form1 do begin
        LbSHA11:=TLbSHA1.Create(nil);
        //pword:=@ByteBuff[2];pkt_size:=pword^;

        //Версия клиента
        version := ByteBuff[$8];
        version_major := ByteBuff[$9];
        version_minor := ByteBuff[$A];
        pword:=@ByteBuff[$B]; version_build := pword^;

        pdword:=@ByteBuff[$19];ltimezone_bias:=pdword^;
        pdword:=@ByteBuff[$1D];lrem_ip:=pdword^;
        acc_len:=ByteBuff[$21];
        lacc_name:=''; for i:=$22 to pred($22+acc_len)do lacc_name:=lacc_name+char(ByteBuff[i]);
        lip_addr.S_addr:=lrem_ip;

        AddToLog('['+inet_ntoa(Addr.sin_addr)+'] CMD_AUTH_LOGON_CHALLENGE ['+lacc_name+'] version ['+IntToStr(version)+'.'+IntToStr(version_major)+'.'+IntToStr(version_minor)+'.'+IntToStr(version_build)+']');

        //Проверка версии клиента
        if (MinVersionBuild > version_build) or (MaxVersionBuild < version_build) then //Версия не подходит
          SendError(Sock, CE_WRONG_BUILD_NUMBER)
        else
          if AuthPlayersHT.Contains(lacc_name) then
            CurrPlayer:=AuthPlayersHT[lacc_name]
          else begin
            CurrPlayer:=TPlayer.Create(lacc_name);
            AuthPlayersHT.Add(lacc_name,CurrPlayer);
          end;
        with CurrPlayer do begin
          //ip_addr:=lip_addr;
          //rem_ip:=lrem_ip;
          timezone_bias:=ltimezone_bias;
          Sockt:=Sock;

          Query('select * from `accounts` where login="'+acc_name+'"');
          if mr.RowsCount =  1 then begin
            if mr.FieldValueByName('preorder') = '1' then begin
              SendError(Sock, CE_PREORDER_TIME_LIMIT);
              ConsoleColor := COLOR_ERR;
              AddToLog('> Accounts "'+acc_name+'" preorder timed out');
              Exit;
            end;
            if mr.FieldValueByName('freezed') = '1' then begin
              SendError(Sock, CE_ACCOUNT_FREEZED);
              ConsoleColor := COLOR_ERR;
              AddToLog('> Accounts "'+acc_name+'" freezed');
              Exit;
            end;
            if mr.FieldValueByName('banned') = '1' then begin
              SendError(Sock, CE_ACCOUNT_CLOSED);
              ConsoleColor := COLOR_ERR;
              AddToLog('> Accounts "'+acc_name+'" banned');
              Exit;
            end;
            if AuthPlayersAccBySockHT.Contains(Sock) then AuthPlayersAccBySockHT.Remove(Sock);
            AuthPlayersAccBySockHT.Add(Sock,@acc_name);

            namepasstsr:=acc_name+':'+AnsiUpperCase(mr.FieldValueByName('password'));
            Access := StrToInt(mr.FieldValueByName('access'));
            //AddToLOg(IntToStr(Access));
            LbSHA11.HashString(namepasstsr);
            LbSHA11.GetDigest(Digest);

            RandArray(salt,length(salt));
            digest_len:=length(Digest);
            SetLength(res_array,digest_len+Th20arraySize);
            for i:=0 to Th20arrayEnd do res_array[i]:=salt[i];
            for i:=0 to pred(digest_len) do res_array[i+Th20arraySize]:=Digest[i];

            LbSHA11.HashBuffer(res_array[0],Th20arraySize+digest_len);
            LbSHA11.GetDigest(Digest2);
            res_array:=nil;

           x:= TLbBigInt.Create(0);
               x.CopyBuffer(Digest2,length(Digest2));
               bi_N:=TLbBigInt.Create(0);
               bi_N.CopyHexStr('894B645E89E1535BBDAD5B8B290650530801B18EBFBF5E8FAB3C82872A3E9BB7');
               bi_v:=TLbBigInt.Create(0);
               bi_v.CopyByte(7);
               bi_v.PowerAndMod(x,bi_N);

//               ShowMessage(IntToHex() );

               bi_B:=TLbBigInt.Create(0);
               bi_B.RandomBytes(20);
               //bi_B.CopyHexStr('8692E3A6BA48B5B1004CEF76825127B7EB7D1AEF');
               gmod:=TLbBigInt.Create(0);
               gmod.CopyByte(7);
               gmod.PowerAndMod(bi_B,bi_N);

		           bi_R:=TLbBigInt.Create(0);
               bi_R.CopyByte(3);
               bi_R.Multiply(bi_v);
               bi_R.Add(gmod);
               bi_R.Modulus(bi_N);
               bi_R.ToBuffer(prom_byte_array,length(prom_byte_array));

               setlength(out_buff,3+length(prom_byte_array)+3+length(N_array)+length(salt)+16);
               offs:=3;
               Add2DbyteArr(prom_byte_array,out_buff,offs,length(prom_byte_array));
               Add2DbyteArr(byte(1),out_buff,offs);
               Add2DbyteArr(byte(7),out_buff,offs);
               Add2DbyteArr(byte(32),out_buff,offs);
               bi_N.ToBuffer(N_array,Th20arraySize);
               Add2DbyteArr(N_array,out_buff,offs,length(N_array));
               Add2DbyteArr(salt,out_buff,offs,length(salt));

               x.Free; gmod.Free;

               send(Sock,out_buff[0],length(out_buff),0);
               inc(player_count);
          end
          else begin
               ConsoleColor := COLOR_ERR;
               AddToLog('['+inet_ntoa(Addr.sin_addr)+'] Account not found: ' + acc_name);
               SendError(Sock, CE_NO_ACCOUNT);
          end;
     end;
     out_buff:=nil;LbSHA11.Free;
     end;
 except
   ConsoleColor := COLOR_ERR;
   AddToLog('['+inet_ntoa(Addr.sin_addr)+'] ERROR LRChallenge');
 end;
end;

procedure LRProof(Sock: TSocket;const ByteBuff: array of byte; rec_len: integer);
var
   i,offs: integer;
   Digest: TSHA1Digest;
   same: boolean;
   bi_U,bi_A,bi_S : TLbBigInt;
   B_array,A_array,t,n_array: Th20array;
   kM1,NHash,userHash: T20array;     //,GHash
   t1: array[0..15]of byte;
   vK: array[0..39]of byte;
   prom64array: array[0..63]of byte;
   temp,out_buff: array of byte;
   Hash7: array[0..0]of byte;
   CurrPlayer: TPlayer;
   LbSHA11: TLbSHA1;

   Addr:TSockAddr;
begin
  try
    i := SizeOf(Addr);
    getsockname(sock, addr, i);
    AddToLog('['+inet_ntoa(Addr.sin_addr)+'] CMD_AUTH_LOGON_PROOF');
    if rec_len>52 then
      with Form1 do begin
        LbSHA11:=TLbSHA1.Create(nil);
        if AuthPlayersAccBySockHT.Contains(Sock) then begin
          CurrPlayer:=AuthPlayersHT[string(AuthPlayersAccBySockHT[Sock]^)];
          if CurrPlayer <> nil then
            with CurrPlayer do begin
              move(ByteBuff[1],A_array,32);
              move(ByteBuff[$21],kM1,20);

              move(A_array,prom64array,32);
              bi_R.ToBuffer(B_array,Th20arraySize);
              move(B_array,(@prom64array[32])^,32);

              LbSHA11.HashBuffer(prom64array,length(prom64array));
              LbSHA11.GetDigest(Digest);

              bi_U:=TLbBigInt.Create(0);
              bi_U.CopyBuffer(Digest,length(Digest));
              bi_S:=TLbBigInt.Create(0);
              bi_S.Copy(bi_v);
              bi_S.PowerAndMod(bi_U,bi_N);
              bi_A:=TLbBigInt.Create(0);
              bi_A.CopyBuffer(A_array,length(A_array));
              bi_S.Multiply(bi_A);
              bi_S.PowerAndMod(bi_B,bi_N);

              bi_S.ToBuffer(t,length(t));

              for i:=0 to 15 do t1[i]:= t[i shl 1];
              LbSHA11.HashBuffer(t1,length(t1));
              LbSHA11.GetDigest(Digest);
              for i:=0 to 19 do vK[i shl 1]:=Digest[i];
              for i:=0 to 15 do t1[i]:= t[(i shl 1)+1];
              LbSHA11.HashBuffer(t1,length(t1));
              LbSHA11.GetDigest(Digest);
              for i:=0 to 19 do vK[(i shl 1)+1]:=Digest[i];

              move(vK,SS_Hash,40);

              bi_N.ToBuffer(n_array,Th20arraySize);
              LbSHA11.HashBuffer(n_array,Th20arraySize);
              LbSHA11.GetDigest(Digest);

              move(Digest,NHash,20);
              Hash7[0]:=7;
              LbSHA11.HashBuffer(Hash7,length(Hash7));
              LbSHA11.GetDigest(Digest);

              for i:=0 to T20arrayEnd do NHash[i]:=NHash[i] xor Digest[i];

              LbSHA11.HashString(CurrPlayer.acc_name);
              LbSHA11.GetDigest(Digest);
              move(Digest,userHash,20);

              setlength(temp,length(NHash)+length(userHash)+length(salt)+length(A_array)+length(B_array)+length(vK));
              offs:=0;
              Add2DbyteArr(NHash,temp,offs,length(NHash));
              Add2DbyteArr(userHash,temp,offs,length(userHash));
              Add2DbyteArr(salt,temp,offs,length(salt));
              Add2DbyteArr(A_array,temp,offs,length(A_array));
              Add2DbyteArr(B_array,temp,offs,length(B_array));
              Add2DbyteArr(vK,temp,offs,length(vK));

              LbSHA11.HashBuffer(temp[0],length(temp));
              LbSHA11.GetDigest(Digest);

              i:=0;same:=true;
              while (i<length(Digest))and(same) do begin
                if kM1[i]<>Digest[i] then same:=false;
                inc(i);
              end;

              if same then begin
                setlength(temp,length(A_array)+length(Digest)+length(vK));
                offs:=0;
                Add2DbyteArr(A_array,temp,offs,length(A_array));
                Add2DbyteArr(Digest,temp,offs,length(Digest));
                Add2DbyteArr(vK,temp,offs,length(vK));
                LbSHA11.HashBuffer(temp[0],length(temp));
                LbSHA11.GetDigest(Digest);

                setlength(out_buff,length(Digest)+6);
                out_buff[0]:=1;
                offs:=2 ;
                Add2DbyteArr(Digest,out_buff,offs,length(Digest));
                Send(Sock,out_buff[0],length(out_buff),0);

                //update last ip
                Query('UPDATE `accounts` SET lastip="'+inet_ntoa(Addr.sin_addr)+'" WHERE login="'+acc_name+'"');
              end else begin
                ConsoleColor := COLOR_ERR;
                AddToLog('['+inet_ntoa(Addr.sin_addr)+'] Incorrect password for account: ' + acc_name);
                SendError(Sock, CE_NO_ACCOUNT);
              end;
              bi_U.Free;bi_A.Free;bi_S.Free;
            end;
          end else SendError(Sock, CE_NO_ACCOUNT);
          out_buff:=nil;temp:=nil;LbSHA11.Free;
        end;
  except
    ConsoleColor := COLOR_ERR;
    AddToLog('['+inet_ntoa(Addr.sin_addr)+'] ERROR LRProof');
  end;
end;

procedure LRRealmList(Sock: TSocket; const ByteBuff: array of byte; rec_len: integer);
var
  out_buff: array of byte;
  offs,atlen,ln, i: integer;
  Addr:TSockAddr;
  RealmsCount: Byte;
begin
 try
  i := SizeOf(Addr);
  getsockname(sock, addr, i);
  AddToLog('['+inet_ntoa(Addr.sin_addr)+'] CMD_REALM_LIST');

  ln := 0;
  Query('select * from `realms`');

  RealmsCount := mr.RowsCount;
  setlength(out_buff, RealmsCount*100); //Выделяем 100 байт массив под каждый рилм
  offs:=0;
  Add2DbyteArr(byte($10),out_buff,offs); //Заголовок пакета со списком рилмов
  Add2DbyteArr(word(43),out_buff,offs);
  Add2DbyteArr(integer(0),out_buff,offs);
  Add2DbyteArr(byte(RealmsCount),out_buff,offs);    //Количество рилмов

  for i := 0 to RealmsCount - 1 do begin
    Add2DbyteArr(integer(0),out_buff,offs);
    Add2DbyteArr(byte(0),out_buff,offs);
    //ShowMessage(mr.FieldValueByName('name'));
    Add2DbyteArr(mr.FieldValueByName('name'), out_buff,offs);
    Add2DbyteArr(mr.FieldValueByName('ip')+':'+mr.FieldValueByName('port'),out_buff,offs);
    Add2DbyteArr(integer(0),out_buff,offs);
    Add2DbyteArr(word(0),out_buff,offs);    //connected chars
    Add2DbyteArr(byte(1),out_buff,offs);
    Add2DbyteArr(word(0),out_buff,offs);
    atlen:=1; ln:=offs; offs:=offs-3;
    Add2DbyteArr(offs,out_buff,atlen);
    Add2DbyteArr(byte(0),out_buff,offs);
    mr.Next ;
  end;

  Send(Sock,out_buff[0],ln,0);
  out_buff:=nil;
 except
   ConsoleColor := COLOR_ERR;
   AddToLog('['+inet_ntoa(Addr.sin_addr)+'] ERROR LRRealmList');
 end;
end;

procedure LRRealmGetHashKey(Sock: TSocket; const ByteBuff: array of byte; rec_len: integer);
var
  out_buff: array of byte;
  offs, i: Integer;
  acc_name: String;
  Player: TPlayer;
  Addr:TSockAddr;
begin
  try
    acc_name := StrPas(@ByteBuff[1]);
    if AuthPlayersHT.Contains(acc_name) then begin
      AddToLog('['+inet_ntoa(Addr.sin_addr)+'] CMD_REALM_GET_HASH_KEY');
      Player:=AuthPlayersHT[acc_name];
      setlength(out_buff, Length(acc_name)+42);
      offs := 0;
      Add2DbyteArr(Byte(1), out_buff, offs);
      Add2DbyteArr(Player.Access, out_buff, offs);
      Add2DbyteArr(Byte(Length(acc_name)), out_buff, offs);
      Add2DbyteArr(acc_name, out_buff, offs);
      for i:=0 to 39 do out_buff[offs+i] := Player.SS_Hash[i];
      offs := offs + 40;
      Send(Sock, out_buff[0], offs, 0);
    end;
  except
   ConsoleColor := COLOR_ERR;
   AddToLog('['+inet_ntoa(Addr.sin_addr)+'] ERROR CMD_REALM_GET_HASH_KEY');
  end;
end;

initialization
  @AuthProcTable[0] := @LRChallenge;
  @AuthProcTable[1] := @LRProof;
  @AuthProcTable[2] := @LRChallenge;
  @AuthProcTable[3] := @LRProof;
  @AuthProcTable[4] := @EmpyOffset;
  @AuthProcTable[5] := @EmpyOffset;
  @AuthProcTable[6] := @EmpyOffset;
  @AuthProcTable[7] := @EmpyOffset;
  @AuthProcTable[8] := @EmpyOffset;
  @AuthProcTable[9] := @EmpyOffset;
  @AuthProcTable[$A] := @EmpyOffset;
  @AuthProcTable[$B] := @EmpyOffset;
  @AuthProcTable[$C] := @EmpyOffset;
  @AuthProcTable[$D] := @EmpyOffset;
  @AuthProcTable[$E] := @EmpyOffset;
  @AuthProcTable[$F] := @EmpyOffset;
  @AuthProcTable[$10] := @LRRealmList;
  @AuthProcTable[$11] := @LRRealmGetHashKey;

end.
