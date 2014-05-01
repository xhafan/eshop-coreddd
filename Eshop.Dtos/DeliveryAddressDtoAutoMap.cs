using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace Eshop.Dtos
{
    public class DeliveryAddressDtoAutoMap : IAutoMappingOverride<DeliveryAddressDto>
    {
        public void Override(AutoMapping<DeliveryAddressDto> mapping)
        {
            mapping.Id(x => x.CustomerId);
        }
    }
}