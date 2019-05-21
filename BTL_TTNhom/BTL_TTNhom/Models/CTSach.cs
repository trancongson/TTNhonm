using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BTL_TTNhom.Models.Entity;
namespace BTL_TTNhom.Models
{
    public class CTSach
    {
        [Display(Name = "Mã sách:")]
        public int MaSach { get; set; }
        [Display(Name = "Tên sách:")]
        public string TenSach { get; set; }
        [Display(Name = "Tên chủ đề:")]
        public string TenChuDe { get; set; }
        [Display(Name = "Tên tác giả:")]
        public string TenTacGia { get; set; }
        [Display(Name = "Giá bán:")]
        public decimal GiaBan { get; set; }
        [Display(Name = "Ảnh bìa:")]
        public string AnhBia { get; set; }
        [Display(Name = "Mô tả:")]
        public string MoTa { get; set; }
        public Quanlybansach chitiet = null;
        public CTSach()
        {
            chitiet = new Quanlybansach();
        }

        public List<CTSach> ListCTSach()
        {
            List<CTSach> cts = chitiet.Database.SqlQuery<CTSach>("pro_Chitiet").ToList();
            return (cts);
        }
    }
}