using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicRecruiter.Domain;

namespace BasicRecruiter.Persistance
{
    public class BasicRecruiterDbContext:DbContext
    {
        public DbSet<JobStatus> JobStatuses { get; set; }
        public DbSet<ApplicantStatus> ApplicantStatuses { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Applicant> Applicants { get; set; }
    }
}
