
-- A pointless view, just to complicate :)

CREATE OR ALTER VIEW [AW].[vGetAllCategories]
WITH SCHEMABINDING 
AS 


WITH CategoryCTE([ParentProductCategoryID], [ProductCategoryID], [Name], [_db_id], [_trans_time]) AS 
(
	SELECT [ParentProductCategoryID], [ProductCategoryID], [Name], [_db_id], [_trans_time]
	FROM SourceDataAdventureWorks.ProductCategory
	WHERE ParentProductCategoryID IS NULL

UNION ALL

	SELECT C.[ParentProductCategoryID], C.[ProductCategoryID], C.[Name], C.[_db_id], C.[_trans_time]
	FROM SourceDataAdventureWorks.ProductCategory AS C
	INNER JOIN CategoryCTE AS BC ON BC.ProductCategoryID = C.ParentProductCategoryID
)

SELECT PC.[Name] AS [ParentProductCategoryName], CCTE.[Name] as [ProductCategoryName], CCTE.[ProductCategoryID], CCTE._db_id, CCTE._trans_time
FROM CategoryCTE AS CCTE
JOIN SourceDataAdventureWorks.ProductCategory AS PC 
ON PC.[ProductCategoryID] = CCTE.[ParentProductCategoryID]


