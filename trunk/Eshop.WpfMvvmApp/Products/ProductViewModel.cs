using CoreMvvm;

namespace Eshop.WpfMvvmApp.Products
{
    public class ProductViewModel : BaseViewModel
    {
        public ProductViewModel(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
    }
}