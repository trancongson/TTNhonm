namespace BTL_TTNhom.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KHACHHANG")]
    public partial class KHACHHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KHACHHANG()
        {
            DONHANGs = new HashSet<DONHANG>();
        }

        [Key]
        public int MAKH { get; set; }
        [Display(Name ="Họ tên")]
        [Required(ErrorMessage ="{0} không được để trống")]
        [StringLength(50)]
        public string HOTEN { get; set; }
        [Display(Name = "Tài khoản")]
        [Required(ErrorMessage = "{0} không được để trống")]
        [StringLength(50)]
        public string TAIKHOAN { get; set; }
        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "{0} không được để trống")]
        [StringLength(50)]
        public string MATKHAU { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "{0} không được để trống")]
        [StringLength(100)]
        public string EMAIL { get; set; }
        [Display(Name = "Địa chỉ")]
        [Required(ErrorMessage = "{0} không được để trống")]
        [StringLength(250)]
        public string DIACHI { get; set; }
        [Display(Name = "Điện thoại")]
        [Required(ErrorMessage = "{0} không được để trống")]
        [StringLength(50)]
        public string DIENTHOAI { get; set; }
        [Display(Name = "Giới tính")]
        [Required(ErrorMessage = "{0} không được để trống")]
        [StringLength(3)]
        public string GIOITINH { get; set; }
        [Display(Name = "Ngày sinh")]
        [Required(ErrorMessage = "{0} không được để trống")]
        public DateTime? NGAYSINH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DONHANG> DONHANGs { get; set; }
    }
}
