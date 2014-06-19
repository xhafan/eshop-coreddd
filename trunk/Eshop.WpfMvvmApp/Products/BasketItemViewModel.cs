using CoreMvvm;
using Eshop.Dtos;

namespace Eshop.WpfMvvmApp.Products
{
    public class BasketItemViewModel : BaseViewModel
    {
        private readonly int _productId;
        private readonly string _productName;
        private readonly decimal _productPrice;

        public BasketItemViewModel(BasketItemDto dto)
        {
            _productId = dto.ProductId;
            _productName = dto.ProductName;
            _productPrice = dto.ProductPrice;
            Quantity = dto.Quantity;
            UpdatedQuantity = dto.Quantity;
        }

        public int ProductId { get { return _productId; } }
        public string ProductName { get { return _productName; } }
        public decimal ProductPrice { get { return _productPrice; } }
        public int Quantity { get; private set; }
        public int UpdatedQuantity { get; set; }
        public bool CanUpdateQuantity { get { return Quantity != UpdatedQuantity; } }
        public string UpdateAction { get { return UpdatedQuantity == 0 ? "Remove" : "Update"; } } // todo : is this tested in chicago tests?

        public void UpdateQuantity()
        {
            Quantity = UpdatedQuantity;
        }
    }
}