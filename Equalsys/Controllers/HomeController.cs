using System;
using System.Collections.Generic;
using Equalsys.Models;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Equalsys.Controllers
{
    public class HomeController : Controller
    {
        private EqualsysEntities1 db = new EqualsysEntities1();
        public ActionResult Index()
        {
            List<Tbl_Karyawan> model = new List<Tbl_Karyawan>();
            model = db.Tbl_Karyawan.ToList();
            
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}