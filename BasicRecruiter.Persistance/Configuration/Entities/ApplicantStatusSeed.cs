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
    //shortlised, interview, accepted, rejected, applied
    internal class ApplicantStatusSeed : IEntityTypeConfiguration<ApplicantStatus>
    {
        public void Configure(EntityTypeBuilder<ApplicantStatus> builder)
        {
            builder.HasData(new ApplicantStatus[] { 
                new ApplicantStatus
                {
                    Id = 1, StatusDescription = "Applied"
                },
                new ApplicantStatus
                {
                    Id = 2, StatusDescription = "Short listed"
                },
                new ApplicantStatus
                {
                    Id = 3, StatusDescription = "Interview"
                },
                new ApplicantStatus
                {
                    Id = 4, StatusDescription = "Accepted"
                },
                new ApplicantStatus
                {
                    Id = 5, StatusDescription = "Rejected"
                }
            });
        }
    }
}
