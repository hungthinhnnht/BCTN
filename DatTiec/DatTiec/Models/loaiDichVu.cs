namespace DatTiec.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("loaiDichVu")]
    public partial class loaiDichVu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public loaiDichVu()
        {
            Dichvus = new HashSet<Dichvu>();
        }

        [Key]
        [StringLength(10)]
        public string idloai { get; set; }

        [StringLength(200)]
        public string Tenloai { get; set; }

        public bool? TrangThai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dichvu> Dichvus { get; set; }
    }
}
