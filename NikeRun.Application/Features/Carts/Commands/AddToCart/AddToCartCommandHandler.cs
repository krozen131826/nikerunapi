using AutoMapper;
using MediatR;
using NikeRun.Application.Contracts.Entities;
using NikeRun.Application.Exception;
using NikeRun.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikeRun.Application.Features.Carts.Commands.AddToCart
{
    internal sealed class AddToCartCommandHandler : IRequestHandler<AddToCartCommand, AddToCartCommandResponse>
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Domain.Entities.Carts> _cartRepository;
        private readonly IProductsRepository _productsRepository;

        public AddToCartCommandHandler(
            IUsersRepository usersRepository, 
            IMapper mapper, 
            IGenericRepository<Domain.Entities.Carts> cartRepository,
            IProductsRepository productsRepository
            )
        {
            _usersRepository = usersRepository;
            _mapper = mapper;
            _cartRepository = cartRepository;
            _productsRepository = productsRepository;
        }


        public async Task<AddToCartCommandResponse> Handle(AddToCartCommand request, CancellationToken cancellationToken)
        {
            var addToCartCommandResponse = new AddToCartCommandResponse();
            var validator = new AddToCartCommandValidator(_usersRepository, _productsRepository);

            var validatorResults = await validator.ValidateAsync(request);

            if (validatorResults.Errors.Count > 0)
            {
                throw new ValidationErrorsException(validatorResults);

            }

            if (addToCartCommandResponse.Success)
            {
                addToCartCommandResponse.Message = "Succesfully Added To Cart";

                var productToBeAddedToCart = _mapper.Map<Domain.Entities.Carts>(request.cart);

                await _cartRepository.AddAsync(productToBeAddedToCart);
            }

            return addToCartCommandResponse;
        }
    }
}
