using BasicRecruiter.Application.Core;
using BasicRecruiter.Domain;
using BasicRecruiter.Persistance;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicRecruiter.Application.Applicants
{
    public  class Details
    {
        public class Query: IRequest<Result<Applicant>>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<Applicant>>
        {
            private readonly BasicRecruiterDbContext context;

            public Handler(BasicRecruiterDbContext context)
            {
                this.context = context;
            }
            public async Task<Result<Applicant>> Handle(Query request, CancellationToken cancellationToken)
            {
                var model = await context.Applicants.FindAsync(request.Id);
                return Result<Applicant>.Success(model);
            }
        }
    }
}
