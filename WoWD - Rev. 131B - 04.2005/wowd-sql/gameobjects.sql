-- phpMyAdmin SQL Dump
-- version 2.6.0-pl3
-- http://www.phpmyadmin.net
-- 
-- Máquina: localhost
-- Data de Criação: 14-Jan-2005 às 00:40
-- Versão do servidor: 3.23.52
-- versão do PHP: 4.3.4
-- 
-- Base de Dados: `wowd`
-- 

-- --------------------------------------------------------

-- 
-- Estrutura da tabela `gameobjects`
-- 

DROP TABLE IF EXISTS `gameobjects`;
CREATE TABLE IF NOT EXISTS `gameobjects` (
  `id` bigint(20) unsigned NOT NULL default '0',
  `positionX` float NOT NULL default '0',
  `positionY` float NOT NULL default '0',
  `positionZ` float NOT NULL default '0',
  `orientation` float NOT NULL default '0',
  `zoneId` int(11) NOT NULL default '38',
  `mapId` int(11) NOT NULL default '0',
  `data` longtext NOT NULL,
  `name_id` bigint(20) NOT NULL default '0',
  `moverandom` int(11) NOT NULL default '1',
  `running` int(11) NOT NULL default '0',
  PRIMARY KEY  (`id`)
) TYPE=MyISAM COMMENT='InnoDB free: 18432 kB';