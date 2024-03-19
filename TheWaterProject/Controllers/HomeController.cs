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

        public IActionResult Index(int pageNum)
        {
            int pageSize = 5;
            var blah = new ProjectsListViewModel
            {
                Projects = _waterrepo.Projects
                .OrderBy(x => x.projectName)
                .Skip(pageSize * (pageNum - 1))
                .Take(pageSize),

                PaginationInfo = new PaginationInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = pageSize,
                    TotalItems = _waterrepo.Projects.Count()
                }
            };


            return View(blah);
        }
    }
}
