using AutoMapper;
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
    public class Edit
    {
        public class Command: IRequest<Result<Unit>>
        {
            public Applicant Applicant { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly BasicRecruiterDbContext context;
            private readonly IMapper mapper;

            public Handler(BasicRecruiterDbContext context, IMapper mapper)
            {
                this.context = context;
                this.mapper = mapper;
            }
            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var model = await context.Applicants.FindAsync(request.Applicant.Id);
                var applicant = request.Applicant;
                if(model != null)
                {
                    mapper.Map(applicant, model);
                    var result = await context.SaveChangesAsync() > 0;
                    if (!result)
                        return Result<Unit>.Failure("Failed to update applicant");
                    return Result<Unit>.Success(Unit.Value);
                }
                return null;

            }
        }
    }
}
