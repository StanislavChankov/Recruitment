using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using Synergy.Recruitment.Core.Services.Identity;

namespace Synergy.Recruitment.Api.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IPersonService _personService;

        public ValuesController(IPersonService personService) 
        {
            _personService = personService;
        }

        // GET api/values
        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetAsync([FromRoute] long id)
        {
            var result = await _personService.GetByUserIdAsync(id);

            return Ok(result);
        }

    
        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
