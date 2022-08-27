using BasicRecruiter.Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicRecruiter.Application.ApplicantStatuses
{
    public class ApplicantStatusValidator:AbstractValidator<ApplicantStatus>
    {
        public ApplicantStatusValidator()
        {
            RuleFor(x => x.StatusDescription)
                .NotNull();
        }
    }
}
