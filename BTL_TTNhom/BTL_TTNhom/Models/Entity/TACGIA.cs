namespace BTL_TTNhom.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TACGIA")]
    public partial class TACGIA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TACGIA()
        {
            THAMGIAs = new HashSet<THAMGIA>();
        }

        [Key]
        public int MATACGIA { get; set; }

        [StringLength(50)]
        public string TENTACGIA { get; set; }

        [StringLength(50)]
        public string DIACHI { get; set; }

        public string TIEUSU { get; set; }

        [StringLength(50)]
        public string DIENTHOAI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<THAMGIA> THAMGIAs { get; set; }
    }
}
