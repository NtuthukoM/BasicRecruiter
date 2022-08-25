using BasicRecruiter.Application.Applicants;
using BasicRecruiter.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BasicRecruiter.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantsController : BaseApiController
    {
        // GET: api/<ApplicantsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await mediator.Send(new List.Query());
            return HandleResult(result);
        }

        // GET api/<ApplicantsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await mediator.Send(new Details.Query() { Id = id });
            return HandleResult(result);
        }

        // POST api/<ApplicantsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Applicant model)
        {
            var result = await mediator.Send(new Create.Command() { Applicant = model });
            return HandleResult(result);
        }

        // PUT api/<ApplicantsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Applicant applicant)
        {
            var result = await mediator.Send(new Edit.Command() { Applicant = applicant });
            return HandleResult(result);
        }

        // DELETE api/<ApplicantsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await mediator.Send(new Delete.Command() { Id = id });
            return HandleResult(result);
        }
    }
}
