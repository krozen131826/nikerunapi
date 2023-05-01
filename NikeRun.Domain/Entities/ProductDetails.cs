using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace NikeRun.Domain.Entities
{
    public class ProductDetails
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal Size { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual Products? Product { get; set; }
        public int ProductId { get; set; }
    }
}
