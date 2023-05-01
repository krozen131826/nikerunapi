using FluentValidation;
using NikeRun.Application.Contracts.Entities;
using NikeRun.Application.Features.Carts.Commands.AddToCart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikeRun.Application.Features.Carts.Commands.UpdateCartQuantity
{
    public class UserCartUpdateCommandValidator : AbstractValidator<UserCartQuantityUpdateCommand>
    {
        private readonly ICartsRepository _cartsRepository;

        public UserCartUpdateCommandValidator(ICartsRepository cartsRepository)
        {
            _cartsRepository = cartsRepository;

            RuleFor(x => x)
                .MustAsync(isCartItemExist)
                .WithMessage("Cart Item Doesnt Exist");

            RuleFor(x => x.patchDocument)
           .Custom((patchDocument, context) =>
           {
               foreach (var docs in patchDocument.Operations)
               {
                   if (docs.value is null)
                   {
                       context.AddFailure("Invalid Quantity");

                   }

                   if (docs.op != "replace")
                   {
                       context.AddFailure("Invalid Operation");
                   }

                   if (int.TryParse(docs.value?.ToString(), out int results))
                   {
                       if (results < 0)
                       {
                           context.AddFailure("Invalid Quantity");
                       }
                   }

               }
           });
        }

        private async Task<bool> isCartItemExist(UserCartQuantityUpdateCommand e, CancellationToken token)
        {
            return await _cartsRepository.IsCartItemExist(e.cartId, e.userId);
        }
    }
}
