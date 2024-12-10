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
            _paymentService = paymentService;
        }

        [HttpGet]
        public IEnumerable<Payment> Get()
        {
            return _paymentService.Get();
        }

        // GET api/<PaymentController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            Payment payment = _paymentService.GetPayment(id);
            if (payment == null)
            {
                return NotFound();
            }
            return Ok(payment);
        }


        // POST api/<PaymentController>
        [HttpPost]
        public void Post([FromBody] Payment payment)
        {
            _paymentService.AddPayment(payment);
        }

        // PUT api/<PaymentController>/5
        [HttpPut("{id}")]

        public ActionResult Put(int id, [FromBody] Payment payment)
        {

            var result = _paymentService.UpdatePayment(id, payment);
            if (result == null)
            {
                return NotFound($"Payment with ID {id} not found.");
            }

            return Ok(result);
        }




        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var success = _paymentService.DeletePayment(id);
            if (!success)
            {
                return NotFound($"Payment with ID {id} not found.");
            }
            return NoContent();
        }

    }
}