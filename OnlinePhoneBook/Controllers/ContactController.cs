using OnlinePhoneBook.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OnlinePhoneBook.Controllers
{
    [RoutePrefix("api/Contact")]
    public class ContactController : ApiController
    {
        [Authorize]
        [Route("")]
        public IHttpActionResult GetAllContacts()
        {
            using (var db = new AuthContext())
            {
                var query = db.ContactList.OrderBy(o => o.Name).ToList();
                if (db == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(query);
                }
            }
        }
    }
}
