using BasicRecruiter.Application.Jobs;
using BasicRecruiter.Domain;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BasicRecruiter.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : BaseApiController
    {
        // GET: api/<JobsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await mediator.Send(new List.Query());
            return HandleResult(result);
        }

        // GET api/<JobsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await mediator.Send(new Details.Query() { Id = id });
            return HandleResult(result);
        }

        // POST api/<JobsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Job value)
        {
            var result = await mediator.Send(new Create.Command() { Job = value });
            return HandleResult(result);
        }

        // PUT api/<JobsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Job value)
        {
            var result = await mediator.Send(new Edit.Command() { Job = value });
            return HandleResult(result);
        }

        // DELETE api/<JobsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await mediator.Send(new Delete.Command() { Id = id });
            return HandleResult(result);
        }
    }
}
