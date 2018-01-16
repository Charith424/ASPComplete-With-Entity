using ASPComplete.Dtos;
using ASPComplete.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ASPComplete.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        public IHttpActionResult GetCustomer()
        {
            var CustomersDto = _context.Customers
                .Include(c => c.MembershipType)
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDto>);

            return Ok(CustomersDto);
            //  var custom= _context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDto>)
            //return Ok(Mapper.Map<Customer, CustomerDto>(customk));
        }
        //GET /api//Customer/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                //  throw new HttpResponseException(HttpStatusCode.NotFound);
                return NotFound();
            };
            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }
        //post //Api/Customer
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                // throw new HttpResponseException(HttpStatusCode.BadRequest);
                return BadRequest();
            }
            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            customerDto.Id = customer.Id;

            //   return customerDto;
            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }
        //Put api/customer/1
        // public void UpdateCustomer(int id, CustomerDto custmoerDto)
        public IHttpActionResult UpdateCustomer(int id, CustomerDto custmoerDto)
        {
            if (!ModelState.IsValid)
            {
               BadRequest();
            }

            var custmerToDb = _context.Customers.SingleOrDefault(x => x.Id == custmoerDto.Id);
            if (custmerToDb == null)
            {
                NotFound();
                //throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            Mapper.Map<CustomerDto, Customer>(custmoerDto, custmerToDb);
            custmerToDb.Name = custmoerDto.Name;
            custmerToDb.BirthDate = custmoerDto.BirthDate;
            custmerToDb.MembershipTypeId = custmoerDto.MembershipTypeId;
            custmerToDb.IsSubsceibedToNewsLetter = custmoerDto.IsSubsceibedToNewsLetter;
            _context.SaveChanges();
            return Ok();


        }

        //DELETE /api/customer/1
        //public void DeleteCustomer(int id)
        //
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var custmerToDb = _context.Customers.SingleOrDefault(x => x.Id == id);
            if (custmerToDb == null)
            {
                return NotFound();
            }
            _context.Customers.Remove(custmerToDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
