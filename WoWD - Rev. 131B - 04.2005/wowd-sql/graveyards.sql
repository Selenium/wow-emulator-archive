-- phpMyAdmin SQL Dump
-- version 2.6.0-pl3
-- http://www.phpmyadmin.net
-- 
-- Máquina: localhost
-- Data de Criação: 14-Jan-2005 às 00:41
-- Versão do servidor: 3.23.52
-- versão do PHP: 4.3.4
-- 
-- Base de Dados: `wowd`
-- 

-- --------------------------------------------------------

-- 
-- Estrutura da tabela `graveyards`
-- 

DROP TABLE IF EXISTS `graveyards`;
CREATE TABLE IF NOT EXISTS `graveyards` (
  `ID` int(60) NOT NULL auto_increment,
  `X` float default NULL,
  `Y` float default NULL,
  `Z` float default NULL,
  `O` float default NULL,
  `zoneId` int(16) default NULL,
  `mapId` int(16) default NULL,
  `faction_id` int(32) unsigned default NULL,
  PRIMARY KEY  (`ID`)
) TYPE=MyISAM AUTO_INCREMENT=2 ;

-- 
-- Extraindo dados da tabela `graveyards`
-- 

INSERT INTO `graveyards` VALUES (1, 10387, 821.682, 1317.52, 0.486154, 141, 1, NULL);