using CoreDdd.Nhibernate.Configurations;

namespace Eshop.Dtos
{
    [IgnoreAutoMap]
    public class ReviewOrderDto
    {
        public BasketItemDto[] BasketItems { get; set; }
        public DeliveryAddressDto DeliveryAddress { get; set; }
    }
}