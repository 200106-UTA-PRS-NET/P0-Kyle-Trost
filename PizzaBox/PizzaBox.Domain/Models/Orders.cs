﻿using System;
using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
    public partial class Orders
    {
        public Orders()
        {
            PizzasSold = new HashSet<PizzasSold>();
        }

        public int OrderId { get; set; }
        public int? StoreId { get; set; }
        public int? UserId { get; set; }
        public decimal? TotalCost { get; set; }
        public DateTime? OrderTimestamp { get; set; }

        public virtual Stores Store { get; set; }
        public virtual Users User { get; set; }
        public virtual ICollection<PizzasSold> PizzasSold { get; set; }
    }
}
