namespace DatTiec.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QuangCao")]
    public partial class QuangCao
    {
        [Key]
        [StringLength(10)]
        public string idqc { get; set; }

        [StringLength(200)]
        public string Tenqc { get; set; }

        public DateTime? Ngaybatdau { get; set; }

        public DateTime? Ngayketthuc { get; set; }

        [StringLength(250)]
        public string Hinh { get; set; }

        [StringLength(300)]
        public string Link { get; set; }
    }
}
