namespace DatTiec.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TinTuc")]
    public partial class TinTuc
    {
        [Key]
        [StringLength(10)]
        public string idtin { get; set; }

        [StringLength(200)]
        public string Tieude { get; set; }

        public DateTime? Ngaydang { get; set; }

        public string Noidung { get; set; }

        [StringLength(250)]
        public string Hinh { get; set; }

        public bool? Trangthai { get; set; }

        [StringLength(600)]
        public string Tomtat { get; set; }

        [StringLength(50)]
        public string Luotxem { get; set; }
    }
}
