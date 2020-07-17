namespace DatTiec.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TuVan")]
    public partial class TuVan
    {
        [Key]
        [StringLength(10)]
        public string IdTuVan { get; set; }
     
        [StringLength(250)]
        public string Hoten { get; set; }

        [StringLength(200)]
        public string Email { get; set; }

        [StringLength(250)]
        public string Dienthoai { get; set; }

        [StringLength(250)]
        public string Loinhan { get; set; }
    }
}
