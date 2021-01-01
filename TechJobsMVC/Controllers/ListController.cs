
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobsMVC.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobsMVC.Controllers
{
    public class ListController : Controller
    {
        internal static Dictionary<string, string> ColumnChoices = new Dictionary<string, string>()
        static ListController()
        {
            ColumnChoices.Add("all", "All");
            ColumnChoices.Add("employer", "Employer");
            ColumnChoices.Add("location", "Location");
            ColumnChoices.Add("positionType", "Position Type");
            ColumnChoices.Add("coreCompetency", "Skill");
        }

        public IActionResult Index()
        {
            ViewBag.columns = ColumnChoices;
            return View();
        }

        // list jobs by column and value
        public IActionResult Values(string column)
        {
            if (column.ToLower().Equals("all"))
            {
                List<Dictionary<string, string>> jobs = JobData.FindAll();
                ViewBag.title = "All Jobs";
                ViewBag.jobs = jobs;
                return View("Jobs");
            }
            else
            {
                List<string> items = JobData.FindAll(column);
                ViewBag.title = "All " + ColumnChoices[column] + ": " + "Values";
                ViewBag.column = column;
                ViewBag.items = items;
                return View("Jobs");
                }
            }

            public IActionResult Jobs(string column, string value)
        {
            List<Dictionary<String, String>> jobs = JobData.FindByColumnAndValue(column, value);
            ViewBag.title = "Jobs with " + ColumnChoices[column] + ":" + value;
            ViewBag.jobs = jobs;
            return View();
        }
    }
}

