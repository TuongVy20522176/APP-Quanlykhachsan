namespace Data_layer.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TAIKHOAN")]
    public partial class TAIKHOAN
    {
        [Key]
        [StringLength(3)]
        public string MATK { get; set; }

        [StringLength(4)]
        public string MANV { get; set; }

        [StringLength(30)]
        public string TENTK { get; set; }

        [StringLength(30)]
        public string MATKHAU { get; set; }

        [StringLength(30)]
        public string VAITRO { get; set; }
    }
}
