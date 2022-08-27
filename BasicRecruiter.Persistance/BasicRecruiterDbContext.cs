using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicRecruiter.Domain;
using BasicRecruiter.Persistance.Configuration.Entities;

namespace BasicRecruiter.Persistance
{
    public class BasicRecruiterDbContext:DbContext
    {
        public DbSet<JobStatus> JobStatuses { get; set; }
        public DbSet<ApplicantStatus> ApplicantStatuses { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Applicant> Applicants { get; set; }

        public BasicRecruiterDbContext(DbContextOptions options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new JobStatusSeed());
            modelBuilder.ApplyConfiguration(new ApplicantStatusSeed());
        }
    }
}
