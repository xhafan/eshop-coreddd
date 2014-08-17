using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace Eshop.Dtos.NhibernateMapping
{
    public class ProductDtoAutoMap : IAutoMappingOverride<ProductSummaryDto>
    {
        public void Override(AutoMapping<ProductSummaryDto> mapping)
        {
            mapping.Id(x => x.Id);
        }
    }
}