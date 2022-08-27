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
    public class List
    {
        public class Query : IRequest<Result<List<Job>>>
        {

        }

        public class Handler:IRequestHandler<Query, Result<List<Job>>>
        {
            private readonly IJobRepository repository;

            public Handler(IJobRepository repository)
            {
                this.repository = repository;
            }

            public async Task<Result<List<Job>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var items = await repository.GetAllAsync();
                return Result<List<Job>>.Success(items);
            }
        }
    }

}
