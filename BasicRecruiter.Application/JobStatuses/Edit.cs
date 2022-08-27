using BasicRecruiter.Application.Contracts;
using BasicRecruiter.Application.Core;
using BasicRecruiter.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicRecruiter.Application.JobStatuses
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public JobStatus JobStatus { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly IJobStatusRepository repository;

            public Handler(IJobStatusRepository repository)
            {
                this.repository = repository;
            }
            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                bool updated = await repository.UpdateAsync(request.JobStatus);
                if (updated)
                    return Result<Unit>.Success(Unit.Value);
                return Result<Unit>.Failure("Failed to update.");
            }
        }
    }
}
