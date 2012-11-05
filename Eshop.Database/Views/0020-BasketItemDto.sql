IF OBJECT_ID('BasketItemDto') IS NOT NULL 
DROP VIEW BasketItemDto
GO

CREATE VIEW BasketItemDto
AS
select
    bi.Id
    , bi.CustomerId
    , bi.ProductId
    , p.Name            as ProductName
    , bi.[Count]
from BasketItem bi
join Product p ON p.Id = bi.ProductId

go