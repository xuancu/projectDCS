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
    /// Interaction logic for UCThongTinTaiKhoan.xaml
    /// </summary>
    public partial class UCThongTinTaiKhoan : UserControl
    {
        public UCThongTinTaiKhoan()
        {
            InitializeComponent();
            tb_Acc.Text = "Account        :  " + WDLogin.TaiKhoan;
            tb_Name.Text ="Tên người dùng :  " + WDLogin.TenUser;
            tb_SDT.Text = "Số điện thoại  :  " + WDLogin.Phone;
            tb_NhomUser.Text = "Nhóm tài khoản :  " + WDLogin.NhomTaiKhoan;
        }
    }
}
