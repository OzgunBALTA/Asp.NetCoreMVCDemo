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
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage(Messages.BlogTitleNotEmpty);
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage(Messages.BlogContentNotEmpty);
            RuleFor(x => x.BlogImage).NotEmpty().WithMessage(Messages.BlogImageNotEmpty);
            RuleFor(x => x.BlogTitle).MinimumLength(2).MaximumLength(50).WithMessage(Messages.BlogTitileLength);
            RuleFor(x => x.BlogContent).MinimumLength(150).WithMessage(Messages.BlogContentLength);
        }
    }
}
