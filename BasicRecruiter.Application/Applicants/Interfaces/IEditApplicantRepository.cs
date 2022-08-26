using BasicRecruiter.Domain;

namespace BasicRecruiter.Application.Applicants.Interfaces
{
    public interface IEditApplicantRepository
    {
        Task<bool?> EditAsync(Applicant applicant);
        Task<bool?> SetDeletedAsync(int id);
    }
}
