using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechJobsMVC.Data;
using TechJobsMVC.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobsMVC.Controllers
{
    public class SearchController : Controller
    {
        // GET: /<controller>/
        [HttpGet]
        [Route("search")]
        public IActionResult Index()
        {
            ViewBag.columns = ListController.ColumnChoices;
            ViewBag.condition = false;
            return View();
        }

        // TODO #3: Create an action method to process a search request and render the updated search view. 

        [HttpPost]
        [Route("search")]
        public IActionResult Index(string searchType, string searchTerm)
        {
            ViewBag.searchType = searchType;
            ViewBag.condition = false;
            List<Job> jobs = new List<Job>();
            if(searchTerm == null || searchTerm == "")
            {
                jobs = JobData.FindAll();
            }
            else
            {
                jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
            }

            if (jobs.Count >= 0)
            {
                ViewBag.condition = true;
            }
            ViewBag.jobs = jobs;
            ViewBag.columns = ListController.ColumnChoices;
            return View();
        }
    }
}
