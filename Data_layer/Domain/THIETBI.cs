namespace Data_layer.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("THIETBI")]
    public partial class THIETBI
    {
        [Key]
        [StringLength(4)]
        public string MATB { get; set; }

        [StringLength(200)]
        public string TENTB { get; set; }

        [Column(TypeName = "money")]
        public decimal? GIATRI { get; set; }
    }
}
