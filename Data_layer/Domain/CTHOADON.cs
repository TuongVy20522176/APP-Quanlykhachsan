namespace Data_layer.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTHOADON")]
    public partial class CTHOADON
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string MACTHD { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(8)]
        public string MAHD { get; set; }

        [StringLength(6)]
        public string NOIDUNG { get; set; }

        public byte? SOLUONG { get; set; }

        [Column(TypeName = "money")]
        public decimal? THANHTIEN { get; set; }
        public virtual HOADON HOADON { get; set; }

        public virtual DICHVU DICHVU { get; set; }
    }
}
