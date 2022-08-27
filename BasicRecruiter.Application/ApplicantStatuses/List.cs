using BasicRecruiter.Application.Contracts;
using BasicRecruiter.Application.Core;
using BasicRecruiter.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicRecruiter.Application.ApplicantStatuses
{
    public class List
    {
        public class Query : IRequest<Result<List<ApplicantStatus>>>
        {

        }

        public class Handler:IRequestHandler<Query, Result<List<ApplicantStatus>>>
        {
            private readonly IApplicantStatusRepository repository;

            public Handler(IApplicantStatusRepository repository)
            {
                this.repository = repository;
            }

            public async Task<Result<List<ApplicantStatus>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var items = await repository.GetAllAsync();
                return Result<List<ApplicantStatus>>.Success(items);
            }
        }
    }
}
