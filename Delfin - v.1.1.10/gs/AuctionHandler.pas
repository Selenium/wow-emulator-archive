unit AuctionHandler;

interface

uses
  Windows, SysUtils, ByteArrayHandler, UnitMain, OpcodeHandler, OpConst,
  DbcFieldsConst, UpdateConst, ItemHandler;

procedure MSG_AUCTION_HELLO_handler(Sender: TPlayer);
procedure CMSG_AUCTION_SELL_ITEM_handler(Sender: TPlayer);
procedure CMSG_AUCTION_REMOVE_ITEM_handler(Sender: TPlayer);
procedure CMSG_AUCTION_LIST_ITEMS_handler(Sender: TPlayer);
procedure CMSG_AUCTION_LIST_OWNER_ITEMS_handler(Sender: TPlayer);
procedure CMSG_AUCTION_PLACE_BID_handler(Sender: TPlayer);
procedure CMSG_AUCTION_LIST_BIDDER_ITEMS_handler(Sender: TPlayer);

implementation

procedure MSG_AUCTION_HELLO_handler(Sender: TPlayer);
var
  guid: Int64;
begin
  if not SystemAuction then Exit ;
  Sender.ReceiveBuff.Get(guid);
  Sender.SendBuff.Init(MSG_AUCTION_HELLO);
  Sender.SendBuff.Add(guid);
  Sender.SendBuff.Add(Integer(0));
  Sender.SendPacket ;
end;

procedure CMSG_AUCTION_SELL_ITEM_handler(Sender: TPlayer);
var
  auctioneer, item: Int64;
  etime, bid, buyout: Integer;
  time_t: Single;
begin
  if not SystemAuction then Exit ;
  Sender.ReceiveBuff.Get(auctioneer);
  Sender.ReceiveBuff.Get(item);
  Sender.ReceiveBuff.Get(bid);
  Sender.ReceiveBuff.Get(buyout);
  Sender.ReceiveBuff.Get(etime);

  time_t := (etime * 60) + Now ;
  AddToLog('selling item '+IntToStr(item)+' to auctioneer '+IntToStr(auctioneer)+' with inital bid '+IntToStr(bid)+' with buyout '+IntToStr(buyout)+' and with time '+FloatToStr(time_t)+' (in minutes)');
end;

procedure CMSG_AUCTION_REMOVE_ITEM_handler(Sender: TPlayer);
begin
  if not SystemAuction then Exit ;
	{}
end;

procedure CMSG_AUCTION_LIST_ITEMS_handler(Sender: TPlayer);
begin
  if not SystemAuction then Exit ;
	{}
end;

procedure CMSG_AUCTION_LIST_OWNER_ITEMS_handler(Sender: TPlayer);
begin
  if not SystemAuction then Exit ;
	{}
end;

procedure CMSG_AUCTION_PLACE_BID_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_AUCTION_LIST_BIDDER_ITEMS_handler(Sender: TPlayer);
var
  guid: Int64;
  unknownAuction: Single;
  BidCount: Integer;
begin
  if not SystemAuction then Exit ;
  Sender.ReceiveBuff.Get(guid);
  Sender.ReceiveBuff.Get(unknownAuction);

  BidCount := 0;

{   Player *pl = GetPlayer();
    std::list<bidentry*>::iterator itr;
    for (itr = pl->GetBidBegin(); itr != pl->GetBidEnd(); itr++)
    begin
        AuctionEntry *ae = objmgr.GetAuction((itr)->AuctionID);
        if ((ae) && (ae->auctioneer = GUID_LOPART(guid)))
        begin
            cnt++;
        end;
    end;   }
    
  Sender.SendBuff.Init(SMSG_AUCTION_BIDDER_LIST_RESULT);
  if BidCount < 51 then
    Sender.SendBuff.Add(BidCount)
  else
    Sender.SendBuff.Add(Integer(50));

{    uint32 cnter = 1;
    for (itr = pl->GetBidBegin(); itr != pl->GetBidEnd(); itr++)
    begin
        AuctionEntry *ae = objmgr.GetAuction((itr)->AuctionID);
        if ((ae->auctioneer = GUID_LOPART(guid)) && (cnter < 51) && (ae))
        begin
            data << ae->Id;
            Item *it = objmgr.GetAItem(ae->item);
            data << it->GetUInt32Value(OBJECT_FIELD_ENTRY);
            data << uint32(1);
            data << uint32(0);
            data << uint32(0);
            data << uint32(1);
            data << uint32(0);
            data << it->GetUInt64Value(ITEM_FIELD_OWNER);
            data << ae->bid;
            data << uint32(0);
            data << ae->buyout;
            data << uint32((ae->time - time(NULL)) * 1000);
            data << uint64(0);
            data << ae->bid;
            cnter++;
        end;
    end;      }
  Sender.SendBuff.Add(BidCount);
  Sender.SendPacket ;
end;

end.
