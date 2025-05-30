using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Equalsys.Models
{
    public class PekerjaanItem
    {
        public string NamaPekerjaan { get; set; }
        public DateTime TanggalMulai { get; set; }
        public DateTime TanggalTanggalBerakhirLahir { get; set; }
        public decimal Gaji { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}