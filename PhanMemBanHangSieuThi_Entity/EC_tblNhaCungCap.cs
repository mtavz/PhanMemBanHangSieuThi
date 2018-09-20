using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhanMemBanHangSieuThi_Entity
{
    public class EC_tblNhaCungCap
    {
        private string _TenNCC;

        public string TenNCC
        {
            get { return _TenNCC; }
            set { _TenNCC = value; }
        }
        private string _DiaChi;

        public string DiaChi
        {
            get { return _DiaChi; }
            set { _DiaChi = value; }
        }
        private string _SDT;

        public string SDT
        {
            get { return _SDT; }
            set { _SDT = value; }
        }
    }
}
