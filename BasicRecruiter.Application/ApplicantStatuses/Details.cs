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
    public class Details
    {
        public class Query : IRequest<Result<ApplicantStatus>>
        {
            public int Id { get; set; }
        }

        public class Handler:IRequestHandler<Query, Result<ApplicantStatus>>
        {
            private readonly IApplicantStatusRepository repository;

            public Handler(IApplicantStatusRepository repository)
            {
                this.repository = repository;
            }

            public async Task<Result<ApplicantStatus>> Handle(Query request, CancellationToken cancellationToken)
            {
                var item = await repository.GetByIdAsync(request.Id);
                return Result<ApplicantStatus>.Success(item);
            }
        }
    }
}
