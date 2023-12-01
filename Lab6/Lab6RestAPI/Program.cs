using Lab6RestAPI.Models;


namespace Lab6RestAPI {

    class DbWrapper
    {

        public static ApplicationContext db = new ApplicationContext();

    }

    public class Program
    {

        public static void Main(string[] args)
        {

            PrepareDatabase();

            StartServer(args);

        }


        static void StartServer(string[] args)
        {

            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();

        }

        static void PrepareDatabase()
        {
            ApplicationContext db = DbWrapper.db;

            if (!db.Customers.Any())
            {
                InitWithData(db);
            }

        }

        static void InitWithData(ApplicationContext db)
        {

            
            // Define initial objects for DB

            //____________________________ Independent _____________________________

            InventoryItemType item1 = new InventoryItemType { Id = 1, Description = "Some random inventory type 1" };
            InventoryItemType item2 = new InventoryItemType { Id = 2, Description = "Some random inventory type 2" };
            InventoryItemType item3 = new InventoryItemType { Id = 3, Description = "Some random inventory type 3" };
            InventoryItemType item4 = new InventoryItemType { Id = 4, Description = "Some random inventory type 4" };
            InventoryItemType item5 = new InventoryItemType { Id = 5, Description = "Some random inventory type 5" };


            db.InventoryItemTypes.AddRange(item1, item2, item3, item4, item5);


            Customer customer1 = new Customer { Id = 1, Name = "John Doe", Address = "123 Main St", OtherDetails = "Details 1" };
            Customer customer2 = new Customer { Id = 2, Name = "Jane Smith", Address = "456 Oak St", OtherDetails = "Details 2" };
            Customer customer3 = new Customer { Id = 3, Name = "Bob Johnson", Address = "789 Elm St", OtherDetails = "Details 3" };
            Customer customer4 = new Customer { Id = 4, Name = "Alice Brown", Address = "101 Pine St", OtherDetails = "Details 4" };
            Customer customer5 = new Customer { Id = 5, Name = "Charlie Wilson", Address = "202 Maple St", OtherDetails = "Details 5" };

            db.Customers.AddRange(customer1, customer2, customer3, customer4, customer5);

            Movie movie1 = new Movie { Id = 1, Title = "Movie 1", RentalDailyRate = 3, NumberInStock = 10 };
            Movie movie2 = new Movie { Id = 2, Title = "Movie 2", RentalDailyRate = 4, NumberInStock = 8 };
            Movie movie3 = new Movie { Id = 3, Title = "Movie 3", RentalDailyRate = 2, NumberInStock = 15 };
            Movie movie4 = new Movie { Id = 4, Title = "Movie 4", RentalDailyRate = 5, NumberInStock = 5 };
            Movie movie5 = new Movie { Id = 5, Title = "Movie 5", RentalDailyRate = 3, NumberInStock = 12 };


            db.Movies.AddRange(movie1, movie2, movie3, movie4, movie5);

            Game game1 = new Game { Id = 1, Title = "Game 1", RentalDailyRate = 2, NumberInStock = 20 };
            Game game2 = new Game { Id = 2, Title = "Game 2", RentalDailyRate = 3, NumberInStock = 15 };
            Game game3 = new Game { Id = 3, Title = "Game 3", RentalDailyRate = 4, NumberInStock = 12 };
            Game game4 = new Game { Id = 4, Title = "Game 4", RentalDailyRate = 5, NumberInStock = 8 };
            Game game5 = new Game { Id = 5, Title = "Game 5", RentalDailyRate = 3, NumberInStock = 18 };


            db.Games.AddRange(game1, game2, game3, game4, game5);

            //____________________ Now add dependent entities _____________________

            Inventory inventory1 = new Inventory { Id = 1, InventoryItemType = item1, Description = "Inventory 1" };
            Inventory inventory2 = new Inventory { Id = 2, InventoryItemType = item2, Description = "Inventory 2" };
            Inventory inventory3 = new Inventory { Id = 3, InventoryItemType = item3, Description = "Inventory 3" };
            Inventory inventory4 = new Inventory { Id = 4, InventoryItemType = item4, Description = "Inventory 4" };
            Inventory inventory5 = new Inventory { Id = 5, InventoryItemType = item5, Description = "Inventory 5" };


            db.Inventories.AddRange(inventory1, inventory2, inventory3, inventory4, inventory5);



            CustomerItemRental cir1 = new CustomerItemRental
            {
                Id = 1,
                Customer = customer1,
                Inventory = inventory1,
                DateOut = DateTime.Now.AddDays(-7),
                DateReturned = DateTime.Now,
                RentalAmountDue = 20
            };

            CustomerItemRental cir2 = new CustomerItemRental
            {
                Id = 2,
                Customer = customer2,
                Inventory = inventory2,
                DateOut = DateTime.Now.AddDays(-14),
                DateReturned = DateTime.Now.AddDays(-7),
                RentalAmountDue = 15
            };

            CustomerItemRental cir3 = new CustomerItemRental
            {
                Id = 3,
                Customer = customer3,
                Inventory = inventory3,
                DateOut = DateTime.Now.AddDays(-21),
                DateReturned = DateTime.Now.AddDays(-14),
                RentalAmountDue = 25
            };

            CustomerItemRental cir4 = new CustomerItemRental
            {
                Id = 4,
                Customer = customer4,
                Inventory = inventory4,
                DateOut = DateTime.Now.AddDays(-28),
                DateReturned = DateTime.Now.AddDays(-21),
                RentalAmountDue = 18
            };

            CustomerItemRental cir5 = new CustomerItemRental
            {
                Id = 5,
                Customer = customer5,
                Inventory = inventory5,
                DateOut = DateTime.Now.AddDays(-35),
                DateReturned = DateTime.Now.AddDays(-28),
                RentalAmountDue = 30
            };


            db.CustomerItemRentals.AddRange(cir1, cir2, cir3, cir4, cir5);


            //---------------------------------------------


            CustomerMovieRentals cmr1 = new CustomerMovieRentals
            {
                Id = 1,
                Customer = customer1,
                Movie = movie1,
                DateOut = DateTime.Now.AddDays(-7),
                DateReturned = DateTime.Now,
                RentalAmountDue = 20
            };

            CustomerMovieRentals cmr2 = new CustomerMovieRentals
            {
                Id = 2,
                Customer = customer2,
                Movie = movie2,
                DateOut = DateTime.Now.AddDays(-14),
                DateReturned = DateTime.Now.AddDays(-7),
                RentalAmountDue = 15
            };

            CustomerMovieRentals cmr3 = new CustomerMovieRentals
            {
                Id = 3,
                Customer = customer3,
                Movie = movie3,
                DateOut = DateTime.Now.AddDays(-21),
                DateReturned = DateTime.Now.AddDays(-14),
                RentalAmountDue = 25
            };

            CustomerMovieRentals cmr4 = new CustomerMovieRentals
            {
                Id = 4,
                Customer = customer4,
                Movie = movie4,
                DateOut = DateTime.Now.AddDays(-28),
                DateReturned = DateTime.Now.AddDays(-21),
                RentalAmountDue = 18
            };

            CustomerMovieRentals cmr5 = new CustomerMovieRentals
            {
                Id = 5,
                Customer = customer5,
                Movie = movie5,
                DateOut = DateTime.Now.AddDays(-35),
                DateReturned = DateTime.Now.AddDays(-28),
                RentalAmountDue = 30
            };


            db.CustomerMovieRentals.AddRange(cmr1, cmr2, cmr3, cmr4, cmr5);


            //---------------------------------

            CustomerGameRentals cgr1 = new CustomerGameRentals
            {
                Id = 1,
                Customer = customer1,
                Game = game1,
                DateOut = DateTime.Now.AddDays(-7),
                DateReturned = DateTime.Now,
                RentalAmountDue = 20
            };

            CustomerGameRentals cgr2 = new CustomerGameRentals
            {
                Id = 2,
                Customer = customer2,
                Game = game2,
                DateOut = DateTime.Now.AddDays(-14),
                DateReturned = DateTime.Now.AddDays(-7),
                RentalAmountDue = 15
            };

            CustomerGameRentals cgr3 = new CustomerGameRentals
            {
                Id = 3,
                Customer = customer3,
                Game = game3,
                DateOut = DateTime.Now.AddDays(-21),
                DateReturned = DateTime.Now.AddDays(-14),
                RentalAmountDue = 25
            };

            CustomerGameRentals cgr4 = new CustomerGameRentals
            {
                Id = 4,
                Customer = customer4,
                Game = game4,
                DateOut = DateTime.Now.AddDays(-28),
                DateReturned = DateTime.Now.AddDays(-21),
                RentalAmountDue = 18
            };

            CustomerGameRentals cgr5 = new CustomerGameRentals
            {
                Id = 5,
                Customer = customer5,
                Game = game5,
                DateOut = DateTime.Now.AddDays(-35),
                DateReturned = DateTime.Now.AddDays(-28),
                RentalAmountDue = 30
            };

            db.CustomerGameRentals.AddRange(cgr1, cgr2, cgr3, cgr4, cgr5);



            db.SaveChanges();


        }

    }

}