using System.Collections.Generic;
using Eshop.Dtos;

namespace Eshop.WpfMvvmApp.Products
{
    public class ProductSearchedEvent
    {
        public IEnumerable<ProductSummaryDto> Products { get; set; }
    }
}