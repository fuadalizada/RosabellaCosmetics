using FluentValidation;
using RosabellaCosmetics.Business.DTOs;

namespace RosabellaCosmetics.Business.FluentValidations
{
    public class ProductValidator:AbstractValidator<ProductDto>
    {
        public ProductValidator()
        {
            RuleFor(product => product.Name).NotNull().WithMessage("Name couldn't be null.");
            RuleFor(product => product.Price).NotNull();
            RuleFor(product => product.QuantityInStock).NotNull();
        }
    }
}
