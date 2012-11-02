using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace Eshop.Dtos
{
    public class ProductDtoAutoMap : IAutoMappingOverride<ProductDto>
    {
        public void Override(AutoMapping<ProductDto> mapping)
        {
            mapping.Id(x => x.Id);
        }
    }
}