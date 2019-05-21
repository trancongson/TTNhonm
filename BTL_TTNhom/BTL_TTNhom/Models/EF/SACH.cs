namespace BTL_TTNhom.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SACH")]
    public partial class SACH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SACH()
        {
            CHITIETDONHANGs = new HashSet<CHITIETDONHANG>();
            THAMGIAs = new HashSet<THAMGIA>();
        }

        [Key]
        public int MASACH { get; set; }
        [Display(Name = "Tên sách:")]
        [StringLength(50)]
        public string TENSACH { get; set; }
        [Display(Name = "Giá bán:")]
        public decimal? GIABAN { get; set; }
        [Display(Name = "Mô tả:")]
        public string MOTA { get; set; }
        [Display(Name = "Ảnh bìa:")]
        [StringLength(50)]
        public string ANHBIA { get; set; }
        [Display(Name = "Ngày cập nhật:")]
        public DateTime? NGAYCAPNHAT { get; set; }
        [Display(Name = "Số lượng:")]
        public int? SOLUONG { get; set; }

        public int? TRANGTHAI { get; set; }

        public int? MANXB { get; set; }

        public int? MACHUDE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETDONHANG> CHITIETDONHANGs { get; set; }

        public virtual CHUDE CHUDE { get; set; }

        public virtual NHAXUATBAN NHAXUATBAN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<THAMGIA> THAMGIAs { get; set; }
    }
}
