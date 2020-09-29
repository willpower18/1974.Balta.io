using System;
using System.Collections.Generic;
using BaltaStore.Domain.StoreContext.Enums;

namespace BaltaStore.Domain.StoreContext.OrderComands.Inputs
{
    public class PlaceOrderComand
    {
        public Guid Customer { get; set; }
        public IList<OrderItemComand> OrderItems { get; set; }
    }

    public class OrderItemComand
    {
        public Guid Product { get; set; }
        public decimal Quantity { get; set; }
    }
}