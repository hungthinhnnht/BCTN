namespace DatTiec.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTDatTiec")]
    public partial class CTDatTiec
    {
        [Key]
        [StringLength(10)]
        public string idct { get; set; }

        [StringLength(10)]
        public string iddattiec { get; set; }

        [StringLength(10)]
        public string idmonan { get; set; }

        [StringLength(10)]
        public string iddichvu { get; set; }

        [StringLength(200)]
        public string Soluong { get; set; }

        public decimal? Gia { get; set; }

        public virtual DatTiec DatTiec { get; set; }
    }
}
