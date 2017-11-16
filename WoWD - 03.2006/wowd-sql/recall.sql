SET FOREIGN_KEY_CHECKS=0;
#----------------------------
# Table structure for recall
#----------------------------
CREATE TABLE `recall` (
  `guid` bigint(20) unsigned NOT NULL auto_increment,
  `locname` varchar(10) NOT NULL,
  `locnsize` tinyint(4) unsigned NOT NULL,
  `mapid` mediumint(8) NOT NULL default '0',
  `positionX` float NOT NULL,
  `positionY` float NOT NULL,
  `positionZ` float NOT NULL,
  PRIMARY KEY  (`guid`)
) TYPE=MyISAM;
#----------------------------
# Records for table recall
#----------------------------


insert  into recall values 
(1, 'sunr', 5, 1, '-180.949', '-296.467', '11.5384'), 
(2, 'out', 4, 0, '-14988.9', '12726.1', '47.92'), 
(3, 'thun', 5, 1, '-1196.22', '29.0941', '176.949'), 
(4, 'darn', 5, 1, '9951.52', '2280.32', '1341.39'), 
(5, 'cross', 6, 1, '-443.128', '-2598.87', '96.2114'), 
(6, 'ogri', 5, 1, '1676.21', '-4315.29', '61.5293'), 
(7, 'neth', 5, 0, '-10996.9', '-3427.67', '61.996'), 
(8, 'thel', 5, 0, '-5395.57', '-3015.79', '327.58'), 
(9, 'storm', 6, 0, '-8913.23', '554.633', '93.7944'), 
(10, 'iron', 5, 0, '-4981.25', '-881.542', '501.66'), 
(11, 'oldiron', 5, 0, '-4843.94', '-1064.63', '502.04'), 
(12, 'under', 6, 0, '1586.48', '239.562', '-52.149'), 
(13, 'gmisl', 6, 1, '16222.1', '16252.1', '12.5872'), 
(14, 'desi', 6, 451, '16303.5', '-16173.5', '40.4365'), 
(15, 'prog', 6, 451, '16391.8', '16341.2', '69.44'), 
(16, 'darr', 5, 1, '10037.6', '2496.8', '1318.4');

