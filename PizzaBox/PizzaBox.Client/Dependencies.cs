using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.EntityFrameworkCore;

using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Interfaces;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client
{
    public class Dependencies
    {
        public static PizzaBoxDbContext GetDbContext()
        {
            var configurBuilder = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = configurBuilder.Build();
            var optionsBuilder = new DbContextOptionsBuilder<PizzaBoxDbContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("PizzaBoxDb"));
            var options = optionsBuilder.Options;
            /*var db =*/ return new PizzaBoxDbContext(options);
        }

        public static IUserRepository<User> CreateUserRepository()
        {
            //var configurBuilder = new ConfigurationBuilder()
            //                .SetBasePath(Directory.GetCurrentDirectory())
            //                .AddJsonFile("Secrets.json", optional: true, reloadOnChange: true);

            //IConfigurationRoot configuration = configurBuilder.Build();
            //var optionsBuilder = new DbContextOptionsBuilder<PizzaBoxDbContext>();
            //optionsBuilder.UseSqlServer(configuration.GetConnectionString("PizzaBoxDb"));
            //var options = optionsBuilder.Options;
            var db = /*new PizzaBoxDbContext(options)*/ GetDbContext();
            return new UserRepository(db);
        }
    }
}
