CREATE OR ALTER VIEW [dbo].[vCustomer]
AS
  SELECT c.Name, c.Id,
  -- (select COUNT(*) from [dbo].[OrderTable1] o where o.CustomerId = c.Id) AS OrderCount
  FROM  dbo.Customer c
GO