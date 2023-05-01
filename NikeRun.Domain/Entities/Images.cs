using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NikeRun.Domain.Entities
{
    public class Images
    {
        public int Id { get; set; }
        public string ImageLink { get; set; } = string.Empty;
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual Products? Product { get; set; }
        public int ProductId { get; set; }
    }
}
