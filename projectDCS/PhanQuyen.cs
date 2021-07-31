using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User
{
    public class PhanQuyen
    {
        public string Account { get; private set; }
        public string Password { get; private set; }
        public string NhomUser { get; private set; }
        public bool TaoUserMoi { get; private set; }
        public bool XoaUser { get; private set; }
        public bool PhanQuyenChoUser { get; private set; }
        public bool SuaThongTinUser { get; private set; }
        public bool SuaThongTinMod { get; private set; }
        public bool TraCuuDataCucBo { get; private set; }
        public bool TraCuuDataOnline { get; private set; }

        internal PhanQuyen(string acc, string pass, string nhomuser, bool taouser, bool xoauser, bool phanquyenuser, bool suathongtinuser, bool suathongtinmod, bool tracuudatacucbo, bool tracuudataonlie)
        {
            this.Account = acc;
            this.Password = pass;
            this.NhomUser = nhomuser;
            this.TaoUserMoi = taouser;
            this.XoaUser = xoauser;
            this.PhanQuyenChoUser = phanquyenuser;
            this.SuaThongTinUser = suathongtinuser;
            this.SuaThongTinMod = suathongtinmod;
            this.TraCuuDataCucBo = tracuudatacucbo;
            this.TraCuuDataOnline = tracuudataonlie;    
        }
    }
}
