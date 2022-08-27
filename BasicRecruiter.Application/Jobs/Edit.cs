using BasicRecruiter.Application.Contracts;
using BasicRecruiter.Application.Core;
using BasicRecruiter.Domain;
using MediatR;

namespace BasicRecruiter.Application.Jobs
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Job Job { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly IJobRepository repository;

            public Handler(IJobRepository repository)
            {
                this.repository = repository;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var updated = await repository.UpdateAsync(request.Job);
                if (updated)
                    return Result<Unit>.Success(Unit.Value);
                return Result<Unit>.Failure("Failed to update");
            }
        }
    }
}
