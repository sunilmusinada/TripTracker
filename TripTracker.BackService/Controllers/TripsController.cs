using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TripTracker.BackService.Models;

namespace TripTracker.BackService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripsController : ControllerBase
    {

        private Repository _repository;

        public TripsController(Repository repository)
        {
            _repository = repository;
        }

        // GET api/Trip
        [HttpGet]
        public ActionResult<IEnumerable<Trip>> Get()
        {
          return  _repository.Get();
        }

        // GET api/Trip/5
        [HttpGet("{id}")]
        public ActionResult<Trip> Get(int id)
        {
            return _repository.Get(id);
        }

        // POST api/Trip
        [HttpPost]
        public void Post([FromBody] Trip value)
        {
            _repository.Add(value);
        }

        // PUT api/Trip/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Trip value)
        {
            _repository.Update(value);
        }

        // DELETE api/Trip/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repository.Remove(id);
        }
    }
}