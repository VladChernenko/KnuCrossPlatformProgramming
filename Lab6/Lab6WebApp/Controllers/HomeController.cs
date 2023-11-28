using Microsoft.AspNetCore.Mvc;


namespace Lab6WebApp.Controllers
{
    public class HomeController : Controller
    {


        public IActionResult Index()
        {
            return View();
        }

        public async Task BlaBlaBla()
        {

            string apiUrl = "http://localhost:5109/WeatherForecast";

            HttpClient httpClient = new HttpClient();


            HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

            string jsonResult = await response.Content.ReadAsStringAsync();

            await Response.WriteAsync(jsonResult);

        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
