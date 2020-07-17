namespace DatTiec.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MonAn")]
    public partial class MonAn
    {
        [Key]
        [StringLength(10)]
        public string idmonan { get; set; }

        [StringLength(10)]
        public string idloaimon { get; set; }

        [StringLength(250)]
        public string Tenmon { get; set; }

        [StringLength(250)]
        public string Hinhanh { get; set; }

        public decimal? Gia { get; set; }

        public string Mota { get; set; }

        public bool? Trangthai { get; set; }

        public virtual LoaiMon LoaiMon { get; set; }
    }
}
