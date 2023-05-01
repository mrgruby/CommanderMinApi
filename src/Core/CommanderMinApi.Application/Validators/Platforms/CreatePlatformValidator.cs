﻿using CommanderMinApi.Application.RequestModels.Platforms;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommanderMinApi.Application.Validators.Platforms
{
    public class CreatePlatformValidator : AbstractValidator<CreatePlatformRequestModel>
    {
        public CreatePlatformValidator()
        {
            RuleFor(p => p.platformName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.platformImageUrl)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
        }
    }
}
