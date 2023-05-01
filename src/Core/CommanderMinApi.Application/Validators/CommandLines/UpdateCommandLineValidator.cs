using CommanderMinApi.Application.RequestModels.CommandLines;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommanderMinApi.Application.Validators.CommandLines
{
    public class UpdateCommandLineValidator : AbstractValidator<UpdateCommandLineRequestModel>
    {
        public UpdateCommandLineValidator()
        {
            RuleFor(p => p.HowTo)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.CommandLine)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
        }
    }
}
