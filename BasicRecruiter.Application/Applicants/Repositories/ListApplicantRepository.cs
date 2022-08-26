using BasicRecruiter.Application.Applicants.Interfaces;
using BasicRecruiter.Domain;
using BasicRecruiter.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicRecruiter.Application.Applicants.Repositories
{
    public class ListApplicantRepository: IListApplicantRepository
    {
        private readonly BasicRecruiterDbContext context;

        public ListApplicantRepository(BasicRecruiterDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Applicant>> GetApplicantsAsync()
        {
            return await context.Applicants.Where(x =>
                    !x.Deleted).ToListAsync();
        }
    }
}
