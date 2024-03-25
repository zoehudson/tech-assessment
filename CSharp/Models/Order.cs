﻿using System;

namespace CSharp.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public bool IsCancelled { get; set; }

        public Order()
        {

        }
    }
}
