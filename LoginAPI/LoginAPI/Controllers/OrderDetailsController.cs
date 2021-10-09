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
    public class OrderDetailsController : ControllerBase
    {
        private readonly OrderDetailsService _orderdetailservice;

        public OrderDetailsController(OrderDetailsService orderDetailsService)
        {
            _orderdetailservice = orderDetailsService;
        }
        // GET: api/<OrderDetailsController>
        [HttpGet]
        public IEnumerable<OrderDetailsDTO> Get()
        {
            var orders= _orderdetailservice.GetAllOrderDetails();
            return orders;
        }

        // GET api/<OrderDetailsController>/5
        [HttpGet("{id}")]
        public OrderDetailsDTO Get(int id)
        {
            var orderbyid = _orderdetailservice.DetailsById(id);
            return orderbyid;
        }

        // POST api/<OrderDetailsController>
        [HttpPost]
        public void Post([FromBody] OrderDetailsDTO orderDetailsDTO)
        {
            _orderdetailservice.Orderdetail(orderDetailsDTO);
        }

        // PUT api/<OrderDetailsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrderDetailsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
