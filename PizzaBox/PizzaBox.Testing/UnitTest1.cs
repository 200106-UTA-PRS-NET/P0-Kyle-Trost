using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Globalization;
using System.Linq;

using PizzaBox.Client;
using PizzaBox.Domain;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Runtime.Serialization.Json;
using System.Text;

namespace PizzaBox.Testing
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var pizza = new Pizza(PizzaSize.Small, PizzaCrust.Thin);
            System.Console.WriteLine($"{pizza.SizeOfPizza} Pizza with {pizza.Crust} " +
                $"crust: ${pizza.Price}");
            Assert.IsNotNull(pizza);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var pizza = new Pizza(PizzaSize.Small, PizzaCrust.Stuffed);
            System.Console.WriteLine($"{pizza.SizeOfPizza} Pizza with {pizza.Crust} " +
                $"crust: ${pizza.Price}");
            Assert.IsNotNull(pizza);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var nfi = new NumberFormatInfo();
            nfi.NumberDecimalDigits = 2;

            var order = new Order(PizzaSize.Small, PizzaCrust.Thin);

            foreach(var pizza in order.GetOrderedPizzas())
            {
                Console.WriteLine($"{pizza.SizeOfPizza} pizza: ${pizza.Price.ToString("N", nfi)}");
            }

            Console.WriteLine($"Total cost: ${order.GetTotalCost().ToString("N", nfi)}");

            //System.Console.WriteLine($"{order.GetOrderedPizza().SizeOfPizza} " +
            //    $"Pizza with {order.GetOrderedPizza().Crust} crust: " +
            //    $"${order.GetTotalCost().ToString("N", nfi)}");
            Assert.IsNotNull(order);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var order = new Order(PizzaSize.Small, PizzaCrust.Thin);

            foreach (var pizza in order.GetOrderedPizzas())
            {
                Console.WriteLine($"{pizza.SizeOfPizza} pizza: ${pizza.Price.ToString("N", Globals.GetNfi())}");
            }

            Console.WriteLine($"Total cost: ${order.GetTotalCost().ToString("N", Globals.GetNfi())}");

            //System.Console.WriteLine($"{order.GetOrderedPizza().SizeOfPizza} " +
            //    $"Pizza with {order.GetOrderedPizza().Crust} crust: " +
            //    $"${order.GetTotalCost().ToString("N", nfi)}");
            Assert.IsNotNull(order);
        }

        [TestMethod]
        public void TestMethod5()
        {
            var order = new Order(PizzaSize.Small, PizzaCrust.Thin);
            order.AddToOrder(PizzaSize.Medium, PizzaCrust.Stuffed);

            foreach (var pizza in order.GetOrderedPizzas())
            {
                Console.WriteLine($"{pizza.SizeOfPizza} pizza with {pizza.Crust} crust: ${pizza.Price.ToString("N", Globals.GetNfi())}");
            }

            Console.WriteLine($"Total cost: ${order.GetTotalCost().ToString("N", Globals.GetNfi())}");

            //System.Console.WriteLine($"{order.GetOrderedPizza().SizeOfPizza} " +
            //    $"Pizza with {order.GetOrderedPizza().Crust} crust: " +
            //    $"${order.GetTotalCost().ToString("N", nfi)}");
            Assert.IsNotNull(order);
        }

        [TestMethod]
        public void TestMethod6()
        {
            var order = new Order(PizzaSize.Small, PizzaCrust.Thin);
            order.AddToOrder(PizzaSize.Medium, PizzaCrust.Stuffed);
            order.AddToOrder(PizzaSize.Large, PizzaCrust.Stuffed);
            order.AddToOrder(PizzaSize.Large, PizzaCrust.Stuffed);
            order.AddToOrder(PizzaSize.Large, PizzaCrust.Stuffed);
            order.AddToOrder(PizzaSize.Large, PizzaCrust.Stuffed);
            order.AddToOrder(PizzaSize.Large, PizzaCrust.Stuffed);
            order.AddToOrder(PizzaSize.Large, PizzaCrust.Stuffed);
            order.AddToOrder(PizzaSize.Large, PizzaCrust.Stuffed);
            order.AddToOrder(PizzaSize.Large, PizzaCrust.Stuffed);
            order.AddToOrder(PizzaSize.Large, PizzaCrust.Stuffed);
            order.AddToOrder(PizzaSize.Large, PizzaCrust.Stuffed);
            order.AddToOrder(PizzaSize.Large, PizzaCrust.Stuffed);
            order.AddToOrder(PizzaSize.Large, PizzaCrust.Stuffed);
            order.AddToOrder(PizzaSize.Large, PizzaCrust.Stuffed);
            order.AddToOrder(PizzaSize.Large, PizzaCrust.Stuffed);
            order.AddToOrder(PizzaSize.Large, PizzaCrust.Stuffed);

            foreach (var pizza in order.GetOrderedPizzas())
            {
                Console.WriteLine($"{pizza.SizeOfPizza} pizza with {pizza.Crust} crust: ${pizza.Price.ToString("N", Globals.GetNfi())}");
            }

            Console.WriteLine($"Total cost: ${order.GetTotalCost().ToString("N", Globals.GetNfi())}");

            //System.Console.WriteLine($"{order.GetOrderedPizza().SizeOfPizza} " +
            //    $"Pizza with {order.GetOrderedPizza().Crust} crust: " +
            //    $"${order.GetTotalCost().ToString("N", nfi)}");
            Assert.IsNotNull(order);
        }

        [TestMethod]
        // test accessing database by getting user "Kyle"
        public void TestMethod7()
        {
            var configurBuilder = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("Secrets.json", optional: true, reloadOnChange: true);

            var configuration = configurBuilder.Build();
            var optionsBuilder = new DbContextOptionsBuilder<PizzaBoxDbContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("PizzaBoxDb"));
            var options = optionsBuilder.Options;
            var db = new PizzaBoxDbContext(options);
            var user = db.Find<Users>(1);

            if(user != null)
                Console.WriteLine($"{user.UserName} {user.UserPass}");
            else
                Console.WriteLine("User does not exist");
        }

        [TestMethod]
        // test deserializing and displaying order for user "Kyle"
        public void TestMethod8()
        {
            //var configurBuilder = new ConfigurationBuilder()
            //                .SetBasePath(Directory.GetCurrentDirectory())
            //                .AddJsonFile("Secrets.json", optional: true, reloadOnChange: true);

            //var configuration = configurBuilder.Build();
            //var optionsBuilder = new DbContextOptionsBuilder<PizzaBoxDbContext>();
            //optionsBuilder.UseSqlServer(configuration.GetConnectionString("PizzaBoxDb"));
            //var options = optionsBuilder.Options;
            //var db = new PizzaBoxDbContext(options);

            //var user = db.Find<Users>("Kyle");

            ////Console.WriteLine($"{user.UserId} {user.Pw}");

            //if(user != null)
            //{
            //    var store = db.Find<Stores>(1);

            //    if(store != null)
            //    {
            //        Console.WriteLine($"Welcome to {store.StoreLocation}");

            //        Console.WriteLine("---Generating test order---");

            //        var testOrder = new Order();
            //        testOrder.AddToOrder(PizzaSize.Small, PizzaCrust.Normal);

            //        var serializer = new DataContractJsonSerializer(typeof(Order));

            //        // this stream required to serialize the string to json
            //        var stream = new MemoryStream();

            //        string jsonString = "";

            //        try
            //        {
            //            // data is serialized here
            //            serializer.WriteObject(stream, testOrder);

            //            jsonString = Encoding.UTF8.GetString(stream.ToArray());
            //        }
            //        catch
            //        {
            //            throw;
            //        }

            //        //var serialTestOrder = JsonConvert.SerializeObject(testOrder);
            //        store.SerializedOrders = /*serialTestOrder*/ jsonString;

            //        Console.WriteLine(jsonString);

            //        db.Stores.Update(store);
            //        db.SaveChanges();

            //        //store.SerializedOrders = serialTestOrder;

            //        //Console.WriteLine(store.SerializedOrders);

            //        Console.WriteLine("---Test order generated---");
            //    }
            //}
        }

        [TestMethod]
        public void TestMethod9()
        {
            //var configurBuilder = new ConfigurationBuilder()
            //                .SetBasePath(Directory.GetCurrentDirectory())
            //                .AddJsonFile("Secrets.json", optional: true, reloadOnChange: true);

            //var configuration = configurBuilder.Build();
            //var optionsBuilder = new DbContextOptionsBuilder<PizzaBoxDbContext>();
            //optionsBuilder.UseSqlServer(configuration.GetConnectionString("PizzaBoxDb"));
            //var options = optionsBuilder.Options;
            //var db = new PizzaBoxDbContext(options);

            //var store = db.Find<Stores>(1);

            //if(store != null)
            //{
            //    var deserializer = new DataContractJsonSerializer(typeof(Order));

            //    var stream = new MemoryStream(Encoding.UTF8.GetBytes(store.SerializedOrders));
            //    var deserialOrder = new Order();

            //    try
            //    {
            //        // data is serialized here
            //        deserialOrder = (Order)deserializer.ReadObject(stream);

            //        if (deserialOrder.OrderedPizzas == null)
            //        {
            //            Console.WriteLine("OrderedPizzas is null");
            //            return;
            //        }

            //        Console.WriteLine("---Itemized Receipt---");

            //        foreach(var pizza in deserialOrder.OrderedPizzas)
            //        {
            //            Console.WriteLine($"Name: {pizza.Name}");
            //            Console.WriteLine($"\tSize: {pizza.SizeOfPizza}");
            //            Console.WriteLine($"\tCrust: {pizza.Crust}");
            //            Console.WriteLine($"\tCost: {pizza.Price}");
            //        }
            //    }
            //    catch
            //    {
            //        throw;
            //    }
            //}
        }

        [TestMethod]
        // test having a user sign in, providing both existing and non-existing login info
        public void TestMethod10()
        {
            var successUser = "Kyle";
            var successPass = "qwerty";

            var failUser = "Trost";
            var failPass = "uiop";

            var configurBuilder = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("Secrets.json", optional: true, reloadOnChange: true);

            var configuration = configurBuilder.Build();
            var optionsBuilder = new DbContextOptionsBuilder<PizzaBoxDbContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("PizzaBoxDb"));
            var options = optionsBuilder.Options;
            var db = new PizzaBoxDbContext(options);
            //var user = db.Find<Users>(1);

            var successQuery = from u in db.Users
                               where u.UserName == successUser && u.UserPass == successPass
                               select u;

            var failQuery = from u in db.Users
                            where u.UserName == failUser && u.UserPass == failPass
                            select u;

            if(successQuery.Any())
            {
                Console.WriteLine($"Welcome, {successQuery.First().UserName}!");
            }
            else
            {
                Console.WriteLine("Success user failed");
            }

            if (failQuery.Any())
            {
                Console.WriteLine($"Welcome, {failQuery.First().UserName}!");
            }
            else
            {
                Console.WriteLine("Fail user failed");
            }
        }

        [TestMethod]
        // test getting the user table with the user repository, and displaying info for all users
        public void TestMethod11()
        {
            var userRepo = Dependencies.CreateUserRepository();
            var users = userRepo.GetUsers();

            foreach(var user in users)
            {
                Console.WriteLine($"{user.UserId} {user.UserName} {user.UserPass}");
            }
        }

        //[TestMethod]
        // test adding a new user to the database, then displaying user list
        public void TestMethod12()
        {
            var testUser = new User();
            //testUser.UserId = 2;
            testUser.UserName = "Trost";
            testUser.UserPass = "uiop";

            var userRepo = Dependencies.CreateUserRepository();
            userRepo.AddUser(testUser);
            var users = userRepo.GetUsers();

            foreach(var user in users)
            {
                Console.WriteLine($"{user.UserId} {user.UserName} {user.UserPass}");
            }
        }

        //[TestMethod]
        // test removing a user from the database, then displaying user list
        public void TestMethod13()
        {
            int idToRemove = 2;

            var userRepo = Dependencies.CreateUserRepository();
            userRepo.RemoveUser(idToRemove);
            var users = userRepo.GetUsers();

            foreach(var user in users)
            {
                Console.WriteLine($"{user.UserId} {user.UserName} {user.UserPass}");
            }
        }

        [TestMethod]
        // test modifying a user by changing its password, then display user list
        public void TestMethod14()
        {
            var testUser = new User
            {
                UserId = 1,
                UserName = "Kyle",
                UserPass = "123456"
            };

            var userRepo = Dependencies.CreateUserRepository();
            userRepo.ModifyUser(testUser);
            var users = userRepo.GetUsers();

            foreach (var user in users)
            {
                Console.WriteLine($"{user.UserId} {user.UserName} {user.UserPass}");
            }
        }
    }
}
