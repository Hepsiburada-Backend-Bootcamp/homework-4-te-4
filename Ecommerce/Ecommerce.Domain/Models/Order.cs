using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Ecommerce.Domain.Models
{
    public class Order
    {
        public Order()
        {
            Items = new List<OrderItem>();
        }
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public bool IsFinal { get; set; } = false;


        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public virtual ICollection<OrderItem> Items { get; set; }


        public virtual double TotalPrice
        {
            get => CalculatePrice();
        }

        public double CalculatePrice()
        {
            double totalPrice = 0; 
            if(Items.Any()) totalPrice = Items.Sum(item => item.Quantity * item.Product.Price);
            return totalPrice;
        }
    }
}