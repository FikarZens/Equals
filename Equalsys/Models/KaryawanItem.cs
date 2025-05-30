using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Equalsys.Models
{
    public class KaryawanItem
    {
        public string NamaDepan { get; set; }
        public string NamaTengah { get; set; }
        public string NamaBelakang { get; set; }
        public DateTime TanggalLahir { get; set; }
        public string JenisKelamin { get; set; }
        public string Alamat { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public string Pekerjaan { get; set; }
    }
}