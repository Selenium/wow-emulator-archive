/*
MySQL Backup
Source Host:           localhost
Source Server Version: 5.0.21-community
Source Database:       awowedb
Date:                  2006.09.02 20:38:38
*/

SET FOREIGN_KEY_CHECKS=0;
use awowedb;
#----------------------------
# Table structure for adb_auctionhouse
#----------------------------
CREATE TABLE `adb_auctionhouse` (
  `auction_id` int(11) NOT NULL auto_increment,
  `auction_bid` int(11) NOT NULL,
  `auction_buyout` int(11) NOT NULL,
  `auction_timeleft` int(11) NOT NULL,
  `auction_bidder` int(11) NOT NULL default '0',
  `auction_owner` int(11) NOT NULL,
  `auction_itemId` mediumint(11) NOT NULL,
  `auction_itemCount` tinyint(4) unsigned NOT NULL default '1',
  `auction_itemGUID` int(11) NOT NULL,
  PRIMARY KEY  (`auction_id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;