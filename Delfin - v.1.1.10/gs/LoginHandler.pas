unit LoginHandler;

interface

uses
  Windows, SysUtils, Classes, WinSock, AcedContainers, LbCipher, LbBigInt,
  LbClass, ByteArrayHandler, UnitMain, OpcodeHandler, DbcFieldsConst;

procedure ReadFromAuthSocket(Sock:TSocket);

implementation

var
  AuthProcTable : Array [0..$10] of AuthProcs;

procedure ReadFromAuthSocket(Sock:TSocket);
var
   cmd: byte;
   lmsg,lstr: string;
   received_len,i: integer;    //len,
   ByteBuff: array of byte;
begin
     setlength(ByteBuff,$4000);
     received_len:=Recv(Sock,ByteBuff[0],length(ByteBuff),0);
     setlength(ByteBuff,received_len);

     if received_len>0 then begin
       if LogLevel > 2 then begin
         lmsg:='';lstr:='';
         for i:=0 to pred(received_len) do lmsg:=lmsg+IntToHex(ByteBuff[i],2)+' ';
         for i:=0 to pred(received_len) do if ByteBuff[i]<>0 then lstr:=lstr+char(ByteBuff[i])+' ';
         AddToLog('receive auth socket ='+IntToStr(Sock));
         AddToLog('Msg='+lmsg+' ('+lstr+')'+#$d#$a);
       end else
         AddToLog('receive auth opcode='+IntToStr(ByteBuff[0]));
     end;

     cmd:=ByteBuff[0];
     if (cmd < $11) then
        AuthProcTable[cmd](Sock,ByteBuff,received_len);
end;

procedure EmpyOffset(Sock: TSocket;const ByteBuff: array of byte; rec_len: integer);
begin
     AddToLog('empty offset');
end;

procedure LRChallenge(Sock: TSocket;const ByteBuff: array of byte; rec_len: integer);
var
   acc_len: byte;
   //pkt_size,build_nmb: word;
   ltimezone_bias,lrem_ip: dword;
   lacc_name,namepasstsr: string;
   i,digest_len,offs: integer;
   //pword: ^word;
   pdword: ^dword;
   lip_addr: in_addr;
   Digest,Digest2: TSHA1Digest;
   x,gmod : TLbBigInt;
   res_array,out_buff: array of byte;
   prom_byte_array,N_array: Th20array;
   CurrPlayer: TPlayer;
   LbSHA11: TLbSHA1;
   paccount: PPackedAccountRecord;
begin
     if rec_len>$22 then
     with Form1 do
     begin
     LbSHA11:=TLbSHA1.Create(Form1);
     //pword:=@ByteBuff[2];pkt_size:=pword^;
     //pword:=@ByteBuff[$B];build_nmb:=pword^;
     pdword:=@ByteBuff[$19];ltimezone_bias:=pdword^;
     pdword:=@ByteBuff[$1D];lrem_ip:=pdword^;
     acc_len:=ByteBuff[$21];
     lacc_name:=''; for i:=$22 to pred($22+acc_len)do lacc_name:=lacc_name+char(ByteBuff[i]);
     lip_addr.S_addr:=lrem_ip;

     if AuthPlayersHT.Contains(lacc_name) then CurrPlayer:=AuthPlayersHT[lacc_name]
     else begin
          CurrPlayer:=TPlayer.Create(lacc_name);
          AuthPlayersHT.Add(lacc_name,CurrPlayer);
     end;
     with CurrPlayer do begin
          //ip_addr:=lip_addr;
          //rem_ip:=lrem_ip;
          timezone_bias:=ltimezone_bias;
          Sockt:=Sock;

          if AccDbcHandler.ContainStrKey(acc_name)then begin
               if AuthPlayersAccBySockHT.Contains(Sock) then AuthPlayersAccBySockHT.Remove(Sock);
               AuthPlayersAccBySockHT.Add(Sock,@acc_name);

               paccount:=PPackedAccountRecord(AccDbcHandler.GetPointerPRValueByStrKey(acc_name));
               namepasstsr:=acc_name+':'+AnsiUpperCase(AccDbcHandler.GetStringByOffset(paccount^.Password));
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
               setlength(out_buff,2);
               out_buff[0]:=1;
               out_buff[1]:=4;
               Send(Sock,out_buff[0],2,0);
          end;
     end;
     out_buff:=nil;LbSHA11.Free;
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
begin
     if rec_len>52 then
     with Form1 do
     begin
     LbSHA11:=TLbSHA1.Create(Form1);
     if AuthPlayersAccBySockHT.Contains(Sock) then
     begin
          CurrPlayer:=AuthPlayersHT[string(AuthPlayersAccBySockHT[Sock]^)];
          if CurrPlayer <> nil then
          with CurrPlayer do
          try
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
             while (i<length(Digest))and(same) do
             begin
                  if kM1[i]<>Digest[i] then same:=false;
                  inc(i);
             end;

             if same then
             begin
                  CurrPlayer.IsAuthed:=true;
                  setlength(temp,length(A_array)+length(Digest)+length(vK));
                  offs:=0;
                  Add2DbyteArr(A_array,temp,offs,length(A_array));
                  Add2DbyteArr(Digest,temp,offs,length(Digest));
                  Add2DbyteArr(vK,temp,offs,length(vK));
                  LbSHA11.HashBuffer(temp[0],length(temp));
                  LbSHA11.GetDigest(Digest);

                  setlength(out_buff,length(Digest)+6);
                  out_buff[0]:=1;
                  offs:=2;
                  Add2DbyteArr(Digest,out_buff,offs,length(Digest));
                  AddToLog('logon proof '+acc_name);

                  Send(Sock,out_buff[0],length(out_buff),0);
             end
             else begin
                  setlength(out_buff,2);
                  out_buff[0]:=1;
                  out_buff[1]:=4;
                  Send(Sock,out_buff[0],2,0);
             end;
             bi_U.Free;bi_A.Free;bi_S.Free;
          except;
          end;
     end
     else begin
          setlength(out_buff,2);
          out_buff[0]:=1;
          out_buff[1]:=4;
          Send(Sock,out_buff[0],2,0);
     end;
     out_buff:=nil;temp:=nil;LbSHA11.Free;
     end;
end;

procedure LRRealmList(Sock: TSocket;const ByteBuff: array of byte; rec_len: integer);
var
   out_buff: array of byte;
   offs,atlen,ln: integer;
begin
          setlength(out_buff,50+succ(length(RealmName))+succ(length(RealmAddr)));
          offs:=0;
          Add2DbyteArr(byte($10),out_buff,offs);
          Add2DbyteArr(word(43),out_buff,offs);
          Add2DbyteArr(integer(0),out_buff,offs);
          Add2DbyteArr(byte(1),out_buff,offs);
          Add2DbyteArr(integer(0),out_buff,offs);
          Add2DbyteArr(byte(0),out_buff,offs);
          Add2DbyteArr(RealmName,out_buff,offs);
          Add2DbyteArr(RealmAddr+':'+RealmPort,out_buff,offs);
          Add2DbyteArr(integer(0),out_buff,offs);
          Add2DbyteArr(word(0),out_buff,offs);//connected chars
          Add2DbyteArr(byte(0),out_buff,offs);
          Add2DbyteArr(word(1),out_buff,offs);
          atlen:=1;
          ln:=offs;
          offs:=offs-3;
          Add2DbyteArr(offs,out_buff,atlen);
          Send(Sock,out_buff[0],ln,0);
          out_buff:=nil;
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

end.
