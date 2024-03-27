using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TheWaterProject.Models;
using TheWaterProject.Models.ViewModels;

namespace TheWaterProject.Controllers
{
    public class HomeController : Controller
    {
        public IWaterRepository _waterrepo;
        public HomeController(IWaterRepository temp) 
        {
            _waterrepo = temp;
        }

        public IActionResult Index(int pageNum, string? projectType)
        {
            int pageSize = 5;
            var blah = new ProjectsListViewModel
            {
                Projects = _waterrepo.Projects
                //Where projectType = projectType OR projectType is true (the null statement)
                .Where(x => x.projectType == projectType || projectType == null)
                .OrderBy(x => x.projectName)
                .Skip(pageSize * (pageNum - 1))
                .Take(pageSize),

                PaginationInfo = new PaginationInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = pageSize,
                    TotalItems = projectType == null ? _waterrepo.Projects.Count() : _waterrepo.Projects.Where(x=>x.projectType == projectType).Count()
                },
                CurrentProjectType = projectType
            };


            return View(blah);
        }
    }
}
