using CommanderMinApi.Application.RequestModels.Platforms;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommanderMinApi.Application.Validators.Platforms
{
    public class UpdatePlatformValidator : AbstractValidator<UpdatePlatformRequestModel>
    {
        public UpdatePlatformValidator()
        {
            RuleFor(p => p.PlatformName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.PlatformImageUrl)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
        }
    }
}
