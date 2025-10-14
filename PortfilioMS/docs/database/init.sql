-- Create database if it doesn't exist
IF NOT EXISTS(SELECT name FROM master.dbo.sysdatabases WHERE name = 'PortfolioDB')
CREATE DATABASE PortfolioDB;
GO

USE PortfolioDB;
GO

-- Create custom schema
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = 'portfolio')
EXEC('CREATE SCHEMA portfolio');
GO