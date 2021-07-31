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
using Access_UngDung;
using System.Data;

namespace projectDCS
{
    /// <summary>
    /// Interaction logic for WDLogin.xaml
    /// </summary>
    public partial class WDLogin : Window
    {
        AccessUngDung DB_User;
        DataTable DT_User = new DataTable();
        public static string TaiKhoan, TenUser, Phone, NhomTaiKhoan;
        public WDLogin()
        {
            InitializeComponent();
            DB_User = new AccessUngDung("User.mdb", "vxcHust@21");
            DT_User = DB_User.LoadToDataTable("Select * from DanhSachUser");
        }
        private void btn_Login_click(object sender, RoutedEventArgs e)
        {
            if (CheckThongTinUser())
            {
                DB_User.HuyKetNoi();
                this.Close();
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không tồn tại!");
                tb_MatKhau.Clear();
            }

        }

        private void btn_Thoat_click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private bool CheckThongTinUser()
        {
            foreach (DataRow row in DT_User.Rows)
            {
                if (tb_TaiKhoan.Text == row[1].ToString() && tb_MatKhau.Password.ToString() == row[2].ToString())
                {
                    TaiKhoan = tb_TaiKhoan.Text;
                    NhomTaiKhoan = row[3].ToString();
                    TenUser = row[11].ToString();
                    Phone = row[12].ToString();
                    return true;
                }    
            }
            return false;
        }
    }
}
