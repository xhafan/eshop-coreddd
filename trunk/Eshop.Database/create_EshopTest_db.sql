use master;

DECLARE @dbname nvarchar(128)
SET @dbname = N'EshopTest'

IF (NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE ('[' + name + ']' = @dbname OR name = @dbname)))
begin
    create database EshopTest
end

go
use EshopTest;
go    
