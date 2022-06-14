using Microsoft.AspNetCore.Mvc;
using MVC.Data;
using MVC.Models;

namespace MVC.Controllers
{
    public class CompanyExecutorController : Controller
    {
        private readonly ApplicationContext _db;

        public CompanyExecutorController(ApplicationContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<CompanyExecutor> CompanyExecutor = _db.Company_executors;
            return View(CompanyExecutor);
        }
        //Панель управления рабочими
        public IActionResult Create()
        {
            return View();
        }

        //Панель создания новых рабочих
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CompanyExecutor companyExe)
        {
            if (ModelState.IsValid)
            {
                _db.Company_executors.Add(companyExe);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(companyExe);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0) return NotFound();

            var companyExeFromDb = _db.Company_executors.Find(id);

            if (companyExeFromDb == null) return NotFound();

            return View(companyExeFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CompanyExecutor companyExe)
        {
            if (ModelState.IsValid)
            {
                _db.Company_executors.Update(companyExe);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(companyExe);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0) return NotFound();
            var companyExeFromDb = _db.Company_executors.Find(id);

            if (companyExeFromDb == null) return NotFound();

            return View(companyExeFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Company_executors.Find(id);

            if (obj == null) return NotFound();

            _db.Company_executors.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
