using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace Eshop.Dtos
{
    public class BasketItemDtoAutoMap : IAutoMappingOverride<BasketItemDto> // todo: move this to separate assembly
    {
        public void Override(AutoMapping<BasketItemDto> mapping)
        {
            mapping.Id(x => x.Id);
        }
    }
}