LETLF - Lightweight ETL Framework

This is a starting point when designing an ETL aka data migration application.

Design goals:

-It shall be a Visual Studio application - easy to program and source control.

-It shall be possible to do the bulk of the work (ie transformation logic) in pure SQL language.

-It shall also be possible to leverage the magnificent power of C#/.NET.

-Said SQL scripts shall be source controlled in this application.

-The database of choice is MS SQL Server (database backup file included)

-There is a fixed folder structure within the VS project where SQL files are placed.

-The means to get the "source data" into the ETL database is omitted.
 Ie SQL Server Integraton Services (SSIS) can be used for this in (VS plugin)



Instructions:

Have SQL Server installed. Ie SQLEXPRESS.

Restore the included database "ETL". It contains sample source system data.

Load the solution in Visual Studio.

Download any needed NuGet packages (like "SMO"). See "Dependencies" on the Project.

Edit the paramteres in the programs C# file to connect to your SQL instance.

F5 and have fun.

The provided examples should run fine right away..






