using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using User;

namespace Access_UngDung
{
    public class AccessUngDung
    {
        private string chuoiketnoi;
        private OleDbConnection ctner;
        private OleDbDataAdapter dat;
        private DataTable dt;
        private OleDbCommand cmd;
        private string DatabaseCanSua;
        public AccessUngDung()
        {

        }
        public AccessUngDung(string DataBase_Name, string Password)
        {
            chuoiketnoi = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = " + DataBase_Name + "; Jet OLEDB:Database PassWord = "+ Password;
            DatabaseCanSua = DataBase_Name;
        }
        public AccessUngDung(string DataBase_Name)
        {
            chuoiketnoi = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = " + DataBase_Name + "; Jet OLEDB:Database";
            DatabaseCanSua = DataBase_Name;
        }
        public void InsertToDatabase(string Table ,DateTime DateValue, int LuongMuaValue, int NhietDoValue, int TocDoGioValue, string HuongGioValue, int TamNhinValue, int MaCanhBao, DateTime CanhBaoBatDau, DateTime CanhBaoKetThuc)
        {
            if (ctner == null)
                TaoKetNoi();
            if (DatabaseCanSua == "QuanTracKhiTuong.mdb")
            {
                cmd = new OleDbCommand("INSERT INTO " + Table + " ([ThoiGian],[LuongMua],[NhietDo],[TocDoGio],[HuongGio],[TamNhin],[CanhBao],[ThoiGianBatDauCanhBao],[ThoiGianKetThucCanhBao]) VALUES(?,?,?,?,?,?,?,?,?)");
                cmd.Connection = ctner;
                cmd.Parameters.AddWithValue("@ThoiGian", DateValue);
                cmd.Parameters.AddWithValue("@LuongMua", LuongMuaValue);
                cmd.Parameters.AddWithValue("@NhietDo", NhietDoValue);
                cmd.Parameters.AddWithValue("@TocDoGio", TocDoGioValue);
                cmd.Parameters.AddWithValue("@HuongGio", HuongGioValue);
                cmd.Parameters.AddWithValue("@TamNhin", TamNhinValue);
                cmd.Parameters.AddWithValue("@CanhBao", MaCanhBao);
                cmd.Parameters.AddWithValue("@ThoiGianBatDauCanhBao", CanhBaoBatDau);
                cmd.Parameters.AddWithValue("@ThoiGianKetThucCanhBao", CanhBaoKetThuc);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            else
            {
                MessageBox.Show("Không tồn tại Database hợp lệ");
            }    
            
        }
        public void InsertToDatabase(string TenDangNhapValue, string MatKhauValue, string NhomUserValue, bool TaoUserMoiValue, bool XoaUserValue, bool PhanQuyenChoUserValue, bool SuaThongTinUserValue, bool SuaThongTinModValue, bool TraCuuDataCucBoValue, bool TraCuuDataOnlineValue, string HoTenValue, Int64 SDTValue)
        {
            if (ctner == null)
                TaoKetNoi();
            if (DatabaseCanSua == "User.mdb")
            {
                cmd = new OleDbCommand("INSERT INTO DanhSachUser ([TenDangNhap],[MatKhau],[NhomUser],[TaoUserMoi],[XoaUser],[PhanQuyenChoUser],[SuaThongTinUser],[SuaThongTinMod],[TraCuuDataCucBo],[TraCuuDataOnline],[HoTen],[SDT]) VALUES(?,?,?,?,?,?,?,?,?,?,?,?)");
                cmd.Connection = ctner;
                cmd.Parameters.AddWithValue("@TenDangNhap", TenDangNhapValue);
                cmd.Parameters.AddWithValue("@MatKhau", MatKhauValue);
                cmd.Parameters.AddWithValue("@NhomUser", NhomUserValue);
                cmd.Parameters.AddWithValue("@TaoUserMoi", TaoUserMoiValue);
                cmd.Parameters.AddWithValue("@XoaUser", XoaUserValue);
                cmd.Parameters.AddWithValue("@PhanQuyenChoUser", PhanQuyenChoUserValue);
                cmd.Parameters.AddWithValue("@SuaThongTinUser", SuaThongTinUserValue);
                cmd.Parameters.AddWithValue("@SuaThongTinMod", SuaThongTinModValue);
                cmd.Parameters.AddWithValue("@TraCuuDataCucBo", TraCuuDataCucBoValue);
                cmd.Parameters.AddWithValue("@TraCuuDataOnline", TraCuuDataOnlineValue);
                cmd.Parameters.AddWithValue("@HoTen", HoTenValue);
                cmd.Parameters.AddWithValue("@SDT", SDTValue);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            else
            {
                MessageBox.Show("Không tồn tại Database hợp lệ");
            }

        }
        public void UpDateToDatabase(string Table, string DateValue, int LuongMuaValue, int NhietDoValue, int TocDoGioValue, string HuongGioValue, int TamNhinValue, int STT)
        {
            if (ctner == null)
                TaoKetNoi();
            cmd = new OleDbCommand("UPDATE " + Table + " SET [ThoiGian] = ? , [LuongMua] = ? ,[NhietDo] = ? ,[TocDoGio] = ? ,[HuongGio] = ? ,[TamNhin] = ? WHERE [STT] = ? ");
            cmd.Connection = ctner;
            cmd.Parameters.AddWithValue("@ThoiGian", DateValue);
            cmd.Parameters.AddWithValue("@LuongMua", LuongMuaValue);
            cmd.Parameters.AddWithValue("@NhietDo", NhietDoValue);
            cmd.Parameters.AddWithValue("@TocDoGio", TocDoGioValue);
            cmd.Parameters.AddWithValue("@HuongGio", HuongGioValue);
            cmd.Parameters.AddWithValue("@TamNhin", TamNhinValue);
            cmd.Parameters.AddWithValue("@STT", STT);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }
        public void UpDateToDatabase(string TenDangNhapValue, string MatKhauValue, string NhomUserValue, bool TaoUserMoiValue, bool XoaUserValue, bool PhanQuyenChoUserValue, bool SuaThongTinUserValue, bool SuaThongTinModValue, bool TraCuuDataCucBoValue, bool TraCuuDataOnlineValue, string HoTenValue, Int64 SDTValue, int ID)
        {
            if (ctner == null)
                TaoKetNoi();
            if (DatabaseCanSua == "User.mdb")
            {
                cmd = new OleDbCommand("UPDATE DanhSachUser SET [TenDangNhap] = ?,[MatKhau] = ?,[NhomUser] = ?,[TaoUserMoi] = ?,[XoaUser] = ?,[PhanQuyenChoUser] = ?,[SuaThongTinUser] = ?,[SuaThongTinMod] = ?,[TraCuuDataCucBo] = ?,[TraCuuDataOnline] = ?,[HoTen] = ?,[SDT] = ? WHERE [ID] = ?");
                cmd.Connection = ctner;
                cmd.Parameters.AddWithValue("@TenDangNhap", TenDangNhapValue);
                cmd.Parameters.AddWithValue("@MatKhau", MatKhauValue);
                cmd.Parameters.AddWithValue("@NhomUser", NhomUserValue);
                cmd.Parameters.AddWithValue("@TaoUserMoi", TaoUserMoiValue);
                cmd.Parameters.AddWithValue("@XoaUser", XoaUserValue);
                cmd.Parameters.AddWithValue("@PhanQuyenChoUser", PhanQuyenChoUserValue);
                cmd.Parameters.AddWithValue("@SuaThongTinUser", SuaThongTinUserValue);
                cmd.Parameters.AddWithValue("@SuaThongTinMod", SuaThongTinModValue);
                cmd.Parameters.AddWithValue("@TraCuuDataCucBo", TraCuuDataCucBoValue);
                cmd.Parameters.AddWithValue("@TraCuuDataOnline", TraCuuDataOnlineValue);
                cmd.Parameters.AddWithValue("@HoTen", HoTenValue);
                cmd.Parameters.AddWithValue("@SDT", SDTValue);
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            else
            {
                MessageBox.Show("Không tồn tại Database hợp lệ");
            }

        }

        public DataTable LoadToDataTable(string CommandQuerry)
        {
            if (ctner == null) 
                TaoKetNoi();
            cmd = new OleDbCommand();
            cmd.Connection = ctner;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = CommandQuerry;
            dat = new OleDbDataAdapter();
            dt = new DataTable();
            dat.SelectCommand = cmd;
            dat.Fill(dt);
            //ctner.Dispose();
            cmd.Dispose();
            dat.Dispose();
            return dt;
        }
        public DataTable LoadToDataTable(string CommandQuerry, string ColumnSearch, string ValueSearch)
        {
            if (ctner == null)
                TaoKetNoi();
            cmd = new OleDbCommand();
            cmd.Connection = ctner;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = CommandQuerry;
            cmd.Parameters.Add(ColumnSearch, OleDbType.VarChar).Value = ValueSearch;
            dat = new OleDbDataAdapter();
            dt = new DataTable();
            dat.SelectCommand = cmd;
            dat.Fill(dt);
            //ctner.Dispose();
            cmd.Dispose();
            dat.Dispose();
            return dt;
        }
        public bool DeleteUser(int ID)
        {
            try
            {
                if (ctner == null)
                    TaoKetNoi();
                cmd = new OleDbCommand("DELETE FROM DanhSachUser WHERE [ID] = ?");
                cmd.Connection = ctner;
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        
        #region Các hàm tra cứu
        public DataTable TraCuu(string Table, DateTime date_min, DateTime date_max)
        {
            string CommandQuery = "SELECT * FROM " + Table + " WHERE ThoiGian >= @date_min AND ThoiGian <= @date_max";
            if (ctner == null)
                TaoKetNoi();
            cmd = new OleDbCommand();
            cmd.Connection = ctner;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = CommandQuery;

            cmd.Parameters.AddWithValue("date_min", date_min);
            cmd.Parameters.AddWithValue("date_max", date_max);
            dat = new OleDbDataAdapter();
            dt = new DataTable();
            dat.SelectCommand = cmd;
            dat.Fill(dt);
            //ctner.Dispose();
            cmd.Dispose();
            dat.Dispose();
            return dt;
        }

        public DataTable TraCuu(string Table, int data_min, int data_max, string ColummSearch)
        {
            string CommandQuery = "SELECT * FROM " + Table + " WHERE " + ColummSearch + " >= @data_min AND " + ColummSearch + " <= @data_max"; 
     
            if (ctner == null)
                TaoKetNoi();
            cmd = new OleDbCommand();
            cmd.Connection = ctner;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = CommandQuery;
            cmd.Parameters.AddWithValue("data_min", data_min);
            cmd.Parameters.AddWithValue("data_max", data_max);
            dat = new OleDbDataAdapter();
            dt = new DataTable();
            dat.SelectCommand = cmd;
            dat.Fill(dt);
            //ctner.Dispose();
            cmd.Dispose();
            dat.Dispose();
            return dt;
        }

        public DataTable TraCuu(string Table, int data_min_1, int data_max_1, string ColummSearch_1, 
                                int data_min_2, int data_max_2, string ColummSearch_2)
        {
            string CommandQuery = "SELECT * FROM " + Table + " WHERE " + ColummSearch_1 + " >= @data_min_1 AND " + ColummSearch_1 + " <= @data_max_1 AND "
                                                                      + ColummSearch_2 + " >= @data_min_2 AND " + ColummSearch_2 + " <= @data_max_2";
            if (ctner == null)
                TaoKetNoi();
            cmd = new OleDbCommand();
            cmd.Connection = ctner;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = CommandQuery;
            cmd.Parameters.AddWithValue("data_min_1", data_min_1);
            cmd.Parameters.AddWithValue("data_max_1", data_max_1);
            cmd.Parameters.AddWithValue("data_min_2", data_min_2);
            cmd.Parameters.AddWithValue("data_max_2", data_max_2);
            dat = new OleDbDataAdapter();
            dt = new DataTable();
            dat.SelectCommand = cmd;
            dat.Fill(dt);
            //ctner.Dispose();
            cmd.Dispose();
            dat.Dispose();
            return dt;
        }

        public DataTable TraCuu(string Table, int data_min_1, int data_max_1, string ColummSearch_1, 
                                int data_min_2, int data_max_2, string ColummSearch_2, 
                                int data_min_3, int data_max_3, string ColummSearch_3)
        {
            string CommandQuery = "SELECT * FROM " + Table + " WHERE " + ColummSearch_1 + " >= @data_min_1 AND " + ColummSearch_1 + " <= @data_max_1 AND "
                                                                      + ColummSearch_2 + " >= @data_min_2 AND " + ColummSearch_2 + " <= @data_max_2 AND "
                                                                      + ColummSearch_3 + " >= @data_min_3 AND " + ColummSearch_3 + " <= @data_max_3";
            if (ctner == null)
                TaoKetNoi();
            cmd = new OleDbCommand();
            cmd.Connection = ctner;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = CommandQuery;
            cmd.Parameters.AddWithValue("data_min_1", data_min_1);
            cmd.Parameters.AddWithValue("data_max_1", data_max_1);
            cmd.Parameters.AddWithValue("data_min_2", data_min_2);
            cmd.Parameters.AddWithValue("data_max_2", data_max_2);
            cmd.Parameters.AddWithValue("data_min_3", data_min_3);
            cmd.Parameters.AddWithValue("data_max_3", data_max_3);
            dat = new OleDbDataAdapter();
            dt = new DataTable();
            dat.SelectCommand = cmd;
            dat.Fill(dt);
            //ctner.Dispose();
            cmd.Dispose();
            dat.Dispose();
            return dt;
        }
        public DataTable TraCuu(string Table, int data_min_1, int data_max_1, string ColummSearch_1,
                                int data_min_2, int data_max_2, string ColummSearch_2,
                                int data_min_3, int data_max_3, string ColummSearch_3,
                                int data_min_4, int data_max_4, string ColummSearch_4)
        {
            string CommandQuery = "SELECT * FROM " + Table + " WHERE " + ColummSearch_1 + " >= @data_min_1 AND " + ColummSearch_1 + " <= @data_max_1 AND "
                                                                      + ColummSearch_2 + " >= @data_min_2 AND " + ColummSearch_2 + " <= @data_max_2 AND "
                                                                      + ColummSearch_3 + " >= @data_min_3 AND " + ColummSearch_3 + " <= @data_max_3 AND "
                                                                      + ColummSearch_4 + " >= @data_min_4 AND " + ColummSearch_4 + " <= @data_max_4";
            if (ctner == null)
                TaoKetNoi();
            cmd = new OleDbCommand();
            cmd.Connection = ctner;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = CommandQuery;
            cmd.Parameters.AddWithValue("data_min_1", data_min_1);
            cmd.Parameters.AddWithValue("data_max_1", data_max_1);
            cmd.Parameters.AddWithValue("data_min_2", data_min_2);
            cmd.Parameters.AddWithValue("data_max_2", data_max_2);
            cmd.Parameters.AddWithValue("data_min_3", data_min_3);
            cmd.Parameters.AddWithValue("data_max_3", data_max_3);
            cmd.Parameters.AddWithValue("data_min_4", data_min_4);
            cmd.Parameters.AddWithValue("data_max_4", data_max_4);
            dat = new OleDbDataAdapter();
            dt = new DataTable();
            dat.SelectCommand = cmd;
            dat.Fill(dt);
            //ctner.Dispose();
            cmd.Dispose();
            dat.Dispose();
            return dt;
        }
        public DataTable TraCuu(string Table, DateTime date_min, DateTime date_max,
                                int data_min_1, int data_max_1, string ColummSearch_1,
                                int data_min_2, int data_max_2, string ColummSearch_2,
                                int data_min_3, int data_max_3, string ColummSearch_3,
                                int data_min_4, int data_max_4, string ColummSearch_4)
        {
            string CommandQuery = "SELECT * FROM " + Table + " WHERE " + "ThoiGian" + " >= @date_min AND " + "ThoiGian" + " <= @date_max AND "
                                                                      + ColummSearch_1 + " >= @data_min_1 AND " + ColummSearch_1 + " <= @data_max_1 AND "
                                                                      + ColummSearch_2 + " >= @data_min_2 AND " + ColummSearch_2 + " <= @data_max_2 AND "
                                                                      + ColummSearch_3 + " >= @data_min_3 AND " + ColummSearch_3 + " <= @data_max_3 AND "
                                                                      + ColummSearch_4 + " >= @data_min_4 AND " + ColummSearch_4 + " <= @data_max_4";
            
            if (ctner == null)
                TaoKetNoi();
            cmd = new OleDbCommand();
            cmd.Connection = ctner;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = CommandQuery;
            cmd.Parameters.AddWithValue("date_min", date_min);
            cmd.Parameters.AddWithValue("date_max", date_max);
            cmd.Parameters.AddWithValue("data_min_1", data_min_1);
            cmd.Parameters.AddWithValue("data_max_1", data_max_1);
            cmd.Parameters.AddWithValue("data_min_2", data_min_2);
            cmd.Parameters.AddWithValue("data_max_2", data_max_2);
            cmd.Parameters.AddWithValue("data_min_3", data_min_3);
            cmd.Parameters.AddWithValue("data_max_3", data_max_3);
            cmd.Parameters.AddWithValue("data_min_4", data_min_4);
            cmd.Parameters.AddWithValue("data_max_4", data_max_4);
            dat = new OleDbDataAdapter();
            dt = new DataTable();
            dat.SelectCommand = cmd;
            dat.Fill(dt);
            //ctner.Dispose();
            cmd.Dispose();
            dat.Dispose();
            return dt;
        }

        public DataTable TraCuu(string Table, DateTime date_min, DateTime date_max,
                                int data_min_1, int data_max_1, string ColummSearch_1,
                                int data_min_2, int data_max_2, string ColummSearch_2,
                                int data_min_3, int data_max_3, string ColummSearch_3,
                                int data_min_4, int data_max_4, string ColummSearch_4,
                                string huonggio, string ColummSearch_5)
        {
            string CommandQuery = "SELECT * FROM " + Table + " WHERE " + "ThoiGian" + " >= @date_min AND " + "ThoiGian" + " <= @date_max AND "
                                                                      + ColummSearch_1 + " >= @data_min_1 AND " + ColummSearch_1 + " <= @data_max_1 AND "
                                                                      + ColummSearch_2 + " >= @data_min_2 AND " + ColummSearch_2 + " <= @data_max_2 AND "
                                                                      + ColummSearch_3 + " >= @data_min_3 AND " + ColummSearch_3 + " <= @data_max_3 AND "
                                                                      + ColummSearch_4 + " >= @data_min_4 AND " + ColummSearch_4 + " <= @data_max_4 AND "
                                                                      + ColummSearch_5 + " = @huonggio";
            if (ctner == null)
                TaoKetNoi();
            cmd = new OleDbCommand();
            cmd.Connection = ctner;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = CommandQuery;
            cmd.Parameters.AddWithValue("date_min", date_min);
            cmd.Parameters.AddWithValue("date_max", date_max);
            cmd.Parameters.AddWithValue("data_min_1", data_min_1);
            cmd.Parameters.AddWithValue("data_max_1", data_max_1);
            cmd.Parameters.AddWithValue("data_min_2", data_min_2);
            cmd.Parameters.AddWithValue("data_max_2", data_max_2);
            cmd.Parameters.AddWithValue("data_min_3", data_min_3);
            cmd.Parameters.AddWithValue("data_max_3", data_max_3);
            cmd.Parameters.AddWithValue("data_min_4", data_min_4);
            cmd.Parameters.AddWithValue("data_max_4", data_max_4);
            cmd.Parameters.AddWithValue("huonggio", huonggio);
            dat = new OleDbDataAdapter();
            dt = new DataTable();
            dat.SelectCommand = cmd;
            dat.Fill(dt);
            //ctner.Dispose();
            cmd.Dispose();
            dat.Dispose();
            return dt;
        }
        #endregion

        public bool DeleteRecordThoiTiet(int ID)
        {
            try
            {
                if (ctner == null)
                    TaoKetNoi();
                cmd = new OleDbCommand("DELETE FROM BangQuanTrac WHERE [ID] = ?");
                cmd.Connection = ctner;
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        private void TaoKetNoi()
        {
            ctner = new OleDbConnection(chuoiketnoi);
            ctner.Open();
        }
        internal void HuyKetNoi()
        {
            ctner.Close(); // Ngắt kết nối với CSDL
            ctner.Dispose(); // Hủy đối tượng, giải phóng tài nguyên
            ctner = null;
        }
    }
}
