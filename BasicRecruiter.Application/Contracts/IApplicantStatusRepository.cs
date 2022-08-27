using BasicRecruiter.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicRecruiter.Application.Contracts
{
    public interface IApplicantStatusRepository: IGenericRepository<ApplicantStatus>
    {
    }
}
