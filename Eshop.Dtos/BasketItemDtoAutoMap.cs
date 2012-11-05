using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace Eshop.Dtos
{
    public class BasketItemDtoAutoMap : IAutoMappingOverride<BasketItemDto>
    {
        public void Override(AutoMapping<BasketItemDto> mapping)
        {
            mapping.Id(x => x.Id);
        }
    }
}