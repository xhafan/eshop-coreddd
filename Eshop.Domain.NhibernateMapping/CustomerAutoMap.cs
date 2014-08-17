using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace Eshop.Domain.NhibernateMapping
{
    public class CustomerAutoMap : IAutoMappingOverride<Customer>
    {
        public void Override(AutoMapping<Customer> mapping)
        {
            mapping.Map(x => x.DeliveryAddress).Nullable();
        }
    }
}