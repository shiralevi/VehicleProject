using Rental_Vehicle;
using Rental_Vehicle.Enties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Core.Repositories;
using Vehicle.Core.Services;

namespace Vehicle.Data.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private DataContext _context;

        public PaymentRepository(DataContext context)
        {
            _context = context;
        }


        public List<Payment> Get()
        {
            return _context.payments;
        }

        public double Get(int code)
        {
            var index = _context.payments.FindIndex(e => e.code == code);
            if (index != -1)
                return _context.payments[index].price;

            return 0;
        }

        public void Post(Payment payment)
        {
            _context.payments.Add(payment);
        }


        public double Put(int code, Payment payment)
        {
            var index = _context.payments.FindIndex(e => e.code == code);
            if (index != -1)
            {
              return  _context.payments[index].price;

            }
            return 0;


        }

        //public void Delete(int id)
        //{


        //}

    }   }


