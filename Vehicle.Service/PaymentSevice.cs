using Rental_Vehicle.Enties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Core.Repositories;
using Vehicle.Core.Services;
using Vehicle.Data.Repositories;

namespace Vehicle.Service
{
    public class PaymentSevice : IPaymentService
    {
        private IPaymentRepository _paymentRepository;

        public PaymentSevice(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }
        public List<Payment> Get()
        {
            return _paymentRepository.Get();
        }
        public double GetPayment(int id)
        {
            return _paymentRepository.Get(id);
        
        }
        public bool AddPayment(Payment payment)
        {
            var pays = _paymentRepository.Get();
            var exist = pays.Contains(payment);
            if (exist)
            {
                return true;
            }
            return false;

        }
        public bool UpdatePayment(int code, Payment payment)
        {
            return true;
        }
       


    }
}
