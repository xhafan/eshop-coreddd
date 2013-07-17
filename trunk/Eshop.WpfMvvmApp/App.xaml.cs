using System.Windows;

namespace Eshop.WpfMvvmApp
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Bootstrapper.Run();

            Current.DispatcherUnhandledException += (sender, args) =>
                {
                    args.Handled = true;

                    MessageBox.Show(args.Exception.ToString(), "Error");
                };
        }
    }
}
