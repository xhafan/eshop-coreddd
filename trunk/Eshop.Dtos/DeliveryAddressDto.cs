using CoreDdd.Nhibernate;

namespace Eshop.Dtos
{
    public class DeliveryAddressDto : IAutoMappedDto
    {
        public int CustomerId { get; set; }
        public string DeliveryAddress { get; set; }
    }
}