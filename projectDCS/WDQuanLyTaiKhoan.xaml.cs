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
using System.Windows.Shapes;

namespace projectDCS
{
    /// <summary>
    /// Interaction logic for WDQuanLyTaiKhoan.xaml
    /// </summary>
    public partial class WDQuanLyTaiKhoan : Window
    {
        public WDQuanLyTaiKhoan()
        {
            InitializeComponent();
        }

        private void ListViewMenuQuanLyTaiKhoa_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UserControl usc = null;
            GridQuanLyTaiKhoan.Children.Clear();
            this.WindowState = WindowState.Normal;

            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "ThemUser":
                    usc = new ThemUserMoi();
                    GridQuanLyTaiKhoan.Children.Add(usc);
                    break;
                case "SuaThongTinUser":
                    usc = new SuaUser();
                    GridQuanLyTaiKhoan.Children.Add(usc);
                    break;
                case "dong":
                    this.Close();
                    break;
                default:
                    usc = new ThemUserMoi();
                    GridQuanLyTaiKhoan.Children.Add(usc);
                    break;
            }
        }
    }
}
