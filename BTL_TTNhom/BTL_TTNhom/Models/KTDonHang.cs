using BTL_TTNhom.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL_TTNhom.Models
{
    public class KTDonHang
    {
        public int MaDonHang { get; set; }
        public string HoTen { get; set; }
        public string DiaChi { get; set; }
        public DateTime NgayDat { get; set; }
        public string Email { get; set; }
        public string Dienthoai { get; set; }
        public decimal ThanhTien { get; set; }

        public Quanlybansach kiemtra = null;
        public KTDonHang()
        {
            kiemtra = new Quanlybansach();
        }

        public List<KTDonHang> DonHangCT()
        {
            List<KTDonHang> kt = kiemtra.Database.SqlQuery<KTDonHang>("pro_DonHang").ToList();
            return (kt);
        }
    }
}