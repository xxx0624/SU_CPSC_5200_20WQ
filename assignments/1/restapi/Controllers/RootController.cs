using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using restapi.Models;

namespace restapi.Controllers
{
    public class RootController : Controller
    {
        // GET api/values
        [Route("~/")]
        [HttpGet]
        [Produces(ContentTypes.Root)]
        [ProducesResponseType(typeof(IDictionary<ApplicationRelationship, object>), 200)]
        public IDictionary<ApplicationRelationship, object> Get()
        {
            var timesheetsLinks = new List<DocumentLink>();
            timesheetsLinks.Add(new DocumentLink()
            {
                Method = Method.Get,
                Type = ContentTypes.Timesheets,
                Relationship = DocumentRelationship.Timesheets,
                Reference = "/timesheets"
            });

            timesheetsLinks.Add(new DocumentLink()
            {
                Method = Method.Post,
                Type = ContentTypes.Timesheets,
                Relationship = DocumentRelationship.Timesheets,
                Reference = "/timesheets"
            });

            var peopleLinks = new List<DocumentLink>();
            peopleLinks.Add(new DocumentLink()
            {
                Method = Method.Get,
                Type = ContentTypes.People,
                Relationship = DocumentRelationship.People,
                Reference = "/people"
            });

            return new Dictionary<ApplicationRelationship, object>()
            {
                {
                    ApplicationRelationship.Timesheets, timesheetsLinks
                },
                {
                    ApplicationRelationship.People, peopleLinks
                },
                {
                    ApplicationRelationship.Version, "0.1"
                }
            };
        }
    }
}
