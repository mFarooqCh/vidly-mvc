using AutoMapper;
using mvcWithMosh.DTOs;
using mvcWithMosh.Models;
using System;
using System.Linq;
using System.Web.Http;

namespace mvcWithMosh.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private readonly AppDbContext _dbContext;

        public CustomersController()
        {
            _dbContext = new AppDbContext();
        }
        // GET api/<controller>
        public IHttpActionResult GetCustomers()
        {
            return Ok(_dbContext.Customer.ToList().Select(Mapper.Map<Customers, CustomerDTO>));
        }

        // GET api/<controller>/5
        [HttpGet]
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _dbContext.Customer.Find(id);
            if (customer == null)
                return NotFound();

            return Ok(Mapper.Map<Customers, CustomerDTO>(customer));
        }

        // POST api/<controller>
        [HttpPost]
        public IHttpActionResult CreateCustomer([FromBody] CustomerDTO customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<CustomerDTO, Customers>(customerDto);
            _dbContext.Customer.Add(customer);
            _dbContext.SaveChanges();

            customerDto.Id = customer.Id;
            return Created(new Uri($"{Request.RequestUri}/{customer.Id}"), customerDto); //returns 201, status code , a restful convention
        }

        // PUT api/<controller>/5
        [HttpPut]
        public IHttpActionResult EditCustomer(int id, [FromBody] CustomerDTO customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customerInDb = _dbContext.Customer.Find(id);

            if (customerInDb == null)
                return NotFound();

            Mapper.Map(customerInDb, customerDto);

            _dbContext.SaveChanges();
            return Ok();
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var customerInDb = _dbContext.Customer.Find(id);

            if (customerInDb == null)
                return NotFound();

            _dbContext.Customer.Remove(customerInDb);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}