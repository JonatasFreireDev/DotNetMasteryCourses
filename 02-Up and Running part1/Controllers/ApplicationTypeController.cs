using Microsoft.AspNetCore.Mvc;
using Rocky.Data;
using Rocky.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rocky.Controllers
{
    public class ApplicationTypeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ApplicationTypeController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<ApplicationType> obList = _db.ApplicationType;
            return View(obList);
        }

        //Get - Crete
        public IActionResult Create()
        {
            return View();
        }

        //Post - Crete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ApplicationType obj)
        {
            _db.ApplicationType.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Get - Edit
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0) return NotFound();

            var appType = _db.ApplicationType.Find(id);
            if (appType == null) return NotFound();

            return View(appType);
        }

        //Post - Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ApplicationType obj)
        {
            if (!ModelState.IsValid) return View(obj);

            _db.ApplicationType.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


        //Get - Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0) return NotFound();

            var appType = _db.ApplicationType.Find(id);
            if (appType == null) return NotFound();

            return View(appType);
        }

        //Post - Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var appType = _db.ApplicationType.Find(id);
            if (appType == null) return NotFound();

            _db.ApplicationType.Remove(appType);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
