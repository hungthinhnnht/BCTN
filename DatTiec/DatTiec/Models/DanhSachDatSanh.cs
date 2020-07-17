using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatTiec.Models
{
    public class DanhSachDatSanh
    {

        public int IdDatSanh { get; set; }
        public string iddichvu { get; set; }
        public string Tendichvu { get; set; }
        public string Hinhanh { get; set; }
        public DateTime? NgayToChuc { get; set; }
        public string ThoiGianToChuc { get; set; }
        public int? ThanhTien { get; set; }
    }
}