using BasicRecruiter.Application.Applicants.Interfaces;
using BasicRecruiter.Application.Core;
using BasicRecruiter.Persistance;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicRecruiter.Application.Applicants
{
    public class Delete
    {
        public class Command : IRequest<Result<Unit>>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly IEditApplicantRepository repository;

            public Handler(IEditApplicantRepository repository)
            {
                this.repository = repository;
            }
            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var result = await repository.SetDeletedAsync(request.Id);
                if(result != null)
                {
                    if(result.Value)
                    return Result<Unit>.Success(Unit.Value);
                    return Result<Unit>.Failure("Failed to delete applicant");
                }
                return null;
            }
        }
    }
}
