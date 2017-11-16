-- phpMyAdmin SQL Dump
-- version 2.6.0-pl3
-- http://www.phpmyadmin.net
-- 
-- Máquina: localhost
-- Data de Criação: 14-Jan-2005 às 00:43
-- Versão do servidor: 3.23.52
-- versão do PHP: 4.3.4
-- 
-- Base de Dados: `wowd`
-- 

-- --------------------------------------------------------

-- 
-- Estrutura da tabela `npc_options`
-- 

DROP TABLE IF EXISTS `npc_options`;
CREATE TABLE IF NOT EXISTS `npc_options` (
  `ID` int(11) NOT NULL default '0',
  `GOSSIP_ID` int(11) NOT NULL default '0',
  `TYPE` int(5) default NULL,
  `OPTION` text NOT NULL,
  `NPC_TEXT_NEXTID` int(11) default '0',
  `SPECIAL` int(11) default NULL,
  PRIMARY KEY  (`ID`)
) TYPE=MyISAM;

-- 
-- Extraindo dados da tabela `npc_options`
-- 

INSERT INTO `npc_options` VALUES (0, 1, 0, 'Return me to life.', 0, 2);