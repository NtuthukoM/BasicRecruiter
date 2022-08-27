using BasicRecruiter.Application.JobStatuses;
using BasicRecruiter.Domain;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BasicRecruiter.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobStatusesController : BaseApiController
    {
        // GET: api/<JobStatusesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await mediator.Send(new List.Query());
            return HandleResult(result);
        }

        // GET api/<JobStatusesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await mediator.Send(new Details.Query { Id = id });
            return HandleResult(result);
        }

        // POST api/<JobStatusesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] JobStatus value)
        {
            var result = await mediator.Send(new Create.Command { JobStatus = value });
            return HandleResult(result);
        }

        // PUT api/<JobStatusesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] JobStatus value)
        {
            var result = await mediator.Send(new Edit.Command { JobStatus = value });
            return HandleResult(result);
        }

        // DELETE api/<JobStatusesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await mediator.Send(new Delete.Command { Id = id });
            return HandleResult(result);
        }
    }
}
