# Entity Framework Core Database-First approach

Since EF Core does not support DB Designer, it's necessary to scaffold the model from the DB.

Since I didn't have the DB file, i needed to import the DB from a backup file. 

## Import DB from backup
> Source
> 
> https://alteridem.net/2016/03/24/restore-a-sql-server-backup-to-localdb/

To import the DB from a backup, follow the following steps:

1. Take note of the database backup file (_Northwind.bak_)
2. Using the filename, execute the query:
   ```tsql
   RESTORE FILELISTONLY
   FROM DISK = 'path\to\file\Northwind.bak'
   ```
3. From result, get the info from _**LogicalName**_ and _**PhysicalName**_
4. It's important to exist the same path as the one in the _**PhysicalName**_ to be able to restore the DB.
   - If it's not there, create it before running the next query
5. WIth all information in place, run the query:
   ```tsql
   RESTORE DATABASE Northwind                               -- DB name
   FROM DISK = 'path\to\file\Northwind.bak'
   WITH MOVE 'Northwind' TO 'C:\Restart\Data\northwnd.mdf', -- WITH MOVE 'LogicalName' TO 'PhysicalName',
   MOVE 'Northwind_log' TO 'C:\Restart\Data\northwnd.ldf',  -- MOVE 'LogicalName' TO 'PhysicalName',
   REPLACE;
   ``` 

## Scaffold model from existing DB
> Sources
> 
> https://www.entityframeworktutorial.net/efcore/create-model-for-existing-database-in-ef-core.aspx
> https://learn.microsoft.com/en-us/ef/core/managing-schemas/scaffolding/?tabs=dotnet-core-cli

To scaffold the models, change directory to the project's directory and then run:

```shell
dotnet ef dbcontext scaffold "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind" Microsoft.EntityFrameworkCore.SqlServer --context-dir Data --output-dir Models
```
