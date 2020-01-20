using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Domain.Interfaces
{
    public interface IOrderRepository<T>
    {
        IEnumerable<T> GetOrders();
        void AddOrder(T order);
        void ModifyOrder(T order);
        void RemoveOrder(int id);
    }
}
