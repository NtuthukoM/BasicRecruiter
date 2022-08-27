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
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Job Job { get; set; }
        }

        public class Handler:IRequestHandler<Command, Result<Unit>>
        {
            private readonly IJobRepository repository;

            public Handler(IJobRepository repository)
            {
                this.repository = repository;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var item = await repository.AddAsync(request.Job);
                if (item.Id > 0)
                    return Result<Unit>.Success(Unit.Value);
                return Result<Unit>.Failure("Failed to create job");
            }
        }
    }
}
