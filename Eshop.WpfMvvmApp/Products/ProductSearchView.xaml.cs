using System.Windows.Controls;

namespace Eshop.WpfMvvmApp.Products
{
    public partial class ProductSearchView : UserControl
    {
        public ProductSearchView()
        {
            InitializeComponent();
            Loaded += OnLoaded;
        }

        void OnLoaded(object sender, System.Windows.RoutedEventArgs e)
        {
            SearchText.Focus();
        }
    }
}
