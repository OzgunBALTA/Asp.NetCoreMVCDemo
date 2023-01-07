using Business.Constants.Messages;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class RegisterValidator : AbstractValidator<UserForRegisterDto>
	{
		public RegisterValidator()
		{
			RuleFor(x => x.FirstName).NotEmpty().WithMessage(Messages.FirstNameNotEmpty);
			RuleFor(x => x.FirstName).MinimumLength(2).MaximumLength(50).WithMessage(Messages.FirstNameLenght);
			RuleFor(x => x.LastName).NotEmpty().WithMessage(Messages.LastNameNotEmpty);
            RuleFor(x => x.LastName).MinimumLength(2).MaximumLength(50).WithMessage(Messages.LastNameLenght);
            RuleFor(x => x.Email).EmailAddress().WithMessage(Messages.EmailInvalid);
			RuleFor(x => x.Password).MinimumLength(5).WithMessage(Messages.PasswordMinimumLength);
		}
	}
}
