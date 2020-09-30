using System;
using System.Collections.Generic;
using BaltaStore.Domain.StoreContext.Enums;
using BaltaStore.Shared.Commands;
using FluentValidator;
using FluentValidator.Validation;

namespace BaltaStore.Domain.StoreContext.OrderComands.Inputs
{
    public class PlaceOrderComand : Notifiable, ICommand
    {
        public PlaceOrderComand()
        {
            OrderItems = new List<OrderItemComand>();
        }
        public Guid Customer { get; set; }
        public IList<OrderItemComand> OrderItems { get; set; }

        public bool Valid()
        {
            AddNotifications(new ValidationContract()
               .HasLen(Customer.ToString(), 36, "Customer", "Identificador do Cliente inválido")
               .IsGreaterThan(OrderItems.Count, 0, "Items", "Nenhum Item do Pedido Foi Encontrado")
           );
            return IsValid;
        }
    }

    public class OrderItemComand
    {
        public Guid Product { get; set; }
        public decimal Quantity { get; set; }
    }
}