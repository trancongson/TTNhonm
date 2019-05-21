using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BTL_TTNhom.Models.Entity;
namespace BTL_TTNhom.Models
{
    [Serializable]
    public class CartItem
    {       
        public SACH SACH { set; get; }
        public int Quantity { set; get; }
        public double GiaBan { set; get; }
        public int SoLuong { set; get; }
        public double ThanhTien
        {
            get { return SoLuong* GiaBan; }
        }
    }
}