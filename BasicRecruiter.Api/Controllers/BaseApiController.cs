using BasicRecruiter.Application.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BasicRecruiter.Api.Controllers
{
    public class BaseApiController: ControllerBase
    {
        private IMediator _mediator;

        protected IMediator mediator => _mediator ??= HttpContext.RequestServices
            .GetService<IMediator>();

        protected ActionResult HandleResult<T>(Result<T> result)
        {
            if (result == null)
                return NotFound();

            if (result.IsSuccess)
            {
                return result.Value == null ? NotFound()
                    : Ok(result.Value);
            }
            return BadRequest();
        }
    }
}
