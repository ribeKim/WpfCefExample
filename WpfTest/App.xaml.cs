using System.Windows;
using CefSharp;
using CefSharp.Handler;
using CefSharp.Wpf;
using WpfTest.Handlers;

namespace WpfTest
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var settings = new CefSettings();

            settings.RegisterScheme(new CefCustomScheme
            {
                SchemeName = DiskSchemeHandlerFactory.SchemeName,
                SchemeHandlerFactory = new DiskSchemeHandlerFactory()
            });

            Cef.Initialize(settings);
            base.OnStartup(e);
        }
    }
}