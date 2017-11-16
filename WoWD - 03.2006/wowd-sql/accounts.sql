SET FOREIGN_KEY_CHECKS=0;
#----------------------------
# Table structure for accounts
#----------------------------
CREATE TABLE `accounts` (
  `acct` bigint(20) NOT NULL auto_increment,
  `login` varchar(255) NOT NULL default '',
  `password` varchar(28) NOT NULL default '',
  `s` longtext NOT NULL,
  `v` longtext NOT NULL,
  `gm` tinyint(1) NOT NULL default '0',
  `sessionkey` longtext NOT NULL,
  `email` varchar(50) NOT NULL default '',
  `joindate` timestamp(14) NOT NULL,
  `banned` tinyint(1) NOT NULL default '0',
  PRIMARY KEY  (`acct`),
  UNIQUE KEY `acct` (`acct`)
) TYPE=MyISAM COMMENT='InnoDB free: 11264 kB; InnoDB free: 18432 kB';
#----------------------------
# Records for table accounts
#----------------------------


insert  into accounts values 
(1, 'WOWD', 'WOWD', '', '', 4, '40DD52ACED674EE6155B750D21ABE2FA9DD6D3D257702C40E470D279A21D04E7D1FE75498A644B95', '', '20050727071223', 0);

