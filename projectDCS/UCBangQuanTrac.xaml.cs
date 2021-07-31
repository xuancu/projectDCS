using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for UCBangQuanTrac.xaml
    /// </summary>
    public partial class UCBangQuanTrac : UserControl
    {
        public string str_khanhhoa;
        public string str_phuyen;
        public static string[] arr_str_phuyen;
        public static string[] arr_str_khanhhoa;

        public int[] arr_canhbao_khanhhoa = new int[3] { 0, 0, 0};
        public int canhbao_khanhhoa;
        public DateTime ThoiGianBatDauCanhBao_KhanhHoa;
        public DateTime ThoiGianKetThucCanhBao_KhanhHoa = new DateTime(9999, 09, 09, 9, 9, 9);
        public int[] arr_canhbao_phuyen = new int[3] { 0, 0, 0 };
        public int canhbao_phuyen;
        public DateTime ThoiGianBatDauCanhBao_PhuYen;
        public DateTime ThoiGianKetThucCanhBao_PhuYen;
        public bool DangCanhBao_KhanhHoa = false;
        public bool DangCanhBao_PhuYen = false;

        /*
         * arr_canhbao_khanhhoa[0] = Cảnh báo LuongMua > 600
         * arr_canhbao_khanhhoa[1] = Cảnh báo TocDoGio > 10
         * arr_canhbao_khanhhoa[2] = Cảnh báo TamNhin  < 5
         * arr_canhbao_khanhhoa[3] = Ngày Bắt đầu: mmddyyyy
         * arr_canhbao_khanhhoa[4] = Giờ Bắt đầu: hhmm
         * 
         * 
         */

        private int counter_time = 0;
        private AccessUngDung QuanTrac1 = new AccessUngDung("QuanTracKhiTuong.mdb", "vxcHust@21");

        System.Windows.Threading.DispatcherTimer UpdateValue = new System.Windows.Threading.DispatcherTimer();

        public UCBangQuanTrac()
        {
            InitializeComponent();
            UpdateValue.Tick += UpdateValue_Tick;
            UpdateValue.Interval = new TimeSpan(0, 0, 1);
            UpdateValue.Start();
        }

        private void UpdateValue_Tick(object sender, EventArgs e)
        {
            GetValueAndUpDate();
        }

        private void GetValueAndUpDate()
        {
            #region Đọc File dữ liệu
            
            try
            {
                StreamReader sr_read_khanhhoa = new StreamReader(@"D:\Ky20202\DCS&SCADA\BaiTapLon\TaoDuLieu\TaoDuLieu\Data\khanhhoa.dat");
                str_khanhhoa = sr_read_khanhhoa.ReadToEnd();
                sr_read_khanhhoa.Close();
            }
            catch
            {
                str_khanhhoa = DateTime.Now.ToString() + "|" + "NULL" + "|" + "0" + "|" + "0" + "|" + "0" + "|" + "0" + "|" + "0" + "|" + "NULL" + "|" + "0";
                    //6 / 9 / 2021 7:55:28 AM | KHÔNG | 124 | 0 | 124 | 19 | 1 | ĐÔNG - NAM | 7
            }
            
            arr_str_khanhhoa = str_khanhhoa.Split('|');

            /* 
             * Cắt chuỗi được: 
             * arr_str_khanhhoa[0] = Thời Gian
             * arr_str_khanhhoa[1] = 0 -> không mưa / 1-> có mưa
             * arr_str_khanhhoa[2] = Lượng mưa hiện tại
             * arr_str_khanhhoa[3] = Lượng mưa liên tục
             * arr_str_khanhhoa[4] = Lượng mua một giờ qua
             * arr_str_khanhhoa[5] = Nhiệt độ hiện tại
             * arr_str_khanhhoa[6] = Tốc độ gió
             * arr_str_khanhhoa[7] = hướng gió ( 1: Đông, 2: Tây, 3: Nam, 4: Bắc)
             * arr_str_khanhhoa[8] = Tầm nhìn
             * 
             * Xử lý cảnh báo: Lượng mưa>600|TocDoGio > 10|TamNhin<5;
             */
            try
            {
                StreamReader sr_read_phuyen = new StreamReader(@"D:\Ky20202\DCS&SCADA\BaiTapLon\TaoDuLieu\TaoDuLieu\Data\phuyen.dat");
                str_phuyen = sr_read_phuyen.ReadToEnd();
                sr_read_phuyen.Close();
            }
            catch
            {
                str_phuyen = DateTime.Now.ToString() + "|" + "NULL" + "|" + "0" + "|" + "0" + "|" + "0" + "|" + "0" + "|" + "0" + "|" + "NULL" + "|" + "0";
            }
            arr_str_phuyen = str_phuyen.Split('|');
            #endregion

            #region Cập nhật thông số lên Bảng Quan Trắc
            #region Lượng mưa _ Khánh Hòa
            TongLuongMuaMotGioQua_KhanhHoa.Text = arr_str_khanhhoa[4] + " mm";
            if(int.Parse(arr_str_khanhhoa[3]) > 600)
            {
                TongLuongMuaLienTuc_KhanhHoa.Foreground = Brushes.Red;
                arr_canhbao_khanhhoa[0] = 1;
            }
            if (int.Parse(arr_str_khanhhoa[3]) <= 600)
            {
                TongLuongMuaLienTuc_KhanhHoa.Foreground = Brushes.Black;
                arr_canhbao_khanhhoa[0] = 0;
            }
            TongLuongMuaLienTuc_KhanhHoa.Text = arr_str_khanhhoa[3] + " mm";
            CoMua_KhanhHoa.Text = arr_str_khanhhoa[1];

            #endregion

            NhietDoHienTai_KhanhHoa.Text = arr_str_khanhhoa[5] + " oC";

            TocDoGioHienTai_KhanhHoa.Text = arr_str_khanhhoa[6] + "m/s";
            if (int.Parse(arr_str_khanhhoa[6]) > 10)
            {
                TocDoGioHienTai_KhanhHoa.Foreground = Brushes.Red;
                arr_canhbao_khanhhoa[1] = 1;
            }
            else if (int.Parse(arr_str_khanhhoa[6]) <= 10)
            {
                TocDoGioHienTai_KhanhHoa.Foreground = Brushes.Black;
                arr_canhbao_khanhhoa[1] = 0;
            }

            HuongGioHienTai_KhanhHoa.Text = arr_str_khanhhoa[7];

            TamNhinHienTai_KhanhHoa.Text = arr_str_khanhhoa[8] + " km";
            if (int.Parse(arr_str_khanhhoa[8]) < 5)
            {
                TamNhinHienTai_KhanhHoa.Foreground = Brushes.Red;
                arr_canhbao_khanhhoa[2] = 1;
            }
            else if (int.Parse(arr_str_khanhhoa[8]) >= 5)
            {
                TamNhinHienTai_KhanhHoa.Foreground = Brushes.Black;
                arr_canhbao_khanhhoa[2] = 0;
            }


            #region Lượng mưa _ Phú Yên 
            TongLuongMuaMotGioQua_PhuYen.Text = arr_str_phuyen[4] + " mm";

            if (int.Parse(arr_str_phuyen[3]) > 600)
            {
                TongLuongMuaLienTuc_PhuYen.Foreground = Brushes.Red;
                arr_canhbao_phuyen[0] = 1;
            }
            else if (int.Parse(arr_str_phuyen[3]) <= 600)
            {
                TongLuongMuaLienTuc_PhuYen.Foreground = Brushes.Black;
                arr_canhbao_phuyen[0] = 0;
            }
            TongLuongMuaLienTuc_PhuYen.Text = arr_str_phuyen[3] + " mm";

            CoMua_PhuYen.Text = arr_str_phuyen[1];
            #endregion

            NhietDoHienTai_PhuYen.Text = arr_str_phuyen[5] + " oC";

            TocDoGioHienTai_PhuYen.Text = arr_str_phuyen[6] + " m/s";
            if (int.Parse(arr_str_phuyen[6]) > 10)
            {
                TocDoGioHienTai_PhuYen.Foreground = Brushes.Red;
                arr_canhbao_phuyen[1] = 1;
            }
            else if (int.Parse(arr_str_phuyen[6]) <= 10)
            {
                TocDoGioHienTai_PhuYen.Foreground = Brushes.Black;
                arr_canhbao_phuyen[1] = 0;
            }

            HuongGioHienTai_PhuYen.Text = arr_str_phuyen[7];

            TamNhinHienTai_PhuYen.Text = arr_str_phuyen[8] + " km";
            if (int.Parse(arr_str_phuyen[8]) < 5)
            {
                TamNhinHienTai_PhuYen.Foreground = Brushes.Red;
                arr_canhbao_phuyen[2] = 1;
            }
            else if(int.Parse(arr_str_phuyen[8]) >= 5)
            {
                TamNhinHienTai_PhuYen.Foreground = Brushes.Black;
                arr_canhbao_phuyen[2] = 0;
            }
            #endregion

            #region Xử lý cảnh báo và tình trạng thời tiết
            canhbao_khanhhoa = arr_canhbao_khanhhoa[0] * 100 + arr_canhbao_khanhhoa[1] * 10 + arr_canhbao_khanhhoa[2];
            canhbao_phuyen = arr_canhbao_phuyen[0] * 100 + arr_canhbao_phuyen[1] * 10 + arr_canhbao_phuyen[2];
            if(arr_str_khanhhoa[1] == "CÓ")
            {
                trangthaithoitiet_khanhhoa.Source = new BitmapImage(new Uri(@"Mua.png", UriKind.RelativeOrAbsolute));
            }
            else if (arr_str_khanhhoa[1] == "KHÔNG")
            {
                trangthaithoitiet_khanhhoa.Source = new BitmapImage(new Uri(@"Nang.png", UriKind.RelativeOrAbsolute));
            }
            if (arr_str_phuyen[1] == "CÓ")
            {
                trangthaithoitiet_phuyen.Source = new BitmapImage(new Uri(@"Mua.png", UriKind.RelativeOrAbsolute));
            }
            else if (arr_str_phuyen[1] == "KHÔNG")
            {
                trangthaithoitiet_phuyen.Source = new BitmapImage(new Uri(@"Nang.png", UriKind.RelativeOrAbsolute));
            }
            #endregion

            #region Ghi vào database
            counter_time++;
            // Khánh Hòa
            if(arr_canhbao_khanhhoa[0] == 1 | arr_canhbao_khanhhoa[1] == 1 | arr_canhbao_khanhhoa[2] == 1)
            {
                if (!DangCanhBao_KhanhHoa)
                {
                    ThoiGianBatDauCanhBao_KhanhHoa = DateTime.Parse(arr_str_khanhhoa[0]);
                    DangCanhBao_KhanhHoa = true;
                }
            }
            if(canhbao_khanhhoa == 0)
            {
                ThoiGianKetThucCanhBao_KhanhHoa = DateTime.Parse(arr_str_khanhhoa[0]);
                DangCanhBao_KhanhHoa = true;
            }

            // Phú Yên
            if (arr_canhbao_phuyen[0] == 1 | arr_canhbao_phuyen[1] == 1 | arr_canhbao_phuyen[2] == 1)
            {
                if (!DangCanhBao_PhuYen)
                {
                    ThoiGianBatDauCanhBao_PhuYen = DateTime.Parse(arr_str_phuyen[0]);
                    DangCanhBao_PhuYen = true;
                }
            }
            if (canhbao_khanhhoa == 0)
            {
                ThoiGianKetThucCanhBao_PhuYen = DateTime.Parse(arr_str_phuyen[0]);
                DangCanhBao_PhuYen = false;
            }

            if (counter_time == 5)
            {
                QuanTrac1.InsertToDatabase("BangQuanTrac", DateTime.Parse(arr_str_khanhhoa[0]), int.Parse(arr_str_khanhhoa[3]), int.Parse(arr_str_khanhhoa[5]), int.Parse(arr_str_khanhhoa[6]), arr_str_khanhhoa[7], int.Parse(arr_str_khanhhoa[8]), canhbao_khanhhoa, ThoiGianBatDauCanhBao_KhanhHoa, ThoiGianKetThucCanhBao_KhanhHoa);
                QuanTrac1.InsertToDatabase("BangQuanTrac_1", DateTime.Parse(arr_str_phuyen[0]), int.Parse(arr_str_phuyen[3]), int.Parse(arr_str_phuyen[5]), int.Parse(arr_str_phuyen[6]), arr_str_phuyen[7], int.Parse(arr_str_phuyen[8]), canhbao_phuyen, ThoiGianBatDauCanhBao_PhuYen, ThoiGianKetThucCanhBao_PhuYen);
                counter_time = 0;
            }    
            #endregion
        }
    }
}
