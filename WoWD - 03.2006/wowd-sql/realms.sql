SET FOREIGN_KEY_CHECKS=0;
#----------------------------
# Table structure for realms
#----------------------------
CREATE TABLE `realms` (
  `id` bigint(20) NOT NULL auto_increment,
  `name` varchar(32) NOT NULL default '',
  `address` varchar(32) NOT NULL default '',
  `icon` int(10) default '0',
  `color` int(10) default '0',
  `timezone` int(10) default '0',
  PRIMARY KEY  (`id`),
  UNIQUE KEY `id` (`id`)
) TYPE=MyISAM COMMENT='InnoDB free: 11264 kB; InnoDB free: 18432 kB';
#----------------------------
# Records for table realms
#----------------------------


insert  into realms values 
(1, 'WoWD', '127.0.0.1:8129', 1, 0, 0);

