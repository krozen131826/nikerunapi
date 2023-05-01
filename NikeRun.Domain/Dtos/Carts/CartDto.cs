﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikeRun.Domain.Dtos.Carts
{
    public class CartDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public string ImageLink { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal Size { get; set; }
    }
}
