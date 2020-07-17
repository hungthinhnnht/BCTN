namespace DatTiec.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Menusan")]
    public partial class Menusan
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public Menusan()
        //{
        //    CTMenus = new HashSet<CTMenu>();
        //}

        [Key]
        [StringLength(10)]
        public string Masomenu { get; set; }

        [StringLength(250)]
        public string Tengoi { get; set; }

        public decimal? Gia { get; set; }

        public bool? Trangthai { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<CTMenu> CTMenus { get; set; }
    }
}
