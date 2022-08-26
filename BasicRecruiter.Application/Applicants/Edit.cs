using AutoMapper;
using BasicRecruiter.Application.Applicants.Interfaces;
using BasicRecruiter.Application.Core;
using BasicRecruiter.Domain;
using BasicRecruiter.Persistance;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicRecruiter.Application.Applicants
{
    public class Edit
    {
        public class Command: IRequest<Result<Unit>>
        {
            public Applicant Applicant { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Applicant).SetValidator(new ApplicantValidator());
            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly IEditApplicantRepository repository;

            public Handler(IEditApplicantRepository repository)
            {
                this.repository = repository;
            }
            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {

                var result = await repository.EditAsync(request.Applicant);
                if(result != null)
                {
                    if (!result.Value)
                        return Result<Unit>.Failure("Failed to update applicant");
                    return Result<Unit>.Success(Unit.Value);
                }
                return null;

            }
        }
    }
}
