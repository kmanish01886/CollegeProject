using CollegeProject.Models;
using CrudEFbyMigration.Data;
using Microsoft.AspNetCore.Mvc;

namespace CollegeProject.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly ApplicationDbContext dbContext;
        public EmployeeController(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public IActionResult Index()
        {
            List<Designation> lst = dbContext.Designations.ToList();
            return View(lst);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Designation model)
        {
           
            if (model!=null)
            {
                dbContext.Designations.Add(model);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
           
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var del = await dbContext.Employees.SingleOrDefaultAsync(x => x.Id == id);
                dbContext.Employees.Remove(del);
                await dbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpGet]
        public async Task<IActionResult> Update(int Id)
        {
            try
            {
                var emp = await dbContext.Employees.SingleOrDefaultAsync(x => x.Id == Id);
                return View(emp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public IActionResult Update(Employee model)
        {
            var files = Request.Form.Files;
            string dbpath = string.Empty;
            if (files.Count > 0)
            {
                string Image = webHostEnvironment.WebRootPath;
                string fullpath = Path.Combine(Image + "\\Image", files[0].FileName);
                dbpath = "Image/" + files[0].FileName;
                FileStream stream = new FileStream(fullpath, FileMode.Create);
                files[0].CopyTo(stream);
            }
            model.Image = dbpath;
            dbContext.Employees.Update(model);
            dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));

        }
    }
}
