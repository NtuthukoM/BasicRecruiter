using BasicRecruiter.Application.Applicants.Interfaces;
using BasicRecruiter.Domain;
using BasicRecruiter.Persistance;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicRecruiter.Application.Applicants.Repositories
{
    public class DetailApplicantRepository : IDetailApplicantRepository
    {
        private readonly BasicRecruiterDbContext context;

        public DetailApplicantRepository(BasicRecruiterDbContext context)
        {
            this.context = context;
        }
        public async Task<Applicant> GetApplicant(int id)
        {
            return await context.Applicants.FindAsync(id);
        }
    }
}
