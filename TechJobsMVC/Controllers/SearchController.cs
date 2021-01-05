using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobsMVC.Models;
using TechJobsMVC.Data;

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
            List<Job> jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
            if (string.IsNullOrEmpty(searchTerm))
            {
                return View("Index");
            }
            if (searchType.Equals("all"))
            {
                jobs = JobData.FindByValue(searchTerm);
                ViewBag.jobs = jobs;
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
