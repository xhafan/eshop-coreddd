using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace Eshop.Dtos.NhibernateMapping
{
    public class DeliveryAddressDtoAutoMap : IAutoMappingOverride<DeliveryAddressDto>
    {
        public void Override(AutoMapping<DeliveryAddressDto> mapping)
        {
            mapping.Id(x => x.CustomerId);
        }
    }
}