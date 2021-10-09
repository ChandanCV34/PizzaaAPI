using LoginAPI.Models;
using LoginAPI.Services;
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
    public class OrderItemDetailsController : ControllerBase
    {
        private readonly OrderItemDetailsService _orderitemdetailsservice;

        public OrderItemDetailsController(OrderItemDetailsService orderItem)
        {
            _orderitemdetailsservice = orderItem;
        }
        // GET: api/<OrderItemDetailsController>
        [HttpGet]
        public IEnumerable<OrderItemDetailsDTO> Get()
        {
            var orditem = _orderitemdetailsservice.GetAllOrderDetails();
            return orditem;
        }

        // GET api/<OrderItemDetailsController>/5
        [HttpGet("{id}")]
        public OrderItemDetailsDTO Get(int id)
        {
            var orderbyid = _orderitemdetailsservice.DetailsById(id);
            return orderbyid;
        }

        // POST api/<OrderItemDetailsController>
        [HttpPost]
        public void Post([FromBody] OrderItemDetailsDTO order)
        {
            _orderitemdetailsservice.Orderdetail(order);
        }

        // PUT api/<OrderItemDetailsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrderItemDetailsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
