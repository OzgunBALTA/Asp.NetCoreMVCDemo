using Business.Constants.Messages;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage(Messages.CategoryNameNotEmpty);
            RuleFor(x => x.CategoryName).MinimumLength(2).MaximumLength(50).WithMessage(Messages.CategoryNameLength);
            RuleFor(x => x.Description).NotEmpty().WithMessage(Messages.CategoryDescriptionNotEmpty);
        }
    }
}
