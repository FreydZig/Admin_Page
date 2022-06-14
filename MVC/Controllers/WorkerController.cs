using Microsoft.AspNetCore.Mvc;
using MVC.Data;
using MVC.Models;

namespace MVC.Controllers
{
    public class WorkerController : Controller
    {

        private readonly ApplicationContext _db;

        public WorkerController(ApplicationContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Worker> objWorkerList = _db.Workers;
            return View(objWorkerList);
        }
        //Панель управления рабочими
        public IActionResult Create()
        {
            return View();
        }

        //Панель создания новых рабочих
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Worker worker)
        {
            if (ModelState.IsValid)
            {
                _db.Workers.Add(worker);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(worker);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0) return NotFound();
            var workerFromDb = _db.Workers.Find(id);
            //var workerFromDbFirst =_db.Workers.FirstOrDefault(u=>u.Id == id);
            //var workerFromDbSingl = _db.Workers.SingleOrDefault(u => u.Id == id);

            if (workerFromDb == null) return NotFound();

            return View(workerFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Worker worker)
        {
            if (ModelState.IsValid)
            {
                _db.Workers.Update(worker);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(worker);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0) return NotFound();
            var workerFromDb = _db.Workers.Find(id);
            //var workerFromDbFirst =_db.Workers.FirstOrDefault(u=>u.Id == id);
            //var workerFromDbSingl = _db.Workers.SingleOrDefault(u => u.Id == id);

            if (workerFromDb == null) return NotFound();

            return View(workerFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Workers.Find(id);

            if(obj == null) return NotFound();

                _db.Workers.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
        }
    }
}
