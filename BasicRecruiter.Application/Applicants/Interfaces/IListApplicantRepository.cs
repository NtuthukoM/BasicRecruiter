using BasicRecruiter.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicRecruiter.Application.Applicants.Interfaces
{
    public interface IListApplicantRepository
    {
        Task<List<Applicant>> GetApplicantsAsync();
    }
}
