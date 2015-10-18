using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CsvFilter
{
  /// <summary>
  /// MainWindow.xaml 的交互逻辑
  /// </summary>
  public partial class MainWindow : Window
  {
    FileFilter ff = null;
    public MainWindow()
    {
      InitializeComponent();
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
      this.Hide();
      FileOpener fo = new FileOpener();
      fo.ShowDialog();
      if (fo.DialogResult == true)
      {
        this.Show();
        ff = new FileFilter(fo.FilePath);
      }
      else
      {
        Application.Current.Shutdown();
      }
    }


  }
}
