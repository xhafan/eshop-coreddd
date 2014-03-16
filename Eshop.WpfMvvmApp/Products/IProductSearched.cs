using System.Collections.Generic;
using System.Threading.Tasks;
using Eshop.Dtos;

namespace Eshop.WpfMvvmApp.Products
{
    public interface IProductSearched
    {
        Task ProductSearched(IEnumerable<ProductSummaryDto> products);
    }
}