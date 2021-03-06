@echo off
IF (%DBNAME%)==() GOTO ERROR

type create_%DBNAME%_db.sql > temp_create_%DBNAME%_db.sql
echo BEGIN TRAN >> temp_create_%DBNAME%_db.sql
type eshop_generated_database_schema.sql >> temp_create_%DBNAME%_db.sql

rem Views
powershell -Command "Get-ChildItem . -filter views\*.sql | get-content" >> temp_create_%DBNAME%_db.sql

rem Data
powershell -Command "Get-ChildItem . -filter data\common\*.sql | get-content" >> temp_create_%DBNAME%_db.sql
IF (%SKIPAPPDATA%)==(YES) GOTO SKIPAPPDATA
powershell -Command "Get-ChildItem . -filter data\app\*.sql | get-content" >> temp_create_%DBNAME%_db.sql
:SKIPAPPDATA

echo COMMIT >> temp_create_%DBNAME%_db.sql

sqlcmd -i temp_create_%DBNAME%_db.sql
rem del temp_create_%DBNAME%_db.sql
GOTO END

:ERROR
echo error: DBNAME variable not defined, exiting...
:END
pause