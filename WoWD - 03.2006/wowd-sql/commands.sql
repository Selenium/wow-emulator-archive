SET FOREIGN_KEY_CHECKS=0;
#----------------------------
# Table structure for commands
#----------------------------
CREATE TABLE `commands` (
  `name` varchar(100) NOT NULL default '',
  `security` int(11) NOT NULL default '0',
  `help` longtext NOT NULL
) TYPE=MyISAM;
#----------------------------
# Records for table commands
#----------------------------


insert  into commands values 
('help', 0, 'Syntax: .help <command name>\r\nDisplays help on a command.'), 
('acct', 0, 'Syntax: .acct\r\nDisplays the level of your account'), 
('mount', 0, 'Syntax: .mount <mount number>\r\nMount from the mount number # \r\n(max=3)  lvl10=1 lvl15=2 lvl20=3'), 
('start', 0, 'Syntax: .start\r\nWarp to your start.'), 
('save', 0, 'Syntax: .save\r\nSave your character.'), 
('gps', 0, 'Syntax: .gps\r\nGives your coordinates.'), 
('modify', 1, 'Syntax: .modify # <new value>\r\n#  gold\r\n    mana\r\n    hp\r\n    level\r\n    speed\r\n    scale\r\n    mount'), 
('announce', 1, 'Syntax: .announce <Message to announce>\r\nSends a Global message.'), 
('aura', 3, 'Syntax: .aura <aura number>\r\nTo test aura\'s, can be unstable'), 
('learn', 3, 'Syntax: .learn <spell number>\r\nLearn a spell to your character'), 
('summon', 1, 'Syntax: .summon <character name>\r\nTeleport the user to you'), 
('appear', 1, 'Syntax: .appear <character name>\r\nTeleport you to the user'), 
('kick', 1, 'Syntax: .kick <character name>\r\nForce to disconnect user (you can\'t kick a >gm).'), 
('prog', 2, 'Syntax: .prog\r\nTeleports you to Programer\'s Island.'), 
('guid', 2, 'Syntax: .guid\r\nGet GUID from selected NPC'), 
('spawn', 2, 'Syntax: .spawn <model number> <npc flag> <faction id> <level> <name>\r\nAllows you to spawn a NPC.\r\n<model number> = decimal model number\r\n'), 
('spawntaxi', 2, 'Syntax: .spawntaxi\r\nSpawns a taxi vendor at your current location.'), 
('delete', 2, 'Syntax: .delete\r\nDelete selected NPC.'), 
('name', 2, 'Syntax: .name <new name>\r\nChanges the name of the selected NPC. (Max 75 chars)'), 
('changelevel', 2, 'Syntax: .changelevel <new level>\r\nChange the level of selected NPC (max 99)'), 
('item', 2, 'Syntax: .item \r\nAllows you to assign an item to a vendor!'), 
('spell', 2, 'Syntax: .spell <spell number>\r\nAllows you to asign a spell to a trainer'), 
('itemmove', 2, 'Syntax: .itemmove\r\nUNKNOW'), 
('addmove', 2, 'Syntax: .move\r\nAdd your current location for move.'), 
('random', 2, 'Syntax: .random #\r\nSet random movement! 1=ranom(default), 0=path'), 
('run', 2, 'Syntax: .run #\r\nSet run or walk! 1=run, 0=walk(default)'), 
('addspirit', 3, 'spawns all Spirit Healers'), 
('anim', 3, ''), 
('animfreq', 3, ''), 
('commands', 0, ''), 
('die', 3, 'Kills your character.\r\n'), 
('dismount', 0, 'Dismount you from a mount'), 
('displayid', 2, ''), 
('factionid', 0, ''), 
('gmlist', 0, 'Syntax: .gmlist\r\nLista all online gm\'s'), 
('gmlogin', 0, 'Syntax: .gmlogin <password>'), 
('gmoff', 1, ''), 
('gmon', 1, ''), 
('info', 0, ''), 
('morph', 3, ''), 
('move', 3, ''), 
('npcflag', 2, ''), 
('recall', 1, ''), 
('security', 3, ''), 
('worldport', 3, ''), 
('update', 2, ''), 
('addgrave', 3, 'add graveyard location to database'), 
('addsh', 3, ''), 
('removesh', 3, ''),
('banchar', 3, 'Syntax: .banchar charactername'),
('unbanchar', 3, 'Syntax: .unbanchar charactername');
