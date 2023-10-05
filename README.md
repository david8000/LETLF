LETLF - Lightweight ETL Framework
This is a starting point when designing an ETL aka data migration project.
The normal use case is to download the code and have it source controlled in your organization.

Design goals:
-It shall be a Visual Studio application - easy to program and source control.
-It shall be possible to do the bulk of the work (ie transformation logic) in pure SQL language.
-Said SQL scripts shall be source controlled in this application.
-The database of choice is MS SQL Server (database backup file included)
-The means to get the "source data" into the ETL database is omitted.
 There are known methods to get any data extractid into a database through visual studio.
 Ie: SQL Server Integraton Services (SSIS). That is a plugin to Visual Studio.
-There is a fixed folder structure within the VS project where SQL files are placed.






