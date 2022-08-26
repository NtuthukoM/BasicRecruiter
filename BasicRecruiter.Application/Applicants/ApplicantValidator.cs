using BasicRecruiter.Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicRecruiter.Application.Applicants
{
    public class ApplicantValidator: AbstractValidator<Applicant>
    {
        public ApplicantValidator()
        {
            RuleFor(x => x.Name).NotEmpty()
                .MinimumLength(5)
                .MaximumLength(500);
            RuleFor(x => x.Phone).NotEmpty().Length(10);
            RuleFor(x => x.CvUrl).NotEmpty();
        }
    }
}
