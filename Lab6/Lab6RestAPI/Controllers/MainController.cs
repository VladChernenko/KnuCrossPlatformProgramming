using Lab6RestAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab6RestAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MainController : ControllerBase
    {

        //_____________________ Роути для перегляду 2 каталогів(список) _____________________

        [HttpGet("GetCustomerItemRental")]
        public IEnumerable<CustomerItemRental> GetCustomerItemRental()
        {
            return DbWrapper.db.CustomerItemRentals.Include(a=>a.Customer).Include(a=>a.Inventory).ToArray();

        }

        [HttpGet("GetCustomerGameRental")]
        public IEnumerable<CustomerGameRentals> GetCustomerGameRental()
        {
            return DbWrapper.db.CustomerGameRentals.Include(a => a.Customer).Include(a => a.Game).ToArray();

        }

        //_____________________ Роути для перегляду 2 каталогів(поелементно) _____________________

        [HttpGet("GetCustomerItemRental/{id}")]
        public ActionResult<CustomerItemRental> GetCustomerItemRentalByID(int id)
        {
            return DbWrapper.db.CustomerItemRentals.Include(a => a.Customer).Include(a => a.Inventory).FirstOrDefault(a => a.Id == id);

        }

        [HttpGet("GetCustomerGameRental/{id}")]
        public ActionResult<CustomerGameRentals> GetCustomerGameRentalByID(int id)
        {

            return DbWrapper.db.CustomerGameRentals.Include(a => a.Customer).Include(a => a.Game).FirstOrDefault(a => a.Id == id);

        }

        //________________ Роути для перегляду 2 центральних таблиць(список) ________________


        [HttpGet("GetGames")]
        public IEnumerable<Game> GetGames() => DbWrapper.db.Games.ToArray();

        [HttpGet("GetMovies")]
        public IEnumerable<Movie> GetMovies() => DbWrapper.db.Movies.ToArray();


        //________________ Роути для перегляду 2 центральних таблиць(поелементно) ________________


        [HttpGet("GetGames/{id}")]
        public ActionResult<Game> GetGameByID(int id) => DbWrapper.db.Games.FirstOrDefault(a => a.Id == id);


        [HttpGet("GetMovies/{id}")]
        public ActionResult<Movie> GetMovieByID(int id) => DbWrapper.db.Movies.FirstOrDefault(a => a.Id == id);


        //________________ Сторінка пошуку ________________

        // Запит за часом & датою
        [HttpGet("SearchForGameRentalsByDate")]
        public IEnumerable<CustomerGameRentals> GetCustomerGameRentalByDate([FromQuery] string datetime)
        {

            return DateTime.TryParse(datetime, out DateTime date)
            ?
            DbWrapper.db.CustomerGameRentals.Include(a => a.Customer).Include(a => a.Game).Where(a => a.DateReturned == date)
            :
            Enumerable.Empty<CustomerGameRentals>();


        }


        // Запит лише деякого набору записів
        [HttpGet("SearchForSeveralGameRentals")]
        public IEnumerable<CustomerGameRentals> SearchForSomeGameRentals([FromQuery] int[] ids)
        {

            return DbWrapper.db.CustomerGameRentals.Include(a => a.Customer).Include(a => a.Game).Where(c => ids.Contains(c.Id));

        }

        // Запит за початком та кінцем
        [HttpGet("SearchForGameRentalsByStartAndEnd")]
        public IEnumerable<CustomerGameRentals> SearchForSomeGameRentalsByStartAndEnd([FromQuery] string startOfName, [FromQuery] string endOfName)
        {

            return DbWrapper.db.CustomerGameRentals
                
                .Include(a => a.Customer)
                .Include(a => a.Game)
                
                .Where(a=>a.Game.Title.StartsWith(startOfName) && a.Game.Title.EndsWith(endOfName));

        }

    }
}