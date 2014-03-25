using CoreMvvm;
using Eshop.Dtos;

namespace Eshop.WpfMvvmApp.Products
{
    public class BasketItemViewModel : BaseViewModel
    {
        private readonly int _productId;
        private readonly string _productName;
        private readonly int _quantity;

        public BasketItemViewModel(BasketItemDto dto)
        {
            _productId = dto.ProductId;
            _productName = dto.ProductName;
            _quantity = dto.Count;
        }

        public int ProductId { get { return _productId; } }
        public string ProductName { get { return _productName; } }
        public int Quantity { get { return _quantity; } }
    }
}