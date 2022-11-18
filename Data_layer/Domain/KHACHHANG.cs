namespace Data_layer.Domain
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
            HOADONs = new HashSet<HOADON>();
            KHACHHANG_PHONG = new HashSet<KHACHHANG_PHONG>();
        }

        [Key]
        [StringLength(6)]
        public string MAKH { get; set; }

        [StringLength(40)]
        public string TENKH { get; set; }

        [StringLength(100)]
        public string DIACHI { get; set; }

        [StringLength(5)]
        public string GIOITINH { get; set; }

        [StringLength(40)]
        public string QUOCTICH { get; set; }

        [StringLength(20)]
        public string CCCD { get; set; }

        [StringLength(15)]
        public string SODT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOADON> HOADONs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KHACHHANG_PHONG> KHACHHANG_PHONG { get; set; }
    }
}
