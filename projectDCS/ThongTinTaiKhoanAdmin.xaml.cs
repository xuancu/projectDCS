using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using Access_UngDung;

namespace projectDCS
{
    /// <summary>
    /// Interaction logic for ThongTinTaiKhoanAdmin.xaml
    /// </summary>
    public partial class ThongTinTaiKhoanAdmin : UserControl
    {
        //AccessUngDung db1 = new AccessUngDung("QuanTracKhiTuong.mdb", "vxcHust@21");
        public ThongTinTaiKhoanAdmin()
        {
            InitializeComponent();
            tb_Acc.Text = "Account        :  " + WDLogin.TaiKhoan;
            tb_Name.Text = "Tên người dùng :  " + WDLogin.TenUser;
            tb_SDT.Text = "Số điện thoại  :  " + WDLogin.Phone;
            tb_NhomUser.Text = "Nhóm tài khoản :  " + WDLogin.NhomTaiKhoan;
        }

        private void btn_Thoat_click(object sender, RoutedEventArgs e)
        {
            Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }

        private void btn_Login_click(object sender, RoutedEventArgs e)
        {
            WDQuanLyTaiKhoan wd1 = new WDQuanLyTaiKhoan();
            wd1.ShowDialog();
        }
    }
}
