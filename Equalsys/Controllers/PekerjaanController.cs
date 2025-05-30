using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Equalsys.Models;

namespace Equalsys.Controllers
{
    public class PekerjaanController : Controller
    {
        private EqualsysEntities1 db = new EqualsysEntities1();
        private readonly EqualsysEntities1 equalsysEntities1 ;

        // GET: Personal
        public ActionResult Index()
        {
            var res = db.Tbl_Pekerjaan.ToList();
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
        public ActionResult Create(Tbl_Pekerjaan obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Tbl_Pekerjaan.Add(obj);
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
            Tbl_Pekerjaan model = new Tbl_Pekerjaan();
            model = db.Tbl_Pekerjaan.Where(x => x.Id == id).FirstOrDefault();
            ReploadDropDown();

            return View(model);
        }
        
        [HttpPost]
        public ActionResult Edit(Tbl_Pekerjaan obj) {
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

        public ActionResult Details(long Id)
        {
            Tbl_Pekerjaan model = new Tbl_Pekerjaan();
            model = db.Tbl_Pekerjaan.Where(x => x.Id == Id).FirstOrDefault();
            ReploadDropDown();

            return View(model);
        }


        public void ReploadDropDown()
        {
            ViewBag.Status = this.ListStatus();
        }

        public List<SelectListItem> ListStatus()
        {
            List<SelectListItem> myStatus = new List<SelectListItem>();

            var dataStatus = db.Tbl_Pekerjaan.ToList();
            myStatus.Add(new SelectListItem
            {
                Text = "Aktif",
                Value = "Aktif"
            });

            myStatus.Add(new SelectListItem
            {
                Text = "Inaktif",
                Value = "Inaktif"
            });

            return myStatus;
        }
    }
}