using BasicRecruiter.Application.Contracts;
using BasicRecruiter.Domain;
using BasicRecruiter.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicRecruiter.Application.Repositories
{
    public class ApplicantStatusRepository : GenericRepository<ApplicantStatus>, IApplicantStatusRepository
    {
        public ApplicantStatusRepository(BasicRecruiterDbContext context) : base(context)
        {
        }
    }
}
