using System;
using Xunit;

using PizzaBox.Client;
using PizzaBox.Domain;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Interfaces;

namespace PizzaBox.Testing
{
    public class UnitTest1
    {
        [Fact]
        // test getting list of users
        public void Test1()
        {
            var userRepo = new TestUserRepository();
            var userList = userRepo.GetUsers();
        }

        [Fact]
        // test getting list of stores
        public void Test2()
        {
            var storeRepo = Dependencies.CreateStoreRepository();
            var storeList = storeRepo.GetStores();
        }

        [Fact]
        // test getting list of sizes
        public void Test3()
        {
            var sizeRepo = Dependencies.CreateSizeRepository();
            var sizeList = sizeRepo.GetSizes();
        }

        [Fact]
        // test getting list of preset pizzas
        public void Test4()
        {
            var presetRepo = Dependencies.CreatePresetPizzaRespository();
            var presetList = presetRepo.GetPresetPizzas();
        }

        [Fact]
        // test getting list of pizzas sold
        public void Test5()
        {
            var pizzaRepo = Dependencies.CreatePizzasSoldRepository();
            var pizzaList = pizzaRepo.GetPizzasSold();
        }

        [Fact]
        // test getting list of crust types
        public void Test6()
        {
            var crustRepo = Dependencies.CreateCrustTypeRepository();
            var crustList = crustRepo.GetCrustTypes();
        }

        [Fact]
        // test getting list of orders
        public void Test7()
        {
            var orderRepo = Dependencies.CreateOrderRepository();
            var orderList = orderRepo.GetOrders();
        }

        [Fact]
        // test adding a user to the test repository
        // user has new UserId and new name
        public void Test8()
        {
            var userRepo = new TestUserRepository();

            var testUser = new User
            {
                UserId = 4,
                UserName = "Jennifer",
                UserPass = "pendleton"
            };

            userRepo.TestUserRepo.Add(testUser);
        }
    }
}
