using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for SuaUser.xaml
    /// </summary>
    public partial class SuaUser : UserControl
    {
        private AccessUngDung SuaThongTinUser;
        private DataTable datauser = new DataTable();
        private int ID;
        public SuaUser()
        {
            InitializeComponent();
            SuaThongTinUser = new AccessUngDung("User.mdb", "vxcHust@21");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                datauser = SuaThongTinUser.LoadToDataTable("Select * from DanhSachUser where TenDangNhap=@TenDangNhap", "TenDangNhap", tenusercansua.Text.Trim());
                lvUser.ItemsSource = datauser.DefaultView;
            }
            catch(Exception Loi)
            {
                MessageBox.Show("Không tìm thấy user tương ứng hoặc đã xảy ra ngoại lệ: \n" + Loi.Message);
            }
        }

        private void lvUser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index_selected = lvUser.SelectedIndex;
            tendangnhapcansua.Text = datauser.Rows[index_selected]["TenDangNhap"].ToString();
            matkhaucansua.Password = datauser.Rows[index_selected]["MatKhau"].ToString();
            if (datauser.Rows[index_selected]["NhomUser"].ToString() == "Administrator")
            {
                nhomusercansua.SelectedIndex = 0;
            }
            else if (datauser.Rows[index_selected]["NhomUser"].ToString() == "Moderator")
            {
                nhomusercansua.SelectedIndex = 1;
            }
            else if (datauser.Rows[index_selected]["NhomUser"].ToString() == "User")
            {
                nhomusercansua.SelectedIndex = 2;
            }
            hotencansua.Text = datauser.Rows[index_selected]["HoTen"].ToString();
            sodienthoaicansua.Text = datauser.Rows[index_selected]["SDT"].ToString();
            ID = int.Parse(datauser.Rows[index_selected]["ID"].ToString());
        }

        private void Button_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(WDLogin.NhomTaiKhoan == "Administrator")
            {
                datauser = SuaThongTinUser.LoadToDataTable("Select * from DanhSachUser");
                lvUser.ItemsSource = datauser.DefaultView;
                MessageBox.Show("Đã hiển thị tất cả tài khoản");
            }    
        }
        private void nhomusercansua_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (nhomusercansua.SelectedIndex.ToString() == "0")
            {
                taousermoicansua.IsChecked = true;
                xoausercansua.IsChecked = true;
                phanquyenusercansua.IsChecked = true;
                suathongtinmodcansua.IsChecked = true;
                suathongtinusercansua.IsChecked = true;
                tracuucucbocansua.IsChecked = true;
                tracuuonlinecansua.IsChecked = true;
            }
            else if (nhomusercansua.SelectedIndex.ToString() == "1")
            {
                taousermoicansua.IsChecked = true;
                xoausercansua.IsChecked = true;
                phanquyenusercansua.IsChecked = true;
                suathongtinmodcansua.IsChecked = false;
                suathongtinusercansua.IsChecked = true;
                tracuucucbocansua.IsChecked = true;
                tracuuonlinecansua.IsChecked = false;
            }
            else
            {
                taousermoicansua.IsChecked = false;
                xoausercansua.IsChecked = false;
                phanquyenusercansua.IsChecked = false;
                suathongtinmodcansua.IsChecked = false;
                suathongtinusercansua.IsChecked = false;
                tracuucucbocansua.IsChecked = true;
                tracuuonlinecansua.IsChecked = false;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if(SuaThongTinUser.DeleteUser(ID))
            {
                MessageBox.Show("Xóa User Thành Công");
            }
            else
            {
                MessageBox.Show("Có lỗi! Xin thử lại!");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SuaThongTinUser.UpDateToDatabase(tendangnhapcansua.Text,
                                             matkhaucansua.Password.ToString(),
                                             nhomusercansua.Text.ToString(),
                                             taousermoicansua.IsChecked.Value,
                                             xoausercansua.IsChecked.Value,
                                             phanquyenusercansua.IsChecked.Value,
                                             suathongtinusercansua.IsChecked.Value,
                                             suathongtinmodcansua.IsChecked.Value,
                                             tracuucucbocansua.IsChecked.Value,
                                             tracuuonlinecansua.IsChecked.Value,
                                             hotencansua.Text,
                                             long.Parse(sodienthoaicansua.Text),
                                             ID);
        }
    }
}
