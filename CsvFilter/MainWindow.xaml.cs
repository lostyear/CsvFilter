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


      string sourceFilePath = null;

      //sourceFilePath = getSourceFilePath();
      sourceFilePath = @"Z:\Internet_Shared\SharedDoc\gwy\公务员职位csv.csv";

      if (sourceFilePath == null)
      {
        Application.Current.Shutdown();
      }
      else
      {
        ff = new FileFilter(sourceFilePath);
        this.Show();
      }
    }

    private void btnApply_Click(object sender, RoutedEventArgs e)
    {
      string[][] aa = new string[][] {
        new string[] {"1","2","3"},
        new string[] {"4","5","6"},
        new string[] {"7","8","9"}
      };
      bindingArry(aa);
    }

    private string getSourceFilePath()
    {
      FileOpener fo = new FileOpener();
      fo.ShowDialog();
      if (fo.DialogResult == true)
      {
        return fo.FilePath;
      }
      else
      {
        return null;
      }

    }

    private void bindingArry(string[][] source)
    {
      Brush blackBrush = new SolidColorBrush(Colors.Black);
      Brush grayBrush = new SolidColorBrush(Colors.LightBlue);
      Thickness borderThickness = new Thickness(1);

      foreach (string[] line in source)
      {
        ListViewItem lvi = new ListViewItem();
        StackPanel sp = new StackPanel();
        sp.Orientation = Orientation.Horizontal;
        

        foreach (string item in line)
        {
          Label itemLabel = new Label();
          itemLabel.Background = grayBrush;
          itemLabel.BorderBrush = blackBrush;
          itemLabel.BorderThickness = borderThickness;
          itemLabel.Content = item;
          sp.Children.Add(itemLabel);
        }
        lvi.Content = sp;
        lvTable.Items.Add(lvi);
      }
    }


  }
}
