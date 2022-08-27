using BasicRecruiter.Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicRecruiter.Application.JobStatuses
{
    public class JobStatusValidator:AbstractValidator<JobStatus>
    {
        public JobStatusValidator()
        {
            RuleFor(x => x.StatusDescription)
                .NotNull();
        }
    }
}
