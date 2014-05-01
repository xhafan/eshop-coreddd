IF OBJECT_ID('DeliveryAddressDto') IS NOT NULL 
DROP VIEW DeliveryAddressDto
GO

CREATE VIEW DeliveryAddressDto
AS
select
    Id                  as CustomerId
    , DeliveryAddress
from Customer

go