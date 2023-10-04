--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO


-- =============================================
-- Author:		david8000
-- Create date: 2023-10-04
-- Description:	A test output procedure with test transformation logic
--				The result is writen to a table with corresponding name
--				It shall conform to the import format of the "destination system"
--
--				Note that the source data is a view, defined within LETLF visual studion solution.
--				AW (schema) = "Adventure Works" (the company to be migrated to a new system)
-- =============================================
CREATE OR ALTER PROCEDURE AW.sp_letlf_out_test01
AS
BEGIN
	
	INSERT INTO destsys01.letlf_out_test01

	SELECT 
	concat('X',t.ProductCategoryID) --prod_cat_id
	,UPPER(t.ProductCategoryName) --prod_cat_name
	,t.ParentProductCategoryName
	,t.ProductCategoryName
	,t.ProductCategoryID
	,t._db_id
	,t._trans_time
	,getdate()
	

	
	FROM AW.vGetAllCategories t

END

