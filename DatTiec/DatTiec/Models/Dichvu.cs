namespace DatTiec.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Dichvu")]
    public partial class Dichvu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Dichvu()
        {
            CTDichvus = new HashSet<CTDichvu>();
        }

        [Key]
        [StringLength(10)]
        public string iddichvu { get; set; }

        [StringLength(200)]
        public string Tendichvu { get; set; }

        [StringLength(10)]
        public string idloai { get; set; }

        [StringLength(250)]
        public string Hinhanh { get; set; }

        public decimal? Gia { get; set; }

        public string Mota { get; set; }

        public bool? Trangthai { get; set; }

        public bool? BatBuoc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTDichvu> CTDichvus { get; set; }

        public virtual loaiDichVu loaiDichVu { get; set; }
    }
}
