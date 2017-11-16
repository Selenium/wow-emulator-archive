SET FOREIGN_KEY_CHECKS=0;
#----------------------------
# Table structure for auctionhouse
#----------------------------
CREATE TABLE `auctionhouse` (
  `auctioneerguid` int(32) NOT NULL default '0',
  `itemguid` int(32) NOT NULL default '0',
  `itemowner` int(32) NOT NULL default '0',
  `buyoutprice` int(32) NOT NULL default '0',
  `time` bigint(40) NOT NULL default '0',
  `buyguid` int(32) NOT NULL default '0',
  `lastbid` int(32) NOT NULL default '0',
  `Id` int(32) NOT NULL default '0'
) TYPE=MyISAM;
#----------------------------
# No records for table auctionhouse
#----------------------------


