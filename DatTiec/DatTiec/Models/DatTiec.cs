namespace DatTiec.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DatTiec")]
    public partial class DatTiec
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DatTiec()
        {
            CTDatTiecs = new HashSet<CTDatTiec>();
        }

        [Key]
        [StringLength(10)]
        public string iddattiec { get; set; }

        [StringLength(250)]
        public string Hoten { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Ngaydat { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayToChuc { get; set; }

        [StringLength(250)]
        public string DiaChi { get; set; }

        [StringLength(250)]
        public string Dienthoai { get; set; }

        public decimal? Tongsotien { get; set; }

        [StringLength(250)]
        public string Trangthai { get; set; }

        public int? Soluongban { get; set; }

        [StringLength(10)]
        public string Masomenu { get; set; }

        public string GhiChu { get; set; }

        public decimal? Giamenu { get; set; }

        [StringLength(200)]
        public string Tendangnhap { get; set; }

        [StringLength(50)]
        public string ThoiGianToChuc { get; set; }

        [StringLength(10)]
        public string MaKH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTDatTiec> CTDatTiecs { get; set; }
    }
}
