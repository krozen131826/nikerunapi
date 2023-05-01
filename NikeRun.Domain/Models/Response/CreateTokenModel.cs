using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikeRun.Domain.Models.Response
{
    public class CreateTokenModel
    {
        public string CreatedToken { get; set; } = string.Empty;
        public string JwtId { get; set; } = string.Empty;
    }
}
