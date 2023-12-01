using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Lab6WebApp.Controllers
{
    public class HomeController : Controller
    {


        public IActionResult Index()
        {
            return View();
        }


        [Authorize]
        public IActionResult Swagger()
        {
            return Redirect("http://localhost:5109/swagger/index.html");
        }



        public IActionResult Error()
        {
            return View();
        }
    }
}
