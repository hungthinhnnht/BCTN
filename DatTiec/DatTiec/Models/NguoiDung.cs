namespace DatTiec.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NguoiDung")]
    public partial class NguoiDung
    {
        [Key]
        [StringLength(200)]
        public string Tendn { get; set; }

        [StringLength(50)]
        public string Matkhau { get; set; }

        [StringLength(250)]
        public string Hoten { get; set; }

        [StringLength(200)]
        public string Email { get; set; }

        public bool? Trangthai { get; set; }

        public bool? Quyen { get; set; }
    }
}
