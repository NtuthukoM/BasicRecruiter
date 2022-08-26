using BasicRecruiter.Application.Applicants.Interfaces;
using BasicRecruiter.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BasicRecruiter.Application.Applicants.Create;

namespace BasicRecruiter.Application.Applicants.Repositories
{
    public class CreateApplicantRepository: ICreateApplicantRepository
    {
        private readonly BasicRecruiterDbContext context;

        public CreateApplicantRepository(BasicRecruiterDbContext context)
        {
            this.context = context;
        }
        public async Task<bool> Create(Command request)
        {
            await context.Applicants.AddAsync(request.Applicant);
            var result = await context.SaveChangesAsync() > 0;
            return result;
        }
    }
}
