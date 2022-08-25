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
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Applicant Applicant { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly BasicRecruiterDbContext context;

            public Handler(BasicRecruiterDbContext context)
            {
                this.context = context;
            }
            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                await context.Applicants.AddAsync(request.Applicant);
                var result =  await context.SaveChangesAsync() > 0;
                if (!result)
                    return Result<Unit>.Failure("Failed to save job application");
                return Result<Unit>.Success(Unit.Value);

            }
        }
    }
}
