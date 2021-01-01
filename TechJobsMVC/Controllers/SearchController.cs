using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechJobsMVC.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobsMVC.Controllers
{
    public class SearchController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.columns = ListController.ColumnChoices;
            ViewBag.title = "Search";
            return View();
        }

        // TODO #3: Create an action method to process a search request and render the updated search view. 
        public IActionResult Results(string searchType, string searchTerm)
        {
            ViewBag.columns = ListController.ColumnChoices;
            List<Dictionary<string, string>> jobs = new List<Dictionary<string, string>>();

            if(string.IsNullOrEmpty(searchTerm))
            {
                return View("Index");
            }
            if(searchType.Equals("all"))
            {
                jobs = JobData.FindByValue(searchTerm);
                ViewBag.jobs = jobs;
                ViewBag.title = "All Jobs";
                return View("Index");
            }
            else
            {
                jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
                ViewBag.jobs = jobs;
                return View("Index");
            }
        }
    }
}
