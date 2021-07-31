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

namespace projectDCS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        WDLogin wdLogin = new WDLogin();
        public MainWindow()
        { 
            InitializeComponent();
            wdLogin.ShowDialog();
            UserControl usc_khoitao = new UCBangQuanTrac();
            GridMain.Children.Add(usc_khoitao);
        }
        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UserControl usc = null;
            GridMain.Children.Clear();
            this.WindowState = WindowState.Normal;

            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "ThongTinTaiKhoan":
                    if (WDLogin.NhomTaiKhoan == "Administrator")
                    {
                        usc = new ThongTinTaiKhoanAdmin();
                        GridMain.Children.Add(usc);
                        break;
                    }
                    else if (WDLogin.NhomTaiKhoan == "Moderator")
                    {
                        usc = new ThongTinTaiKhoanAdmin();
                        GridMain.Children.Add(usc);
                        break;
                    }
                    else
                    {
                        usc = new UCThongTinTaiKhoan();
                        GridMain.Children.Add(usc);
                        break;
                    }
                case "BangQuanTrac":
                    usc = new UCBangQuanTrac();
                    GridMain.Children.Add(usc);
                    break;
                case "TraCuuKetQua":
                    usc = new UCTraCuuKetQua();
                    GridMain.Children.Add(usc);
                    break;
                case "ThuNho":
                    this.WindowState = WindowState.Minimized;
                    break;
                case "Thoat":
                    this.Close();
                    break;
                default:
                    usc = new UCBangQuanTrac();
                    GridMain.Children.Add(usc);
                    break;
            }
        }
        // Tra cứu kết quả


    }
}
