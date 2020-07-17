namespace DatTiec.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTMenu")]
    public partial class CTMenu
    {
        public int id { get; set; }

        [StringLength(10)]
        public string Masomenu { get; set; }

        [StringLength(10)]
        public string idmonan { get; set; }

        public virtual Menusan Menusan { get; set; }
    }
}
