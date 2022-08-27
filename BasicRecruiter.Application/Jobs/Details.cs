using BasicRecruiter.Application.Contracts;
using BasicRecruiter.Application.Core;
using BasicRecruiter.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicRecruiter.Application.Jobs
{
    public class Details
    {
        public class Query : IRequest<Result<Job>>
        {
            public int Id { get; set; }
        }

        public class Handler:IRequestHandler<Query, Result<Job>>
        {
            private readonly IJobRepository repository;

            public Handler(IJobRepository repository)
            {
                this.repository = repository;
            }

            public async Task<Result<Job>> Handle(Query request, CancellationToken cancellationToken)
            {
                var item = await repository.GetByIdAsync(request.Id);
                return Result<Job>.Success(item);
            }
        }
    }
}
