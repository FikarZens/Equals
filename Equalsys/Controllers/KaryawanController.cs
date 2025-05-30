using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Equalsys.Models;

namespace Equalsys.Controllers
{
    public class KaryawanController : Controller
    {
        private EqualsysEntities1 db = new EqualsysEntities1();
        // GET: Karyawan
        public ActionResult Index()
        {
            var res = db.Tbl_Karyawan.ToList();
            return View(res);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Error = null;
            ViewBag.Valid = null;
            ReploadDropDown();

            return View();
        }

        [HttpPost]
        public ActionResult Create(Tbl_Karyawan obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Tbl_Karyawan.Add(obj);
                    db.SaveChanges();
                    ViewBag.Valid = "Data Berhasil di simpan";

                    return RedirectToAction("Index");
                }
            }
            catch (Exception e) {
                ViewBag.Error = e.Message.ToString();
            }

            return View(obj);
        }

        public ActionResult Edit(long id) {
            Tbl_Karyawan model = new Tbl_Karyawan();
            model = db.Tbl_Karyawan.Where(x => x.Id == id).FirstOrDefault();
            ReploadDropDown();

            return View(model);
        }
        
        [HttpPost]
        public ActionResult Edit(Tbl_Karyawan obj) {
            try {
                if (ModelState.IsValid) {

                    db.Entry(obj).State = EntityState.Modified;
                    db.SaveChanges();
                    ViewBag.valid = "Data Berhasil di Ubah";

                    return RedirectToAction("Index");

                }
            }
            catch (Exception e) {
                ViewBag.Error = e.Message.ToString();
            }
            return View(obj);
        }

        public ActionResult Details(long Id) {
            Tbl_Karyawan model = new Tbl_Karyawan();
            model = db.Tbl_Karyawan.Where(x => x.Id == Id).FirstOrDefault();

            return View(model);
        }


        public void ReploadDropDown()
        {
            ViewBag.Pekerjaan = this.ListPekerjaan();
        }

        public List<SelectListItem> ListPekerjaan()
        {
            List<SelectListItem> myPekerjaan = new List<SelectListItem>();

            var dataPekerjaan = db.Tbl_Pekerjaan.Where(x => x.Status == "Aktif").ToList();
            foreach (var item in dataPekerjaan)
            {
                myPekerjaan.Add(new SelectListItem
                {
                    Text = item.NamaPekerjaan,
                    Value = item.NamaPekerjaan
                });
            }

            return myPekerjaan;
        }
    }
}