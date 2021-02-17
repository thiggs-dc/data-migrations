CREATE OR ALTER VIEW [dbo].[vCustomer]
AS
  SELECT c.Name, c.Id
  -- ,(select COUNT(*) from [dbo].[${orderTable}] o where o.CustomerId = c.Id) AS OrderCount
  FROM  dbo.Customer c
GO