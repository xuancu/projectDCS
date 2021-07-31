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
using System.Data.OleDb;
using System.Data;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;
using Microsoft.Win32;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Diagnostics;
using Access_UngDung;
using Excel_UngDung;

namespace projectDCS
{
    /// <summary>
    /// Interaction logic for UCTraCuuKetQua.xaml
    /// </summary>
    public partial class UCTraCuuKetQua : UserControl
    {
        DataTable table_base = new DataTable();
        AccessUngDung TraCuu1 = new AccessUngDung("QuanTracKhiTuong.mdb", "vxcHust@21");
        ExcelUngDung XuatBaoCao1;
        private DateTime value_date_min;
        private DateTime value_date_max;
        private int value_luongmua_min;
        private int value_luongmua_max;
        private int value_nhietdo_min;
        private int value_nhietdo_max;
        private int value_tocdogio_min;
        private int value_tocdogio_max;
        private int value_tamnhin_min;
        private int value_tamnhin_max;
        private int index_huonggio;
        private string tramtracuu;
        private string[] value_huonggio = new string[] { "BẮC", "ĐÔNG - BẮC", "ĐÔNG", "ĐÔNG - NAM", "NAM", "TÂY - NAM", "TÂY", "TÂY - BẮC"};

        public UCTraCuuKetQua()
        {    
            InitializeComponent();
            if (WDLogin.NhomTaiKhoan != "Administrator")
            {
                TramCanTraCuu.IsEnabled = false;
                tramtracuu = "BangQuanTrac";
            }
            table_base = TraCuu1.LoadToDataTable("Select * from BangQuanTrac");
            LvTraCuu.ItemsSource = table_base.DefaultView;

        }

        private void btn_tracuu_Click(object sender, RoutedEventArgs e)
        {
            if (TramCanTraCuu.SelectedIndex == -1)
            {
                tramtracuu = "BangQuanTrac";
            }
            else if (TramCanTraCuu.SelectedIndex == 0)
            {
                tramtracuu = "BangQuanTrac";
            }
            else if (TramCanTraCuu.SelectedIndex == 1)
            {
                tramtracuu = "BangQuanTrac_1";
            }
            else
            {
                tramtracuu = "BangQuanTrac";
            }
            #region Cài đặt thông số

            //if (date_min. == null) { value_date_min = new DateTime(1999, 1, 1, 0, 0, 0); }
            //else { value_date_min = (DateTime)date_min.Value; }
            //if (date_max.Value == null) { value_date_max = new DateTime(2050, 12, 31, 11, 59, 59); }
            //else { value_date_max = (DateTime)date_max.Value; }
            if (date_min.SelectedDate == null) { value_date_min = DateTime.MinValue; }
            else { value_date_min = date_min.SelectedDate.Value; }
            if (date_max.SelectedDate == null) { value_date_max = DateTime.MaxValue; }
            else { value_date_max = date_max.SelectedDate.Value; }

            if (time_min.SelectedTime != null) { value_date_min = new DateTime(value_date_min.Year, value_date_min.Month, value_date_min.Day, time_min.SelectedTime.Value.Hour, time_min.SelectedTime.Value.Minute, time_min.SelectedTime.Value.Second); }
            else {value_date_min = new DateTime(value_date_min.Year, value_date_min.Month, value_date_min.Day, 0, 0, 0); }
            if (time_max.SelectedTime != null) { value_date_max = new DateTime(value_date_max.Year, value_date_max.Month, value_date_max.Day, time_max.SelectedTime.Value.Hour, time_max.SelectedTime.Value.Minute, time_max.SelectedTime.Value.Second); }
            else { value_date_max = new DateTime(value_date_max.Year, value_date_max.Month, value_date_max.Day, 11, 59, 59); }

            if (luongmua_min.Text == null | luongmua_min.Text == "") { value_luongmua_min = 0; }
            else { value_luongmua_min = int.Parse(luongmua_min.Text); }
            if (luongmua_max.Text == null | luongmua_max.Text == "") { value_luongmua_max = 99999999; }
            else { value_luongmua_max = int.Parse(luongmua_max.Text); }

            if (nhietdo_min.Text == null | nhietdo_min.Text == "") { value_nhietdo_min = 0; }
            else { value_nhietdo_min = int.Parse(nhietdo_min.Text); }
            if (nhietdo_max.Text == null | nhietdo_max.Text == "") { value_nhietdo_max = 9999; }
            else { value_nhietdo_max = int.Parse(nhietdo_max.Text); }

            if (tocdogio_min.Text == null | tocdogio_min.Text == "") { value_tocdogio_min = 0; }
            else { value_tocdogio_min = int.Parse(tocdogio_min.Text); }
            if (tocdogio_max.Text == null | tocdogio_max.Text == "") { value_tocdogio_max = 9999; }
            else { value_tocdogio_max = int.Parse(tocdogio_max.Text); }

            if (tamnhin_min.Text == null | tamnhin_min.Text == "") { value_tamnhin_min = 0; }
            else { value_tamnhin_min = int.Parse(tamnhin_min.Text); }
            if (tamnhin_max.Text == null | tamnhin_max.Text == "") { value_tamnhin_max = 9999; }
            else { value_tamnhin_max = int.Parse(tamnhin_max.Text); }
            #endregion

            if (index_huonggio == 0)
            {
                table_base = TraCuu1.TraCuu(tramtracuu, value_date_min, value_date_max,
                                            value_luongmua_min, value_luongmua_max, "LuongMua",
                                            value_nhietdo_min, value_nhietdo_max, "NhietDo",
                                            value_tocdogio_min, value_tocdogio_max, "TocDoGio",
                                            value_tamnhin_min, value_tamnhin_max, "TamNhin");
            }
            else
            {
                table_base = TraCuu1.TraCuu(tramtracuu, value_date_min, value_date_max,
                                            value_luongmua_min, value_luongmua_max, "LuongMua",
                                            value_nhietdo_min, value_nhietdo_max, "NhietDo",
                                            value_tocdogio_min, value_tocdogio_max, "TocDoGio",
                                            value_tamnhin_min, value_tamnhin_max, "TamNhin",
                                            value_huonggio[index_huonggio - 1], "HuongGio");
            }
            LvTraCuu.ItemsSource = table_base.DefaultView;
        }

        private void btn_xuatbaocao_Click(object sender, RoutedEventArgs e)
        {
            XuatBaoCao1 = new ExcelUngDung();
            XuatBaoCao1.XuatThongTinBaoCao(value_date_min, value_date_max, WDLogin.TenUser, TramCanTraCuu.Text.ToString());
            XuatBaoCao1.XuatDuLieuBang(table_base);
            XuatBaoCao1.XuatCanhBao(table_base);
            XuatBaoCao1.LuuBienBan();
        }

        private void huongiotimkiem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            index_huonggio = huongiotimkiem.SelectedIndex;
        }

        
    }
}
