using AutoMapper;
using MediatR;
using NikeRun.Application.Contracts.Entities;
using NikeRun.Application.Exception;
using NikeRun.Application.Features.Users.Commands.UpdateUser;
using NikeRun.Domain.Dtos.Carts;
using NikeRun.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikeRun.Application.Features.Carts.Commands.UpdateCartQuantity
{
    public sealed class UserCartQuantyUpdateCommandHandler : IRequestHandler<UserCartQuantityUpdateCommand, UserCartQuantityUpdateCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICartsRepository _cartsRepository;
        private readonly IGenericRepository<Domain.Entities.Carts> _genericRepository;

        public UserCartQuantyUpdateCommandHandler(IMapper mapper,ICartsRepository cartsRepository, IGenericRepository<Domain.Entities.Carts> genericRepository)
        {
            _mapper = mapper;
            _cartsRepository = cartsRepository;
            _genericRepository = genericRepository;
        }

        public async Task<UserCartQuantityUpdateCommandResponse> Handle(UserCartQuantityUpdateCommand request, CancellationToken cancellationToken)
        {
            var userCart = await _genericRepository.GetByIdAsync(request.cartId);

            var userCartQuantityUpdateCommandResponse = new UserCartQuantityUpdateCommandResponse();
            var validator = new UserCartUpdateCommandValidator(_cartsRepository);
            var validatorResults = await validator.ValidateAsync(request);

            if (validatorResults.Errors.Count() > 0)
            {
                throw new ValidationErrorsException(validatorResults);
            }

            if (userCartQuantityUpdateCommandResponse.Success)
            {
                var mappedCart = _mapper.Map<UpdateCartDto>(userCart);

                request.patchDocument.ApplyTo(mappedCart);

                var cartToUpdate = _mapper.Map(mappedCart, userCart);

                userCartQuantityUpdateCommandResponse.Message = "Update Successfull";

                await _genericRepository.UpdateAsync(cartToUpdate!);
            }

            return userCartQuantityUpdateCommandResponse;

        }
    }
}
