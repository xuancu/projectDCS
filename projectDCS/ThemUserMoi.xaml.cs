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
using Access_UngDung;

namespace projectDCS
{
    /// <summary>
    /// Interaction logic for ThemUserMoi.xaml
    /// </summary>
    
    public partial class ThemUserMoi : UserControl
    {
        private AccessUngDung dbthemuser = new AccessUngDung("User.mdb", "vxcHust@21");
        //private string TenDangNhap_Value;
        //private string MatKhau_Value;
        //private string NhomUser_Value;
        //private string HoTen;
        //private Int32 SoDienThoai;

        public ThemUserMoi()
        {
            InitializeComponent();
        }

        private void btn_apply(object sender, RoutedEventArgs e)
        {
            try
            {
                dbthemuser.InsertToDatabase(tendangnhap.Text, matkhau.Password.ToString(), nhomuser.Text.ToString(), taousermoi.IsChecked.Value, xoauser.IsChecked.Value, phanquyenuser.IsChecked.Value, suathongtinuser.IsChecked.Value, suathongtinmod.IsChecked.Value, tracuucucbo.IsChecked.Value, tracuuonline.IsChecked.Value, hoten.Text, long.Parse(sodienthoai.Text));
                MessageBox.Show("Thêm tài khoản thành công");
                tendangnhap.Clear();
                matkhau.Clear();
                hoten.Clear();
                sodienthoai.Clear();

            }
            catch(Exception Loi)
            {
                MessageBox.Show("Có lỗi xảy ra. Exception: " + Loi.Message);
            }
        }

        private void nhomuser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (nhomuser.SelectedIndex.ToString() == "0")
            {
                taousermoi.IsChecked = true;
                xoauser.IsChecked = true;
                phanquyenuser.IsChecked = true;
                suathongtinmod.IsChecked = true;
                suathongtinuser.IsChecked = true;
                tracuucucbo.IsChecked = true;
                tracuuonline.IsChecked = true;
            }
            else if (nhomuser.SelectedIndex.ToString() == "1")
            {
                taousermoi.IsChecked = true;
                xoauser.IsChecked = true;
                phanquyenuser.IsChecked = true;
                suathongtinmod.IsChecked = false;
                suathongtinuser.IsChecked = true;
                tracuucucbo.IsChecked = true;
                tracuuonline.IsChecked = false;
            }
            else
            {
                taousermoi.IsChecked = false;
                xoauser.IsChecked = false;
                phanquyenuser.IsChecked = false;
                suathongtinmod.IsChecked = false;
                suathongtinuser.IsChecked = false;
                tracuucucbo.IsChecked = true;
                tracuuonline.IsChecked = false;
            }
        }
    }
}
