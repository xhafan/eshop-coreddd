IF OBJECT_ID('ProductDto') IS NOT NULL 
DROP VIEW ProductDto
GO

CREATE VIEW ProductDto
AS
select
    Id
    , Name
    , [Description]
    , Price
from Product

go