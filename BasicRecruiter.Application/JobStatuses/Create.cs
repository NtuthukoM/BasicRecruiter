using BasicRecruiter.Application.Contracts;
using BasicRecruiter.Application.Core;
using BasicRecruiter.Domain;
using MediatR;

namespace BasicRecruiter.Application.JobStatuses
{
    public class Create
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
                var response = await repository.AddAsync(request.JobStatus);
                if (response.Id > 0)
                    return Result<Unit>.Success(Unit.Value);
                return Result<Unit>.Failure("Failed to add Job status");
            }
        }
    }
}
