using Microsoft.AspNetCore.Mvc;
using MVC.Data;
using MVC.Models;

namespace MVC.Controllers
{
    public class ProjectController : Controller
    {
        private readonly ApplicationContext _db;

        public ProjectController(ApplicationContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Project> objProjectList = _db.Projects;
            return View(objProjectList);
        }
        //Панель управления рабочими
        public IActionResult Create()
        {
            IEnumerable<CompanyCustomer> companyCust = _db.Company_customers.ToList();
            ViewBag.CompanyCust = companyCust;

            IEnumerable<CompanyExecutor> companyExe = _db.Company_executors.ToList();
            ViewBag.CompanyExe = companyExe;

            IEnumerable<Worker> workers = _db.Workers.ToList();
            ViewBag.Worker = workers;

            return View();
        }

        //Панель создания новых рабочих
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Project project)
        {

            IEnumerable<CompanyCustomer> companyCust = _db.Company_customers.ToList();
            ViewBag.CompanyCust = companyCust;

            IEnumerable<CompanyExecutor> companyExe = _db.Company_executors.ToList();
            ViewBag.CompanyExe = companyExe;

            IEnumerable<Worker> workers = _db.Workers.ToList();
            ViewBag.Worker = workers;

            if (ModelState.IsValid)
            {
                _db.Projects.Add(project);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(project);
        }

        public IActionResult Edit(int? id)
        {

            IEnumerable<CompanyCustomer> companyCust = _db.Company_customers.ToList();
            ViewBag.CompanyCust = companyCust;

            IEnumerable<CompanyExecutor> companyExe = _db.Company_executors.ToList();
            ViewBag.CompanyExe = companyExe;

            IEnumerable<Worker> workers = _db.Workers.ToList();
            ViewBag.Worker = workers;

            if (id == null || id == 0) return NotFound();
            var projectFromDb = _db.Projects.Find(id);

            if (projectFromDb == null) return NotFound();

            return View(projectFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Project project)
        {
            IEnumerable<CompanyCustomer> companyCust = _db.Company_customers.ToList();
            ViewBag.CompanyCust = companyCust;

            IEnumerable<CompanyExecutor> companyExe = _db.Company_executors.ToList();
            ViewBag.CompanyExe = companyExe;

            IEnumerable<Worker> workers = _db.Workers.ToList();
            ViewBag.Worker = workers;

            if (ModelState.IsValid)
            {
                _db.Projects.Update(project);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(project);
        }

        public IActionResult Delete(int? id)
        {

            IEnumerable<CompanyCustomer> companyCust = _db.Company_customers.ToList();
            ViewBag.CompanyCust = companyCust;

            IEnumerable<CompanyExecutor> companyExe = _db.Company_executors.ToList();
            ViewBag.CompanyExe = companyExe;

            IEnumerable<Worker> workers = _db.Workers.ToList();
            ViewBag.Worker = workers;

            if (id == null || id == 0) return NotFound();
            var projectFromDb = _db.Projects.Find(id);

            if (projectFromDb == null) return NotFound();

            return View(projectFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {

            IEnumerable<CompanyCustomer> companyCust = _db.Company_customers.ToList();
            ViewBag.CompanyCust = companyCust;

            IEnumerable<CompanyExecutor> companyExe = _db.Company_executors.ToList();
            ViewBag.CompanyExe = companyExe;

            IEnumerable<Worker> workers = _db.Workers.ToList();
            ViewBag.Worker = workers;

            var projectFromDb = _db.Projects.Find(id);

            if (projectFromDb == null) return NotFound();

            _db.Projects.Remove(projectFromDb);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public IActionResult ViewWorkers(string name)
        {
            IEnumerable<WorkerProject> workerProjects = _db.Workers_projects.Where(n => n.Name_project == name);
            ViewData["name"] = name;
            return View(workerProjects);
        }

        //Панель управления рабочими
        public IActionResult AddWorker(string name)
        {

            IEnumerable<Worker> workers = _db.Workers.ToList();
            ViewBag.Worker = workers;

            ViewData["name"] = name;

            return View();
        }

        //Панель создания новых рабочих
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddWorker(WorkerProject workerProject, string name)
        {
            IEnumerable<WorkerProject> workersP = _db.Workers_projects.Where(n => n.Name_project == name);

            IEnumerable<Worker> workers = _db.Workers;

            ViewBag.Worker = workers;

            ViewData["name"] = name;

            if (ModelState.IsValid)
            {
                _db.Workers_projects.Add(workerProject);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(workerProject);
        }

        public IActionResult DeleteWorker(int? id)
        {

            IEnumerable<Worker> workers = _db.Workers.ToList();
            ViewBag.Worker = workers;

            if (id == null || id == 0) return NotFound();
            var workerPFromDb = _db.Workers_projects.Find(id);

            if (workerPFromDb == null) return NotFound();

            return View(workerPFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteWorkerPOST(int? id)
        {
            IEnumerable<Worker> workers = _db.Workers.ToList();
            ViewBag.Worker = workers;

            var workerPFromDb = _db.Workers_projects.Find(id);

            if (workerPFromDb == null) return NotFound();

            _db.Workers_projects.Remove(workerPFromDb);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Sort(int sortid)
        {
            switch (sortid)
            {
                case 0:
                    {
                        IEnumerable<Project> projects = _db.Projects;
                        IEnumerable<Project> projectSort = from p in projects orderby p.Priority select p;
                        return View(projectSort);
                    }

                case 1:
                    {
                        IEnumerable<Project> projects = _db.Projects;
                        IEnumerable<Project> projectSort = from p in projects orderby p.Priority descending select p;
                        return View(projectSort);
                    }

                case 2:
                    {
                        IEnumerable<Project> projects = _db.Projects;
                        IEnumerable<Project> projectSort = from p in projects orderby p.Date_start select p;
                        return View(projectSort);
                    }

                case 3:
                    {
                        IEnumerable<Project> projects = _db.Projects;
                        IEnumerable<Project> projectSort = from p in projects orderby p.Date_start descending select p;
                        return View(projectSort);
                    }

                case 4:
                    {
                        IEnumerable<Project> projects = _db.Projects;
                        IEnumerable<Project> projectSort = from p in projects orderby p.Date_end select p;
                        return View(projectSort);
                    }

                case 5:
                    {
                        IEnumerable<Project> projects = _db.Projects;
                        IEnumerable<Project> projectSort = from p in projects orderby p.Date_end descending select p;
                        return View(projectSort);
                    }
            }
            IEnumerable<Project> pj = _db.Projects;
            return View(pj);
        }
        
        [HttpPost]
        public IActionResult Serch(string parameterName, string parameter)
        {
            IEnumerable<Project> projects = _db.Projects.Where(p => p.Name == parameter);
            return View(projects);
        }

    }
}
