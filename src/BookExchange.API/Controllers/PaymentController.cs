using BookExchange.API.Utils;
using BookExchange.Domain.DTOs;
using BookExchange.Domain.Interfaces;
using BookExchange.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIContext = PayPal.Api.APIContext;
using Payment = PayPal.Api.Payment;

//TODO: split logic into commands/queries in the application layer 

namespace BookExchange.API.Controllers
{

     [Route("api/[controller]")]
     [ApiController]
     public class PaymentController : ControllerBase
     {
          private readonly IConfiguration Configuration;
          private readonly IPaymentRepository _paymentRepository;
          private readonly IUserRepository _userRepository;


          public PaymentController(IConfiguration configuration, IPaymentRepository paymentRepository, IUserRepository userRepository)
          {
               Configuration = configuration;
               _paymentRepository = paymentRepository;
               _userRepository = userRepository;
          }

          [HttpPost("singlePayment")]
          [AllowAnonymous]
          public ActionResult Index([FromBody] CreatePaymentDto paymentDto)
          {
               if (true)
               {

                    var paymentEntity = new BookExchange.Domain.Models.Payment
                    {
                         PaymentStatus = PaymentStatus.InProcess,
                         Amount = paymentDto.Amount,
                         UserId = paymentDto.UserId
                    }; 

                    var apiContext = PaymentUtils.GetApiContext(Configuration);

                    // Create a new payment object
                    var payment = new Payment
                    {
                         intent = "sale",
                         payer = new Payer
                         {
                              payment_method = "paypal"
                         },
                         transactions = new List<Transaction>
                    {
                        new Transaction
                        {
                            description = $"Book Exchange App Coins",
                            amount = new Amount
                            {
                                currency = "USD",
                                total = paymentDto.Amount.ToString("F"), 
                            },
                            item_list = new ItemList()
                            {
                                items = new List<Item>()
                                {
                                    new Item()
                                    {
                                        description = $"Book Exchange App Coins",
                                        currency = "USD",
                                        quantity = "1",
                                        price = paymentDto.Amount.ToString("F"),                                      
                                    }
                                }
                            }
                        },

                    },
                          redirect_urls = new RedirectUrls
                          {
                               return_url = Configuration.GetSection("paypal:singlePayment:return_url").Value,
                               cancel_url = Configuration.GetSection("paypal:singlePayment:cancel_url").Value
                          }
                    };

                    // Send the payment to PayPal
                     var createdPayment = payment.Create(apiContext);

                    // Save a reference to the paypal payment
                    paymentEntity.PaymentServiceReference = createdPayment.id;
                    _paymentRepository.Add(paymentEntity);
                    _paymentRepository.SaveAll();

                    // Find the Approval URL to send our user to
                    var approvalUrl =
                        createdPayment.links.FirstOrDefault(
                            x => x.rel.Equals("approval_url", StringComparison.OrdinalIgnoreCase));

                    // Send the user to PayPal to approve the payment
                    return Ok(new { Url = approvalUrl.href});
               }
          }

          [HttpPost("finish-payment")]
          [AllowAnonymous]
          public ActionResult FinishPayment([FromBody] FinishPaymentDto paymentDto)
          {
               var apiContext = PaymentUtils.GetApiContext(Configuration);

               var paymentEntity = _paymentRepository.GetByReference(paymentDto.PaymentId);
               var user = _userRepository.GetById(paymentEntity.UserId);

               try
               {

                    var paymentExecution = new PaymentExecution()
                    {
                         payer_id = paymentDto.PayerId
                    };
                    var payment = new Payment()
                    {
                         id = paymentDto.PaymentId
                    };

                    var executedPayment = payment.Execute(apiContext, paymentExecution);

                    if (executedPayment.state.ToLower() != "approved")
                    {
                         paymentEntity.PaymentStatus = PaymentStatus.Failed;
                         _paymentRepository.SaveAll();
                         return BadRequest(); 
                    }

               } catch (Exception ex) {
                    paymentEntity.PaymentStatus = PaymentStatus.Failed;
                    _paymentRepository.SaveAll();
                    return BadRequest(ex.Message);
               }

               paymentEntity.PaymentStatus = PaymentStatus.Executed;
               user.Points += 10;
               _paymentRepository.SaveAll();
               _userRepository.SaveAll();

               return Ok();
          }

          [HttpPost("cancel")]
          [AllowAnonymous]
          public IActionResult CancelPayment([FromBody] FinishPaymentDto paymentDto)
          {
               var paymentEntity = _paymentRepository.GetByReference(paymentDto.PaymentId); // check if not null / try catch & status in progress

               if (paymentEntity == null)
               {
                    return BadRequest("Invalid payment ID");
               }

               paymentEntity.PaymentStatus = PaymentStatus.Cancelled;
               _paymentRepository.SaveAll();

               return Ok();
          }
     }
}
