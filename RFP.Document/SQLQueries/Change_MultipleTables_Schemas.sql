use [DoctorFAMDb]

DECLARE @OldSchemaName NVARCHAR(128) = 'DoctorFAMDb';
DECLARE @NewSchemaName NVARCHAR(128) = 'dbo';
DECLARE @TableName NVARCHAR(128);

DECLARE table_cursor CURSOR FOR
SELECT TABLE_NAME 
FROM INFORMATION_SCHEMA.TABLES 
WHERE TABLE_SCHEMA = @OldSchemaName;

OPEN table_cursor;
FETCH NEXT FROM table_cursor INTO @TableName;

WHILE @@FETCH_STATUS = 0
BEGIN
    DECLARE @sql NVARCHAR(MAX);
    SET @sql = 'ALTER SCHEMA ' + QUOTENAME(@NewSchemaName) + 
               ' TRANSFER ' + QUOTENAME(@OldSchemaName) + '.' + QUOTENAME(@TableName);
    EXEC sp_executesql @sql;

    FETCH NEXT FROM table_cursor INTO @TableName;
END

CLOSE table_cursor;
DEALLOCATE table_cursor;