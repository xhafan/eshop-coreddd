using System.Collections.Generic;
using Eshop.Dtos;

namespace Eshop.WpfMvvmApp.Products
{
    public interface IProductSearched
    {
        void ProductSearched(IEnumerable<ProductSummaryDto> products);
    }
}