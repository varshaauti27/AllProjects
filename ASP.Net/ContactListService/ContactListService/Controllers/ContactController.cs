using ContactListService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ContactListService.Controllers
{
    [EnableCors(origins:"*",headers:"*",methods:"*")]
    public class ContactController : ApiController
    {
        [Route("contacts/")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetAll()
        {
            return Ok(ContactRepository.GetAll());
        }

        [Route("contact/{id}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult Get(int id)
        {
            Contact found = ContactRepository.Get(id);
            if (found == null)
            {
                return NotFound();
            }
            return Ok(found);
        }
        [Route("contact")]
        [AcceptVerbs("POST")]
        public IHttpActionResult Add(Contact contact)
        {
            ContactRepository.Create(contact);

            return Created($"contact/{contact.ContactId}",contact);
        }

        [Route("contact/{id}")]
        [AcceptVerbs("PUT")]
        public void Update(int id, Contact contact)
        {
            ContactRepository.Update(contact);
        }

        [Route("contact/{id}")]
        [AcceptVerbs("DELETE")]
        public void Delete(int id)
        {
            ContactRepository.Delete(id);
        }
    }
}