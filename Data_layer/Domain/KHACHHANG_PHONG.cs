namespace Data_layer.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class KHACHHANG_PHONG
    {
        [Key]
        [StringLength(6)]
        public string MAKH_P { get; set; }

        [StringLength(6)]
        public string MAKH { get; set; }

        [StringLength(4)]
        public string MAPHONG { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? NGAYTHUE { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? NGAYTRA { get; set; }

        [Column(TypeName = "money")]
        public decimal? GIATHUE { get; set; }

        [StringLength(20)]
        public string TINHTRANG { get; set; }

        public byte? SONGUOI { get; set; }

        public virtual KHACHHANG KHACHHANG { get; set; }

        public virtual PHONG PHONG { get; set; }
    }
}
