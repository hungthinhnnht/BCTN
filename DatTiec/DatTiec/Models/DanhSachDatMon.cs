using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatTiec.Models
{
    public class DanhSachDatMon
    {

        public int IdDatMon { get; set; }
        public string idmonan { get; set; }
        public string Tenmon { get; set; }
        public string Hinhanh { get; set; }
        public DateTime? NgayToChuc { get; set; }
        public string ThoiGianToChuc { get; set; }
        public int? ThanhTien { get; set; }
    }
}