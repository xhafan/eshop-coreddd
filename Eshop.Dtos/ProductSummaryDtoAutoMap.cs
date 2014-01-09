using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace Eshop.Dtos
{
    public class ProductSummaryDtoAutoMap : IAutoMappingOverride<ProductSummaryDto>
    {
        public void Override(AutoMapping<ProductSummaryDto> mapping)
        {
            mapping.Id(x => x.Id);
        }
    }
}