namespace Data_layer.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NHANVIEN")]
    public partial class NHANVIEN
    {
        [Key]
        [StringLength(4)]
        public string MANV { get; set; }

        [StringLength(40)]
        public string TENNV { get; set; }

        [StringLength(20)]
        public string CCCD { get; set; }

        [StringLength(100)]
        public string DIACHI { get; set; }

        [StringLength(10)]
        public string SDT { get; set; }

        [StringLength(50)]
        public string CHUCVU { get; set; }

        [Column(TypeName = "money")]
        public decimal? LUONG { get; set; }

        [StringLength(5)]
        public string GIOITINH { get; set; }
    }
}
