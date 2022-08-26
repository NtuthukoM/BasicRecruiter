using BasicRecruiter.Application.Applicants.Interfaces;
using BasicRecruiter.Application.Core;
using BasicRecruiter.Domain;
using BasicRecruiter.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicRecruiter.Application.Applicants
{
    public class List
    {
        public class Query : IRequest<Result<List<Applicant>>>
        {

        }

        public class Handler : IRequestHandler<Query, Result<List<Applicant>>>
        {
            private readonly IListApplicantRepository repository;

            public Handler(IListApplicantRepository repository)
            {
                this.repository = repository;
            }
            public async Task<Result<List<Applicant>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var applicants = await repository.GetApplicantsAsync();
                return Result<List<Applicant>>.Success(applicants);
            }
        }
    }
}
