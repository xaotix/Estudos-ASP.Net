using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWith_ASP.Net.Model;
using RestWith_ASP.Net.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWith_ASP.Net.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : Controller
    {
        private readonly ILogger<PersonController> _logger;

        private IPersonService _personService;

        public PersonController(ILogger<PersonController> logger, IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personService.FindAll());
        }
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var person = _personService.FindByID(id);
            if(person==null)
            {
                return NotFound();
            }
            return Ok(person);
        }
        [HttpPost("{id}")]
        public IActionResult Post([FromBody] Person person)
        {
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }
    }
}
