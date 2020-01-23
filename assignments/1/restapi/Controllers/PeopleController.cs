using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.Logging;
using restapi.Models;

namespace restapi.Controllers
{
    [Route("[controller]")]
    public class PeopleController : Controller
    {
        private readonly PeopleRepository repository;

        private readonly ILogger logger;

        public PeopleController(ILogger<PeopleController> logger)
        {
            repository = new PeopleRepository();
            this.logger = logger;
        }

        [HttpGet("/people")]
        [Produces(ContentTypes.People)]
        [ProducesResponseType(typeof(IEnumerable<People>), 200)]
        public IEnumerable<People> GetAll()
        {
            return repository
                .All
                .OrderBy(t => t.Opened);
        }

        [HttpPost("/people")]
        [Produces(ContentTypes.Timesheet)]
        [ProducesResponseType(typeof(Timecard), 200)]
        public People Create([FromBody] DocumentPerson person)
        {
            logger.LogInformation($"Creating people for {person.ToString()}");

            var p = new People(person.Id);

            repository.Add(p);

            return p;
        }
    }
}