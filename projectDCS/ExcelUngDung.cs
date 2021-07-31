using OfficeOpenXml;
using OfficeOpenXml.Style;
using OfficeOpenXml.Table;
using OfficeOpenXml.Table.PivotTable;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Excel_UngDung
{
    public class ExcelUngDung
    {
        public ExcelPackage ep;
        public ExcelWorksheet ws1;
        public ExcelWorksheet ws2;
        public ExcelUngDung()
        {
            ep = new ExcelPackage(new System.IO.FileInfo("SourceBaoCao.xlsx"));
            ws1 = ep.Workbook.Worksheets["Sheet1"];
            ws2 = ep.Workbook.Worksheets["Sheet2"];

        }
        public void XuatThongTinBaoCao(DateTime TuNgay, DateTime DenNgay, string NguoiBaoCao, string TramDo)
        {
            string[] arr = new string[2];
            arr = DateTime.Now.ToShortTimeString().Split(' ');
            if(arr[1]=="AM")
            {
                ws1.Cells[2, 5].Value = "CA NGÀY";
            }  
            else if (arr[1] == "PM")
            {
                ws1.Cells[2, 5].Value = "CA ĐÊM";
            }
            else
            {
                ws1.Cells[2, 5].Value = "NULL";
            }

            
            ws1.Cells[3, 3].Value = TuNgay.ToString();
            ws1.Cells[4, 3].Value = DenNgay.ToString();
            ws1.Cells[3, 5].Value = NguoiBaoCao;
            ws1.Cells[4, 5].Value = TramDo;
        }
        public void XuatDuLieuBang(DataTable DT)
        {
            int i = 8;
            foreach(DataRow dt_row in DT.Rows)
            {
                // STT
                ws1.Cells[i, 1].Value = i - 8;
                ws1.Cells[i, 1].Style.Border.Bottom.Style = ws1.Cells[i, 1].Style.Border.Top.Style = ws1.Cells[i, 1].Style.Border.Left.Style = ws1.Cells[i, 1].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                ws1.Cells[i, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                // Ngày
                ws1.Cells[i, 2].Value = ((DateTime)dt_row[1]).Date;
                ws1.Cells[i, 2].Style.Numberformat.Format = "mm-dd-yy";
                ws1.Cells[i, 2].Style.Border.Bottom.Style = ws1.Cells[i, 2].Style.Border.Top.Style = ws1.Cells[i, 2].Style.Border.Left.Style = ws1.Cells[i, 2].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                ws1.Cells[i, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                // Giờ
                ws1.Cells[i, 3].Value = ((DateTime)dt_row[1]).TimeOfDay;
                ws1.Cells[i, 3].Style.Border.Bottom.Style = ws1.Cells[i, 3].Style.Border.Top.Style = ws1.Cells[i, 3].Style.Border.Left.Style = ws1.Cells[i, 3].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                ws1.Cells[i, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                // Nhiệt độ
                ws1.Cells[i, 4].Value = dt_row[3];
                ws1.Cells[i, 4].Style.Border.Bottom.Style = ws1.Cells[i, 4].Style.Border.Top.Style = ws1.Cells[i, 4].Style.Border.Left.Style = ws1.Cells[i, 4].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                ws1.Cells[i, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                // Lượng mưa
                ws1.Cells[i, 5].Value = dt_row[2];
                ws1.Cells[i, 5].Style.Border.Bottom.Style = ws1.Cells[i, 5].Style.Border.Top.Style = ws1.Cells[i, 5].Style.Border.Left.Style = ws1.Cells[i, 5].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                ws1.Cells[i, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                // Tốc độ gió
                ws1.Cells[i, 6].Value = dt_row[4];
                ws1.Cells[i, 6].Style.Border.Bottom.Style = ws1.Cells[i, 6].Style.Border.Top.Style = ws1.Cells[i, 6].Style.Border.Left.Style = ws1.Cells[i, 6].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                ws1.Cells[i, 6].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                // Hướng gió
                ws1.Cells[i, 7].Value = dt_row[5];
                ws1.Cells[i, 7].Style.Border.Bottom.Style = ws1.Cells[i, 7].Style.Border.Top.Style = ws1.Cells[i, 7].Style.Border.Left.Style = ws1.Cells[i, 7].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                ws1.Cells[i, 7].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                // Tầm nhìn
                ws1.Cells[i, 8].Value = dt_row[6];
                ws1.Cells[i, 8].Style.Border.Bottom.Style = ws1.Cells[i, 8].Style.Border.Top.Style = ws1.Cells[i, 8].Style.Border.Left.Style = ws1.Cells[i, 8].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                ws1.Cells[i, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws1.Cells[i, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                i++;
            }
            
        }
        public void XuatCanhBao(DataTable DT)
        {
            int i = 4;
            foreach (DataRow dt_row in DT.Rows)
            {
                // STT
                ws2.Cells[i, 1].Value = (i-3).ToString();
                ws2.Cells[i, 1].Style.Border.Bottom.Style = ws1.Cells[i, 1].Style.Border.Top.Style = ws1.Cells[i, 1].Style.Border.Left.Style = ws1.Cells[i, 1].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;

                // Ngày
                ws2.Cells[i, 2].Value = ((DateTime)dt_row[1]).ToShortDateString();
                ws2.Cells[i, 2].Style.Border.Bottom.Style = ws1.Cells[i, 2].Style.Border.Top.Style = ws1.Cells[i, 2].Style.Border.Left.Style = ws1.Cells[i, 2].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;

                // Bắt đầu 8
                ws2.Cells[i, 3].Value = ((DateTime)dt_row[8]).TimeOfDay.ToString();
                ws2.Cells[i, 3].Style.Border.Bottom.Style = ws1.Cells[i, 3].Style.Border.Top.Style = ws1.Cells[i, 3].Style.Border.Left.Style = ws1.Cells[i, 3].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;

                // Kết thúc 9
                ws2.Cells[i, 4].Value = ((DateTime)dt_row[9]).TimeOfDay.ToString();
                ws2.Cells[i, 4].Style.Border.Bottom.Style = ws1.Cells[i, 4].Style.Border.Top.Style = ws1.Cells[i, 4].Style.Border.Left.Style = ws1.Cells[i, 4].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;

                if (int.Parse(dt_row[4].ToString())>10)
                {
                    //Gió mạnh 5
                    ws2.Cells[i, 5].Value = "X";
                    //ws2.Cells[i, 5].Style.Border.Bottom.Style = ws1.Cells[i, 5].Style.Border.Top.Style = ws1.Cells[i, 5].Style.Border.Left.Style = ws1.Cells[i, 5].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;

                }
                ws2.Cells[i, 5].Style.Border.Bottom.Style = ws2.Cells[i, 5].Style.Border.Top.Style = ws2.Cells[i, 5].Style.Border.Left.Style = ws2.Cells[i, 5].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                if (int.Parse(dt_row[2].ToString()) > 600)
                {
                    //luong mua lon 6
                    ws2.Cells[i, 6].Value = "X";
                    
                }
                ws2.Cells[i, 6].Style.Border.Bottom.Style = ws2.Cells[i, 6].Style.Border.Top.Style = ws2.Cells[i, 6].Style.Border.Left.Style = ws2.Cells[i, 6].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;

                if (int.Parse(dt_row[6].ToString()) < 5 )
                {
                    //Gió mạnh 7
                    ws2.Cells[i, 7].Value = "X";
                    
                }
                ws2.Cells[i, 7].Style.Border.Bottom.Style = ws2.Cells[i, 7].Style.Border.Top.Style = ws2.Cells[i, 7].Style.Border.Left.Style = ws2.Cells[i, 7].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;


                i++;
            }
        }
        public void LuuBienBan()
        {
            DateTime RTime = DateTime.Now;
            string TenFile = "BB" + RTime.Hour.ToString() + RTime.Minute.ToString() + RTime.Second.ToString() + RTime.Day.ToString() + RTime.Month.ToString() + RTime.Year.ToString();
            string path = @"D:\Ky20202\DCS&SCADA\BaiTapLon\projectDCS\BaoCao1\" + TenFile + ".xlsx";
            Byte[] bin = ep.GetAsByteArray();
            File.WriteAllBytes(path, bin);
            Process.Start(path);
        }
    }
}
