using CoreDto;

namespace Eshop.Dtos
{
    public class DeliveryAddressDto : IDto
    {
        public int CustomerId { get; set; }
        public string DeliveryAddress { get; set; }
    }
}