using BasicRecruiter.Application.Contracts;
using BasicRecruiter.Application.Core;
using MediatR;

namespace BasicRecruiter.Application.JobStatuses
{
    public class Delete
    {
        public class Command : IRequest<Result<Unit>>
        {
            public int Id { get; set; }
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
                bool updated = await repository.DeleteAsync(request.Id);
                if (updated)
                    return Result<Unit>.Success(Unit.Value);
                return Result<Unit>.Failure("Failed to delete");
            }
        }
    }
}
