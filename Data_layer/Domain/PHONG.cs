namespace Data_layer.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHONG")]
    public partial class PHONG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHONG()
        {
            HOADONs = new HashSet<HOADON>();
            KHACHHANG_PHONG = new HashSet<KHACHHANG_PHONG>();
        }

        [Key]
        [StringLength(4)]
        public string MAPHONG { get; set; }

        [StringLength(4)]
        public string LOAIPHONG { get; set; }

        [StringLength(20)]
        public string TINHTRANG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOADON> HOADONs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KHACHHANG_PHONG> KHACHHANG_PHONG { get; set; }

        public virtual LOAIPHONG LOAIPHONG1 { get; set; }
    }
}
