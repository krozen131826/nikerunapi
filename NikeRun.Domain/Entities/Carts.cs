using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikeRun.Domain.Entities
{
    public class Carts
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal Size { get; set; }
        public virtual Users? Users { get; set; }
        public int UserId { get; set; }
        public virtual Products? Products { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
