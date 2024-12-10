using Rental_Vehicle.Enties;
using System;
using System.Collections.Generic;
using System.Linq;
using Vehicle.Core.Repositories;
using Vehicle.Core.Services;

namespace Vehicle.Service
{
    public class PaymentService : IPaymentService
    {
        private IPaymentRepository _paymentRepository;

        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        // מחזיר את כל התשלומים
        public List<Payment> Get()
        {
            return _paymentRepository.Get();
        }

        // מחזיר תשלום לפי מזהה
        public double GetPayment(int id)
        {
            return _paymentRepository.Get(id);
        }

        // הוספת תשלום
        public bool AddPayment(Payment payment)
        {
            // בודק אם תשלום עם אותו קוד כבר קיים
            var existingPayment = _paymentRepository.Get().FirstOrDefault(p => p.code == payment.code);
            if (existingPayment != null)
            {
                return false;  // התשלום כבר קיים, לא ניתן להוסיף אותו שוב
            }

            _paymentRepository.Post(payment);  // מוסיף את התשלום למאגר
            return true;  // התשלום נוסף בהצלחה
        }

        // עדכון תשלום
        public bool UpdatePayment(int code, Payment payment)
        {
            // בודק אם התשלום קיים לפי הקוד
            var existingPayment = _paymentRepository.Get().FirstOrDefault(p => p.code == code);
            if (existingPayment == null)
            {
                return false;  // התשלום לא נמצא
            }

            // מעדכן את מחיר התשלום (או את שאר המאפיינים אם צריך)
            existingPayment.price = payment.price;
            _paymentRepository.Put(code, existingPayment);  // שומר את התשלום המעודכן במאגר
            return true;  // העדכון בוצע בהצלחה
        }

        // מחיקת תשלום
        //public bool DeletePayment(int code)
        //{
        //    var paymentToDelete = _paymentRepository.Get().FirstOrDefault(p => p.code == code);

        //    if (paymentToDelete == null)
        //    {
        //        return false;  // התשלום לא נמצא
        //    }

        //    _paymentRepository.Delete(paymentToDelete);  // מוחק את התשלום מהמאגר
        //    return true;  // המחיקה בוצעה בהצלחה
        //}

    }
}
