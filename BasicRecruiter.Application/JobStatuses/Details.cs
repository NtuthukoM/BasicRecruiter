using BasicRecruiter.Application.Contracts;
using BasicRecruiter.Application.Core;
using BasicRecruiter.Domain;
using MediatR;

namespace BasicRecruiter.Application.JobStatuses
{
    public class Details
    {
        public class Query : IRequest<Result<JobStatus>>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<JobStatus>>
        {
            private readonly IJobStatusRepository repository;

            public Handler(IJobStatusRepository repository)
            {
                this.repository = repository;
            }

            public async Task<Result<JobStatus>> Handle(Query request, CancellationToken cancellationToken)
            {
                var item = await repository.GetByIdAsync(request.Id);
                return Result<JobStatus>.Success(item);
            }
        }
    }
}
