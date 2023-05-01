using FluentValidation;
using NikeRun.Application.Contracts.Entities;
using NikeRun.Application.Features.Users.Queries.GetUserById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikeRun.Application.Features.Carts.Commands.AddToCart
{
    public class AddToCartCommandValidator : AbstractValidator<AddToCartCommand>
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IProductsRepository _productsRepository;

        public AddToCartCommandValidator(IUsersRepository usersRepository, IProductsRepository productsRepository)
        {
            _usersRepository = usersRepository;
            _productsRepository = productsRepository;


            RuleFor(e => e.cart.ProductName)
                .NotEmpty().WithMessage("Product Name Should not be Empty")
                .NotNull();

            RuleFor(e => e.cart.Description)
                .NotEmpty().WithMessage("Description Should not be Empty")
                .NotNull();

            RuleFor(e => e.cart.Price)
                .NotEmpty().WithMessage("Price Should not be Empty")
                .NotNull();
            RuleFor(e => e.cart.ImageLink)
                .NotEmpty().WithMessage("Link Should not be Empty")
                .NotNull();
            RuleFor(e => e.cart.Size)
                .NotEmpty().WithMessage("Size Should not be Empty")
                .NotNull();

            RuleFor(e => e)
                 .MustAsync(isUserExist).WithMessage("User Does not Exist");

            RuleFor(e => e)
             .MustAsync(isProductExist).WithMessage("Product Does not Exist");

        }


        private async Task<bool> isUserExist(AddToCartCommand e, CancellationToken token)
        {
            return await _usersRepository.isUserExist(e.email);
        }


        private async Task<bool> isProductExist(AddToCartCommand e, CancellationToken token)
        {
            return await _productsRepository.isProductExist(e.cart.ProductId);
        }
    }
}
