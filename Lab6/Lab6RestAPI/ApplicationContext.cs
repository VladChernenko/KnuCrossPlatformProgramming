using Microsoft.EntityFrameworkCore;
using Lab6RestAPI.Models;


namespace Lab6RestAPI
{


    public class ApplicationContext : DbContext
    {

        public DbSet<Customer> Customers => Set<Customer>();

        public DbSet<CustomerGameRentals> CustomerGameRentals => Set<CustomerGameRentals>();

        public DbSet<CustomerItemRental> CustomerItemRentals => Set<CustomerItemRental>();

        public DbSet<CustomerMovieRentals> CustomerMovieRentals => Set<CustomerMovieRentals>();

        public DbSet<Game> Games => Set<Game>();

        public DbSet<Inventory> Inventories => Set<Inventory>();

        public DbSet<InventoryItemType> InventoryItemTypes => Set<InventoryItemType>();

        public DbSet<Movie> Movies => Set<Movie>();


      



        public ApplicationContext()
        {

            Database.EnsureCreated();

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            var builder = new ConfigurationBuilder();

            builder.AddJsonFile($"{Directory.GetCurrentDirectory()}/appsettings.json");

            var config = builder.Build();


            string typeOfDatabase = config.GetSection("TypeOfDb").Value ?? "sqllite";


            switch (typeOfDatabase)
            {

                case "sqllite":

                    optionsBuilder.UseSqlite("Data Source=final.db");

                    break;

                case "mssql":

                    optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=mssqldb;Trusted_Connection=True;");

                    break;

                case "postgresql":

                    optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=usersdb2;Username=postgres;Password=123456789");

                    break;

                case "inmemory":

                    optionsBuilder.UseInMemoryDatabase("InMemoryDatabase");

                    break;

            }

        }

    }

}
