namespace DatTiec.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhachHang")]
    public partial class KhachHang
    {
        [Key]
        [StringLength(10)]
        public string MaKH { get; set; }

        [StringLength(250)]
        public string Hoten { get; set; }

        [StringLength(50)]
        public string Tendangnhap { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string MatKhau { get; set; }

        [StringLength(250)]
        public string Diachi { get; set; }

        [StringLength(250)]
        public string Dienthoai { get; set; }
    }
}
