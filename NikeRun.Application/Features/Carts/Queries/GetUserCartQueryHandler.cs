using AutoMapper;
using MediatR;
using NikeRun.Application.Contracts.Entities;
using NikeRun.Application.Exception;
using NikeRun.Domain.Dtos.Carts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikeRun.Application.Features.Carts.Queries
{
    internal sealed class GetUserCartQueryHandler : IRequestHandler<GetUserCartListQuery, GetUserCartResponse>
    {
        private readonly ICartsRepository _cartsRepository;
        private readonly IUsersRepository _usersRepository;
        private readonly IMapper _mapper;

        public GetUserCartQueryHandler(ICartsRepository cartsRepository, IUsersRepository usersRepository, IMapper mapper)
        {
            _cartsRepository = cartsRepository;
            _usersRepository = usersRepository;
            _mapper = mapper;
        }

        public async Task<GetUserCartResponse> Handle(GetUserCartListQuery request, CancellationToken cancellationToken)
        {
            var getUserCartResponse = new GetUserCartResponse();
            var validation = new GetUserCartValidator(_usersRepository);

            var validationResults = await validation.ValidateAsync(request);

            if (validationResults.Errors.Count > 0)
            {

                throw new ValidationErrorsException(validationResults);
            }

            if (getUserCartResponse.Success)
            {
                var cart = await _cartsRepository.GetUserCartsByUserId(request.userId);

                if (cart.Count is 0)
                {
                    getUserCartResponse.Message = "Cart is Empty";
                }

                getUserCartResponse.UserCart = _mapper.Map<List<CartDto>>(cart);
            }

            return getUserCartResponse;
        }
    }
}
