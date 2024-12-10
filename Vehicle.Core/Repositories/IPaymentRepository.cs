using Rental_Vehicle.Enties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle.Core.Repositories
{
    public interface IPaymentRepository
    {
        public List<Payment> Get();
        public double Get(int code);
        public void Post(Payment payment);
        public double Put(int code, Payment payment);

        //void Delete(Payment paymentToDelete);
    }
}
