using Microsoft.AspNetCore.Mvc;
using MVC.Data;
using MVC.Models;

namespace MVC.Controllers
{
    public class CompanyCustomerController : Controller
    {

        private readonly ApplicationContext _db;

        public CompanyCustomerController(ApplicationContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<CompanyCustomer> CompanyCustomer = _db.Company_customers;
            return View(CompanyCustomer);
        }
        //Панель управления рабочими
        public IActionResult Create()
        {
            return View();
        }

        //Панель создания новых рабочих
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CompanyCustomer companyCust)
        {
            if (ModelState.IsValid)
            {
                _db.Company_customers.Add(companyCust);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(companyCust);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0) return NotFound();

            var companyCustFromDb = _db.Company_customers.Find(id);

            if (companyCustFromDb == null) return NotFound();

            return View(companyCustFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CompanyCustomer companyCust)
        {
            if (ModelState.IsValid)
            {
                _db.Company_customers.Update(companyCust);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(companyCust);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0) return NotFound();
            var companyCustFromDb = _db.Company_customers.Find(id);

            if (companyCustFromDb == null) return NotFound();

            return View(companyCustFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Company_customers.Find(id);

            if (obj == null) return NotFound();

            _db.Company_customers.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
