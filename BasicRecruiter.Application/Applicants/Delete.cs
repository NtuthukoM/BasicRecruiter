using BasicRecruiter.Application.Core;
using BasicRecruiter.Persistance;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicRecruiter.Application.Applicants
{
    public class Delete
    {
        public class Command : IRequest<Result<Unit>>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly BasicRecruiterDbContext context;

            public Handler(BasicRecruiterDbContext context)
            {
                this.context = context;
            }
            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var model = await context.Applicants.FindAsync(request.Id);
                if(model != null)
                {
                    model.Deleted = true;
                    await context.SaveChangesAsync();
                    return Result<Unit>.Success(Unit.Value);
                }
                return null;
            }
        }
    }
}
