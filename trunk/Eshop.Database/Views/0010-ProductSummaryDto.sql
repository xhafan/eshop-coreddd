IF OBJECT_ID('ProductSummaryDto') IS NOT NULL 
DROP VIEW ProductSummaryDto
GO

CREATE VIEW ProductSummaryDto
AS
select
    Id
    , Name
from Product

go