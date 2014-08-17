namespace Eshop.Dtos
{
    public class ReviewOrderDto
    {
        public BasketItemDto[] BasketItems { get; set; }
        public DeliveryAddressDto DeliveryAddress { get; set; }
    }
}