using CommanderMinApi.Application.RequestModels.CommandLines;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommanderMinApi.Application.Validators.CommandLines
{
    public class CreateCommandLineValidator : AbstractValidator<CreateCommandLineRequestModel>
    {
        public CreateCommandLineValidator()
        {
            RuleFor(p => p.howTo)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.commandLine)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
        }
    }
}
