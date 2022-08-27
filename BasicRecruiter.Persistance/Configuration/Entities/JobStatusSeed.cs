using BasicRecruiter.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicRecruiter.Persistance.Configuration.Entities
{
    internal class JobStatusSeed : IEntityTypeConfiguration<JobStatus>
    {
        public void Configure(EntityTypeBuilder<JobStatus> builder)
        {
            builder.HasData(new JobStatus[] { 
                new JobStatus
                {
                    Id = 1, StatusDescription = "Draft"
                },
                new JobStatus
                {
                    Id = 2, StatusDescription = "Published"
                },
                new JobStatus
                {
                    Id = 3, StatusDescription = "Closed"
                },
            });
        }
    }
}
