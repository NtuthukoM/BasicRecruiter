using BasicRecruiter.Application.ApplicantStatuses;
using BasicRecruiter.Domain;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BasicRecruiter.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantStatusesController : BaseApiController
    {
        // GET: api/<ApplicantStatusesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var items = await mediator.Send(new List.Query());
            return HandleResult(items);
        }

        // GET api/<ApplicantStatusesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await mediator.Send(new Details.Query() { Id = id });
            return HandleResult(response);
        }

        // POST api/<ApplicantStatusesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ApplicantStatus value)
        {
            var result = await mediator.Send(new Create.Command 
            { 
                ApplicantStatus = value
            });
            return HandleResult(result);
        }

        // PUT api/<ApplicantStatusesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ApplicantStatus value)
        {
            var result = await mediator.Send(new Edit.Command() 
            { 
                ApplicantStatus = value
            });
            return HandleResult(result);
        }

        // DELETE api/<ApplicantStatusesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await mediator.Send(new Delete.Command { Id = id });
            return HandleResult(result);
        }
    }
}
