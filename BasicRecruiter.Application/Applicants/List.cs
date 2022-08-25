using BasicRecruiter.Application.Core;
using BasicRecruiter.Domain;
using BasicRecruiter.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicRecruiter.Application.Applicants
{
    public class List
    {
        public class Query : IRequest<Result<List<Applicant>>>
        {

        }

        public class Handler : IRequestHandler<Query, Result<List<Applicant>>>
        {
            private readonly BasicRecruiterDbContext context;

            public Handler(BasicRecruiterDbContext context)
            {
                this.context = context;
            }
            public async Task<Result<List<Applicant>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var applicants = await context.Applicants.Where(x =>
                    !x.Deleted).ToListAsync();
                return Result<List<Applicant>>.Success(applicants);
            }
        }
    }
}
