using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC_Start.Models;

namespace MVC_Start.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(int id)
        {
            return View();
        }

        public IActionResult IndexWithLayout()
        {
            return View();
        }

        public IActionResult Contact()
        {
            TempData["name"] = "ISM 6225";

            GuestContact contact = new GuestContact();

            contact.Name = "Manish Agrawal";
            contact.Email = "magrawal@usf.edu";
            contact.Phone = "813-974-6716";


            /* alternate syntax to initialize object 
            GuestContact contact2 = new GuestContact
            {
              Name = "Manish Agrawal",
              Email = "magrawal@usf.edu",
              Phone = "813-974-6716"
            };
            */

            //ViewData["Message"] = "Your contact page.";

            return View(contact);
        }

        [HttpPost]
        public IActionResult Contact(GuestContact contact)
        {
            string name = TempData["name"].ToString();

            return View(contact);
        }

        /// <summary>
        /// Replicate the chart example in the JavaScript presentation
        /// 
        /// Typically LINQ and SQL return data as collections.
        /// Hence we start the example by creating collections representing the x-axis labels and the y-axis values
        /// However, chart.js expects data as a string, not as a collection.
        ///   Hence we join the elements in the collections into strings in the view model
        /// </summary>
        /// <returns>View that will display the chart</returns>
        public ViewResult DemoChart()
        {
            string[] ChartLabels = new string[] { "Africa", "Asia", "Europe", "Latin America", "North America" };
            int[] ChartData = new int[] { 2478, 5267, 734, 784, 433 };

            ChartModel Model = new ChartModel
            {
                ChartType = "bar",
                Labels = String.Join(",", ChartLabels.Select(d => "'" + d + "'")),
                Data = String.Join(",", ChartData.Select(d => d)),
                Title = "Predicted world population (millions) in 2050"
            };

            return View(Model);
        }
    }
}