using LoginAPI.Models;
using LoginAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LoginAPI.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ToppingController : ControllerBase
    {
        private  readonly ToppingService _toppingservice;

        public ToppingController(ToppingService toppingService)
        {
            _toppingservice = toppingService;

        }
        // GET: api/<ToppingController>
        [HttpGet]

        public IEnumerable<ToppingDTO> Get()
        {
            var tops = _toppingservice.AllToppings();
            return tops;
        }
       
        // GET api/<ToppingController>/5
        [HttpGet("{id}")]
        public ToppingDTO Get(int id)
        {
            var top = _toppingservice.ToppingDetail(id);
            return top;
        }

        // POST api/<ToppingController>
        [HttpPost]
        public void Post([FromBody] ToppingDTO toppingDetails)
        {
            _toppingservice.ToppingDetail(toppingDetails);

        }

        // PUT api/<ToppingController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ToppingController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
