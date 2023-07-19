using Casgem.BusinessLayer.Abstract;
using Casgem.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CasgemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult CustomerList()
        {
            var values = _customerService.TGetList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CustomerAdd(Customer customer)
        {
            _customerService.TInsert(customer);
            return Ok();
        }

        [HttpDelete]
        public IActionResult CustomerDelete(int id)
        {
            var values = _customerService.TGetById(id);
            _customerService.TDelete(values);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomer(int id)
        {
            var value = _customerService.TGetById(id);

            return Ok(value);
        }

        [HttpPut]
        public IActionResult CustomerUpdate(Customer customer)
        {
            _customerService.TUpdate(customer);
            return Ok();
        }
    }
}
