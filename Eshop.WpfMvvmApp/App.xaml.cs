using System.Windows;

namespace Eshop.WpfMvvmApp
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            DispatcherUnhandledException += (sender, args) =>
            {
                args.Handled = true;

                MessageBox.Show(args.Exception.ToString(), "Error");
            };

            base.OnStartup(e);

            Bootstrapper.Run();            
        }
    }
}
