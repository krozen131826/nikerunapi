using NikeRun.Domain.Dtos.Carts;
using NikeRun.Domain.Models.Response;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikeRun.Application.Features.Carts.Queries
{
    public class GetUserCartResponse : BaseResponseModel<CartDto>
    {
        public GetUserCartResponse() : base()
        {
        }

        public List<CartDto> UserCart { get; set; } = new List<CartDto>();

    }
}
