use master;

DECLARE @dbname nvarchar(128)
SET @dbname = N'Eshop'

IF (NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE ('[' + name + ']' = @dbname OR name = @dbname)))
begin
    create database Eshop
end

go
use Eshop;
go    
