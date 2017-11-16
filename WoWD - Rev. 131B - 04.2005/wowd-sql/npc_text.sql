-- phpMyAdmin SQL Dump
-- version 2.6.0-pl3
-- http://www.phpmyadmin.net
-- 
-- Máquina: localhost
-- Data de Criação: 14-Jan-2005 às 00:44
-- Versão do servidor: 3.23.52
-- versão do PHP: 4.3.4
-- 
-- Base de Dados: `wowd`
-- 

-- --------------------------------------------------------

-- 
-- Estrutura da tabela `npc_text`
-- 

DROP TABLE IF EXISTS `npc_text`;
CREATE TABLE IF NOT EXISTS `npc_text` (
  `ID` int(11) NOT NULL default '0',
  `TYPE_UNUSED` int(11) NOT NULL default '0',
  `TEXT` longtext NOT NULL,
  PRIMARY KEY  (`ID`)
) TYPE=MyISAM;

-- 
-- Extraindo dados da tabela `npc_text`
-- 

INSERT INTO `npc_text` VALUES (1, 0, 'It is not yet your time. I shall aid your journey back to the realm of the living...\r\nFor a price.');