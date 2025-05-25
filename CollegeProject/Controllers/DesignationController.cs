using CollegeProject.Models;
using CrudEFbyMigration.Data;
using Microsoft.AspNetCore.Mvc;

namespace CollegeProject.Controllers
{
    public class DesignationController : Controller
    {

        private readonly ApplicationDbContext dbContext;
        public DesignationController(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public async Task<IActionResult> Index()
        {
            List<Designation> lst = dbContext.Designations.ToList();
            return View(lst);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(DesignationVM Vm)
        {
            if (Vm != null)
            {
                var model = new Designation
                {
                    CollegeName = Vm.CollegeName,
                    DesignationCode = Vm.DesignationCode,
                    DesignationAcronym = Vm.DesignationAcronym,
                    DesignationName = Vm.DesignationName,
                    Stream = Vm.Stream,
                    RolesandResponsability=Vm.RolesandResponsability
                };
                await dbContext.AddAsync(model);
            }
            return RedirectToAction("Index");
        }





    }
}
