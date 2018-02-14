using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HelloMVC.Controllers
{
	public class Phone
	{
		public string Model { get; set; }
		public decimal Price { get; set; }
	}

    //[Authorize]
    public class PhonesController : ApiController
    {
        //static in order to prevent re-creation of the list after each request
        private static List<Phone> _phones = new List<Phone>();

        // GET api/values
        public IEnumerable<Phone> Get()
        {
            return _phones;
        }

        // GET api/values/5
        public Phone Get(int id)
        {
            return _phones[id];
        }

        // POST api/values
        public void Post([FromBody]Phone phone)
        {
            _phones.Add(phone);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]Phone newPhone)
        {
            _phones[id] = newPhone;
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            _phones.RemoveAt(id);
        }
    }
}
