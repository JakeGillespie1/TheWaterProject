using Microsoft.AspNetCore.Mvc;
using TheWaterProject.Models;

namespace TheWaterProject.Components
{
    public class ProjectTypesViewComponent : ViewComponent
    {
        private IWaterRepository _waterRepository;
        public ProjectTypesViewComponent(IWaterRepository temp) 
        { 
                _waterRepository = temp;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedProjectType = RouteData?.Values["projectType"]; 

            var projectTypes = _waterRepository.Projects
                .Select(x => x.projectType)
                .Distinct()
                .OrderBy(x => x);

            return View(projectTypes);
        }
    }
}
