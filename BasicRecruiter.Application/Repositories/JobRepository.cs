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
    public class JobRepository : GenericRepository<Job>, IJobRepository
    {
        public JobRepository(BasicRecruiterDbContext context) : base(context)
        {
        }
    }
}
