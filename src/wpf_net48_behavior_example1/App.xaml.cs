using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace wpf_net48_behavior_example1
{
    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            // Windowの派生クラス(MainWindowとか)にもApp.xamlで定義したStyleを適用
            FrameworkElement.StyleProperty.OverrideMetadata(
                typeof(Window),
                new FrameworkPropertyMetadata(Application.Current.FindResource(typeof(Window)))
            );

            var vm = new MainWindowViewModel();
            var v = new MainWindow { DataContext = vm };
            v.Show();
        }
    }
}
