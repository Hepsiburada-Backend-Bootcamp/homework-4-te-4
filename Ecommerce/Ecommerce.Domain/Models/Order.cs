using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Domain.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        //[ForeignKey("UserId")]
        //public User User { get; set; }
        public virtual ICollection<OrderItem> Items { get; set; }
        public bool IsFinal { get; set; } = false;
        public virtual double TotalPrice
        {
            get => CalculatePrice();
        }

        public double CalculatePrice()
        {
            double totalPrice = 0;
            foreach (OrderItem item in Items)
            {
                totalPrice += item.Quantity * item.Product.Price;
            }
            return totalPrice;
        }
    }
}