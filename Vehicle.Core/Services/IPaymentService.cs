using Rental_Vehicle.Enties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle.Core.Services
{
    
    public interface IPaymentService
    {
        public List<Payment> Get();
        public Payment GetPayment(int id);
        public Payment AddPayment(Payment payment);
        public bool UpdatePayment(int code, Payment payment);
        
    }
}
