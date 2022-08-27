using BasicRecruiter.Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicRecruiter.Application.Jobs
{
    public class JobValidator:AbstractValidator<Job>
    {
        public JobValidator()
        {
            RuleFor(x => x.Title).NotNull();
            RuleFor(x => x.Summary).NotNull();
            RuleFor(x => x.JobDescriptionUrl).NotNull();
            RuleFor(x => x.ExpiryDate).NotNull().Must(x => x > DateTime.Now);
            RuleFor(x => x.JobStatusId).NotNull().Must(x => x > 0);
        }
    }
}
