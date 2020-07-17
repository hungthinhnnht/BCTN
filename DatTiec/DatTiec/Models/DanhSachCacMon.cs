using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatTiec.Models
{
    public class DanhSachCacMon
    {
        public string idmonan { get; set; }
        public string Tenmon { get; set; }
        public Nullable<decimal> Gia { get; set; }
        public string Tenloai { get; set; }
    }
}
