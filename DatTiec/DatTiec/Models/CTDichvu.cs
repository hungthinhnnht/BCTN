namespace DatTiec.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTDichvu")]
    public partial class CTDichvu
    {
        [Key]
        [StringLength(10)]
        public string idChiTiet { get; set; }

        [StringLength(10)]
        public string iddichvu { get; set; }

        [StringLength(250)]
        public string Hinhanh { get; set; }

        public string MoTa { get; set; }

        public bool? Trangthai { get; set; }

        [StringLength(50)]
        public string Gia { get; set; }

        public virtual Dichvu Dichvu { get; set; }
    }
}
