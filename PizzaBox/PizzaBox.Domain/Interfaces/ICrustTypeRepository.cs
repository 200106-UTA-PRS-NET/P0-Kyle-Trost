using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Domain.Interfaces
{
    public interface ICrustTypeRepository<T>
    {
        IEnumerable<T> GetCrustTypes();
        void AddCrust(T crust);
        void ModifyCrust(T crust);
        void RemoveCrust(int id);
    }
}
