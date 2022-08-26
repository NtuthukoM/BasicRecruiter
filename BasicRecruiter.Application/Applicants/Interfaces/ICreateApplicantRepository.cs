using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BasicRecruiter.Application.Applicants.Create;

namespace BasicRecruiter.Application.Applicants.Interfaces
{
    public interface ICreateApplicantRepository
    {
        Task<bool> Create(Command request);
    }
}
