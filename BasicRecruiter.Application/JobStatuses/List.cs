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
    public class List
    {
        public class Query : IRequest<Result<List<JobStatus>>>
        {

        }

        public class Handler : IRequestHandler<Query, Result<List<JobStatus>>>
        {
            private readonly IJobStatusRepository repository;

            public Handler(IJobStatusRepository repository)
            {
                this.repository = repository;
            }
            public async Task<Result<List<JobStatus>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var items = await repository.GetAllAsync();
                return Result<List<JobStatus>>.Success(items);
            }
        }
    }
}
