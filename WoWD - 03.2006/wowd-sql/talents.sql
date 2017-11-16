SET FOREIGN_KEY_CHECKS=0;
#----------------------------
# Table structure for talents
#----------------------------
CREATE TABLE `talents` (
  `id` int(10) NOT NULL auto_increment,
  `t_id` int(10) NOT NULL default '0',
  `maxrank` int(7) NOT NULL default '0',
  `class` int(10) NOT NULL default '0',
  `rank1` longtext NOT NULL,
  `rank2` longtext NOT NULL,
  `rank3` longtext NOT NULL,
  `rank4` longtext NOT NULL,
  `rank5` longtext NOT NULL,
  PRIMARY KEY  (`id`)
) TYPE=MyISAM;
#----------------------------
# No records for table talents
#----------------------------


