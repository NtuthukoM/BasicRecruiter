using AutoMapper;
using BasicRecruiter.Application.Applicants.Interfaces;
using BasicRecruiter.Application.Core;
using BasicRecruiter.Domain;
using BasicRecruiter.Persistance;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicRecruiter.Application.Applicants.Repositories
{
    public class EditApplicantRepository: IEditApplicantRepository
    {
        private readonly BasicRecruiterDbContext db;
        private readonly IMapper mapper;

        public EditApplicantRepository(BasicRecruiterDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }


        public async Task<bool?> EditAsync(Applicant applicant)
        {
            var model = await db.Applicants.FindAsync(applicant.Id);
            if (model == null)
                return null;
            mapper.Map(applicant, model);
            return await db.SaveChangesAsync() > 0;
        }

        public async Task<bool?> SetDeletedAsync(int id)
        {
            var model = await db.Applicants.FindAsync(id);
            if (model != null)
            {
                model.Deleted = true;
                return await db.SaveChangesAsync() > 0;
            }
            return null;
        }
    }
}
