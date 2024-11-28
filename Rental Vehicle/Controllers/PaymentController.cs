using Microsoft.AspNetCore.Mvc;
using Rental_Vehicle.Enties;
using Vehicle.Core.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Rental_Vehicle.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private IPaymentService _paymentService;
        public PaymentController(IPaymentService paymentService)
        {
            _paymentService=paymentService;
        }

        [HttpGet]
        public IEnumerable<Payment> Get()
        {
           return _paymentService.Get();
        }

        // GET api/<PaymentController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int code)
        {
          Payment paymant= _paymentService.GetPayment(code);
          
        }

        // POST api/<PaymentController>
        [HttpPost]
        public void Post([FromBody] Payment payment)
        {
            context.payments.Add(payment);
        }

        // PUT api/<PaymentController>/5
        [HttpPut("{id}")]
        public double Put(int code, [FromBody] Payment payment)
        {
            var index = context.payments.FindIndex(e => e.code == code);
            if (index != -1)
            {

                return context.payments[index].price;
            }
          return 0;
        
        }

        // DELETE api/<PaymentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
