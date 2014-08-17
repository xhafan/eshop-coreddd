using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace Eshop.Domain
{
    public class CustomerAutoMap : IAutoMappingOverride<Customer> // todo : move to separate project to separate domain and persistence
    {
        public void Override(AutoMapping<Customer> mapping)
        {
            mapping.Map(x => x.DeliveryAddress).Nullable();
        }
    }
}