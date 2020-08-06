using Business.Abstract;
using Entities.Dtos.Customer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class CustomerController : BaseApiController
    {
        ICustomerService _customerService;
        public CustomerController(ICustomerService customerService, IHttpContextAccessor _context) : base(_context)
        {
            _customerService = customerService;
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody] CustomerAddDto value)
        {
            var addResult = _customerService.Add(value, base._Id.Value);
            
            if (!addResult.Success)
                return Error(addResult.Message, addResult.Code);

            return Success(new { Id = addResult.Data });
        }

        [HttpPost("update")]
        public IActionResult Update([FromBody] CustomerUpdateDto value)
        {
            var updateResult = _customerService.Update(value, base._Id.Value);

            if (!updateResult.Success)
                return Error(updateResult.Message, updateResult.Code);

            return Success();
        }

        [HttpPost("delete")]
        public IActionResult Delete([FromBody] CustomerDeleteDto value)
        {
            var deleteResult = _customerService.Delete(value, base._Id.Value);

            if (!deleteResult.Success)
                return Error(deleteResult.Message, deleteResult.Code);

            //TODO: delete ops

            return Success();
        }
    }
}