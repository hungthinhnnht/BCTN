namespace DatTiec.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DatSanh")]
    public partial class DatSanh
    {
        [Key]
        public int IdDatSanh { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayToChuc { get; set; }

        [StringLength(50)]
        public string ThoiGianToChuc { get; set; }

        public string DiaChi { get; set; }

        public string GhiChu { get; set; }

        [StringLength(10)]
        public string MaKH { get; set; }

        [StringLength(10)]
        public string IdDichVu { get; set; }

        public int? ThanhTien { get; set; }
    }
}
