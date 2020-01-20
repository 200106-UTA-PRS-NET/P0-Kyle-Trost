using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Domain.Interfaces
{
    public interface IPizzasSoldRepository<T>
    {
        IEnumerable<T> GetPizzasSold();
        void AddPizzaSold(T pizza);
        void ModifyPizzaSold(T pizza);
        void RemovePizzaSold(int id);
    }
}
