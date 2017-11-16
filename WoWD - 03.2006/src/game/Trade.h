// Copyright (C) 2004 WoW Daemon
//
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA 02111-1307, USA.

#ifndef __TRADE_H
#define __TRADE_H

enum TRADE_STATUS
{
    TRADE_STATUS_PLAYER_BUSY       = 0x00,
    TRADE_STATUS_PROPOSED          = 0x01,
    TRADE_STATUS_INITIATED         = 0x02,
    TRADE_STATUS_CANCELLED         = 0x03,
    TRADE_STATUS_ACCEPTED          = 0x04,
    TRADE_STATUS_ALREADY_TRADING   = 0x05,
    TRADE_STATUS_PLAYER_NOT_FOUND  = 0x06,
    TRADE_STATUS_STATE_CHANGED     = 0x07,
    TRADE_STATUS_COMPLETE          = 0x08,
    TRADE_STATUS_UNACCEPTED        = 0x09,
    TRADE_STATUS_TOO_FAR_AWAY      = 0x0A,
    TRADE_STATUS_WRONG_FACTION     = 0x0B,
    TRADE_STATUS_FAILED            = 0x0C,
    TRADE_STATUS_DEAD              = 0x0D,
    TRADE_STATUS_PETITION          = 0x0E,
    TRADE_STATUS_PLAYER_IGNORED    = 0x0F,
};

enum TRADE_DATA
{
    TRADE_GIVE        = 0x00,
    TRADE_RECEIVE     = 0x01,
};

struct TradeItem
{
	uint8 TradeSlot;
    uint8 SourceSlot;
	uint8 SourceBag;

};

class TradeHandler : public Singleton<TradeHandler>
{
public:
	TradeHandler();
	~TradeHandler();

	void UpdateTrade(Player *player);
	bool SwapItems(Player *from, Player *to, uint8 tradeslot);

protected:

};

#define sTradeHandler TradeHandler::getSingleton()

#endif
