using System;
using System.Collections.Generic;

namespace MvcCafeteria.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public required string CustomerName { get; set; }
        public required List<OrderItem> OrderItems { get; set; } // Lista de itens no pedido
    }

    public class OrderItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
