using BookExchange.Domain.Interfaces;
using BookExchange.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExchange.Infrastructure.Persistance.Repositories
{
     public class PaymentRepository : RepositoryBase<Payment>, IPaymentRepository
     {
          public PaymentRepository(BookExchangeDbContext context) : base(context)
          {
          }

          public Payment GetByReference(string paymentServiceReference) 
          {
               return GetAllByCondition(x => x.PaymentServiceReference == paymentServiceReference).Single();
          }

     }
}
