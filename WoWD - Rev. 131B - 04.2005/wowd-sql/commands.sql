-- phpMyAdmin SQL Dump
-- version 2.6.0-pl3
-- http://www.phpmyadmin.net
-- 
-- Máquina: localhost
-- Data de Criação: 14-Jan-2005 às 00:54
-- Versão do servidor: 3.23.52
-- versão do PHP: 4.3.4
-- 
-- Base de Dados: `wowd`
-- 

-- --------------------------------------------------------

-- 
-- Estrutura da tabela `commands`
-- 

DROP TABLE IF EXISTS `commands`;
CREATE TABLE IF NOT EXISTS `commands` (
  `name` varchar(100) NOT NULL default '',
  `security` int(11) NOT NULL default '0',
  `help` longtext NOT NULL
) TYPE=MyISAM;

-- 
-- Extraindo dados da tabela `commands`
-- 

INSERT INTO `commands` (`name`, `security`, `help`) VALUES ('help', 0, 'Syntax: .help <command name>\r\nDisplays help on a command.');
INSERT INTO `commands` (`name`, `security`, `help`) VALUES ('acct', 0, 'Syntax: .acct\r\nDisplays the level of your account');
INSERT INTO `commands` (`name`, `security`, `help`) VALUES ('mount', 0, 'Syntax: .mount <mount number>\r\nMount from the mount number # \r\n(max=3)  lvl10=1 lvl15=2 lvl20=3');
INSERT INTO `commands` (`name`, `security`, `help`) VALUES ('start', 0, 'Syntax: .start\r\nWarp to your start.');
INSERT INTO `commands` (`name`, `security`, `help`) VALUES ('save', 0, 'Syntax: .save\r\nSave your character.');
INSERT INTO `commands` (`name`, `security`, `help`) VALUES ('gps', 0, 'Syntax: .gps\r\nGives your coordinates.');
INSERT INTO `commands` (`name`, `security`, `help`) VALUES ('modify', 1, 'Syntax: .modify # <new value>\r\n#  gold\r\n    mana\r\n    hp\r\n    level\r\n    speed\r\n    scale\r\n    mount');
INSERT INTO `commands` (`name`, `security`, `help`) VALUES ('announce', 1, 'Syntax: .announce <Message to announce>\r\nSends a Global message.');
INSERT INTO `commands` (`name`, `security`, `help`) VALUES ('aura', 3, 'Syntax: .aura <aura number>\r\nTo test aura''s, can be unstable');
INSERT INTO `commands` (`name`, `security`, `help`) VALUES ('learn', 3, 'Syntax: .learn <spell number>\r\nLearn a spell to your character');
INSERT INTO `commands` (`name`, `security`, `help`) VALUES ('summon', 1, 'Syntax: .summon <character name>\r\nTeleport the user to you');
INSERT INTO `commands` (`name`, `security`, `help`) VALUES ('appear', 1, 'Syntax: .appear <character name>\r\nTeleport you to the user');
INSERT INTO `commands` (`name`, `security`, `help`) VALUES ('kick', 1, 'Syntax: .kick <character name>\r\nForce to disconnect user (you can''t kick a >gm).');
INSERT INTO `commands` (`name`, `security`, `help`) VALUES ('prog', 2, 'Syntax: .prog\r\nTeleports you to Programer''s Island.');
INSERT INTO `commands` (`name`, `security`, `help`) VALUES ('guid', 2, 'Syntax: .guid\r\nGet GUID from selected NPC');
INSERT INTO `commands` (`name`, `security`, `help`) VALUES ('spawn', 2, 'Syntax: .spawn <model number> <npc flag> <faction id> <level> <name>\r\nAllows you to spawn a NPC.\r\n<model number> = decimal model number\r\n');
INSERT INTO `commands` (`name`, `security`, `help`) VALUES ('spawntaxi', 2, 'Syntax: .spawntaxi\r\nSpawns a taxi vendor at your current location.');
INSERT INTO `commands` (`name`, `security`, `help`) VALUES ('delete', 2, 'Syntax: .delete\r\nDelete selected NPC.');
INSERT INTO `commands` (`name`, `security`, `help`) VALUES ('name', 2, 'Syntax: .name <new name>\r\nChanges the name of the selected NPC. (Max 75 chars)');
INSERT INTO `commands` (`name`, `security`, `help`) VALUES ('changelevel', 2, 'Syntax: .changelevel <new level>\r\nChange the level of selected NPC (max 99)');
INSERT INTO `commands` (`name`, `security`, `help`) VALUES ('item', 2, 'Syntax: .item \r\nAllows you to assign an item to a vendor!');
INSERT INTO `commands` (`name`, `security`, `help`) VALUES ('spell', 2, 'Syntax: .spell <spell number>\r\nAllows you to asign a spell to a trainer');
INSERT INTO `commands` (`name`, `security`, `help`) VALUES ('itemmove', 2, 'Syntax: .itemmove\r\nUNKNOW');
INSERT INTO `commands` (`name`, `security`, `help`) VALUES ('addmove', 2, 'Syntax: .move\r\nAdd your current location for move.');
INSERT INTO `commands` (`name`, `security`, `help`) VALUES ('random', 2, 'Syntax: .random #\r\nSet random movement! 1=ranom(default), 0=path');
INSERT INTO `commands` (`name`, `security`, `help`) VALUES ('run', 2, 'Syntax: .run #\r\nSet run or walk! 1=run, 0=walk(default)');
INSERT INTO `commands` (`name`, `security`, `help`) VALUES ('addspirit', 3, 'spawns all Spirit Healers');
INSERT INTO `commands` (`name`, `security`, `help`) VALUES ('anim', 3, '');
INSERT INTO `commands` (`name`, `security`, `help`) VALUES ('animfreq', 3, '');
INSERT INTO `commands` (`name`, `security`, `help`) VALUES ('commands', 0, '');
INSERT INTO `commands` (`name`, `security`, `help`) VALUES ('die', 3, 'Kills your character.\r\n');
INSERT INTO `commands` (`name`, `security`, `help`) VALUES ('dismount', 0, 'Dismount you from a mount');
INSERT INTO `commands` (`name`, `security`, `help`) VALUES ('displayid', 2, '');
INSERT INTO `commands` (`name`, `security`, `help`) VALUES ('factionid', 0, '');
INSERT INTO `commands` (`name`, `security`, `help`) VALUES ('gmlist', 0, 'Syntax: .gmlist\r\nLista all online gm''s');
INSERT INTO `commands` (`name`, `security`, `help`) VALUES ('gmlogin', 0, 'Syntax: .gmlogin <password>');
INSERT INTO `commands` (`name`, `security`, `help`) VALUES ('gmoff', 1, '');
INSERT INTO `commands` (`name`, `security`, `help`) VALUES ('gmon', 1, '');
INSERT INTO `commands` (`name`, `security`, `help`) VALUES ('info', 0, '');
INSERT INTO `commands` (`name`, `security`, `help`) VALUES ('morph', 3, '');
INSERT INTO `commands` (`name`, `security`, `help`) VALUES ('move', 3, '');
INSERT INTO `commands` (`name`, `security`, `help`) VALUES ('npcflag', 2, '');
INSERT INTO `commands` (`name`, `security`, `help`) VALUES ('recall', 1, '');
INSERT INTO `commands` (`name`, `security`, `help`) VALUES ('security', 3, '');
INSERT INTO `commands` (`name`, `security`, `help`) VALUES ('worldport', 3, '');
INSERT INTO `commands` (`name`, `security`, `help`) VALUES ('update', 2, '');
INSERT INTO `commands` (`name`, `security`, `help`) VALUES ('addgrave', 3, 'add graveyard location to database');
INSERT INTO `commands` (`name`, `security`, `help`) VALUES ('addsh', 3, '');
INSERT INTO `commands` (`name`, `security`, `help`) VALUES ('removesh', 3, '');