using BookExchange.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookExchange.Domain.Interfaces
{
     public interface IPaymentRepository : IRepositoryBase<Payment>
     {
          public Payment GetByReference(string paymentServiceReference);
     }
}
