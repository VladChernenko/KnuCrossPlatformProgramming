using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Lab5PreviousTasks;

namespace Lab5WebApp.Controllers
{
    public class Labs : Controller
    {

        [Authorize]
        public IActionResult Lab1()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public string Lab1(string input_file,string output_file) => Lab5PreviousTasks.Lab1.Lab1Execution(input_file, output_file);
        

        [Authorize]
        public IActionResult Lab2()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public string Lab2(string input_file, string output_file) => Lab5PreviousTasks.Lab2.Lab2Execution(input_file, output_file);


        [Authorize]
        public IActionResult Lab3()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public string Lab3(string input_file, string output_file) => Lab5PreviousTasks.Lab3.Lab3Execution(input_file, output_file);
       
    }
}
