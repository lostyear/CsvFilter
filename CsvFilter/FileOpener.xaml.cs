using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CsvFilter
{
  /// <summary>
  /// FileOpener.xaml 的交互逻辑
  /// </summary>
  public partial class FileOpener : Window
  {
    public string FilePath { get; private set; }

    public FileOpener()
    {
      InitializeComponent();
    }

    private void btnOkey_Click(object sender, RoutedEventArgs e)
    {
      if (File.Exists(tbFilePath.Text))
      {
        FilePath = tbFilePath.Text;
        this.DialogResult = true;
        this.Close();
      }
      else
      {
        MessageBox.Show("File Not Exist!!");
      }
    }

    private void btnCancel_Click(object sender, RoutedEventArgs e)
    {
      this.DialogResult = false;
      this.Close();
    }

    private void btnOpen_Click(object sender, RoutedEventArgs e)
    {
      Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
      ofd.CheckFileExists = true;
      ofd.Filter = "csv file (#.csv)|*.csv";
      if (ofd.ShowDialog() == true)
      {
        tbFilePath.Text = ofd.FileName;
      }
    }


  }
}
