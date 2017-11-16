SET FOREIGN_KEY_CHECKS=0;
#----------------------------
# Table structure for char_spells
#----------------------------
CREATE TABLE `char_spells` (
  `id` bigint(20) unsigned zerofill NOT NULL auto_increment,
  `charId` bigint(20) unsigned NOT NULL default '0',
  `spellId` int(20) unsigned NOT NULL default '0',
  `slotId` int(11) unsigned default NULL,
  PRIMARY KEY  (`id`)
) TYPE=MyISAM;
#----------------------------
# No records for table char_spells
#----------------------------


