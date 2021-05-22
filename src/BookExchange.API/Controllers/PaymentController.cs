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

namespace BookExchange.API.Controllers
{
     [Route("api/[controller]")]
     [ApiController]
     public class PaymentController : ControllerBase
     {
          private readonly IConfiguration Configuration;

          public PaymentController(IConfiguration configuration)
          {
               Configuration = configuration;
          }

          [HttpPost]
          [AllowAnonymous]
          public ActionResult Index()
          {
               if (true)
               {
                    // Fetch the tour info from the server and NOT from the POST data.
                    // Otherwise users could manipulate the data
                    //    var tourInfo = GetNextTourInfo();

                    // Create a Ticket object to store info about the purchaser
                    /*   var ticket = new Ticket()
                       {
                            FirstName = model.FirstName,
                            LastName = model.LastName,
                            Email = model.Email,
                            TourDate = tourInfo.TourDate
                       };*/

                    // Get PayPal API Context using configuration from web.config

                    var _payPalConfig = new Dictionary<string, string>()
                        {
                            { "clientId" , Configuration.GetSection("paypal:settings:clientId").Value },
                            { "clientSecret", Configuration.GetSection("paypal:settings:clientSecret").Value },
                            { "mode", Configuration.GetSection("paypal:settings:mode").Value },
                            { "business", Configuration.GetSection("paypal:settings:business").Value },
                           // { "merchantId", Configuration.GetSection("paypal:settings:merchantId").Value },
                        };
                    var accessToken = new PayPal.Api.OAuthTokenCredential(_payPalConfig).GetAccessToken();


                    var apiContext = new APIContext(accessToken);

                    // Create a new payment object
                    var payment = new Payment
                    {
                         //experience_profile_id = "XP-HMV5-V9ES-8QXN-2F33", // Created in the WebExperienceProfilesController. This one is for DigitalGoods.
                         intent = "sale",
                         payer = new Payer
                         {
                              payment_method = "paypal"
                         },
                         transactions = new List<Transaction>
                    {
                        new Transaction
                        {
                            description = $"Brewery Tour (Single Payment) for ...",
                            amount = new Amount
                            {
                                currency = "USD",
                                total = "20.00", // PayPal expects string amounts, eg. "20.00"
                            },
                            item_list = new ItemList()
                            {
                                items = new List<Item>()
                                {
                                    new Item()
                                    {
                                        description = $"Brewery Tour (Single Payment) for ...",
                                        currency = "USD",
                                        quantity = "1",
                                        price = "20.00", // PayPal expects string amounts, eg. "20.00"                                        
                                    }
                                }
                            }
                        },

                    },
                          redirect_urls = new RedirectUrls
                          {
                               return_url = "https://google.com",
                               cancel_url = "https://google.com"
                          }
                    };

                    // Send the payment to PayPal
                     var createdPayment = payment.Create(apiContext);

                    // Save a reference to the paypal payment
                    // ticket.PayPalReference = createdPayment.id;
                    // _dbContext.SaveChanges();

                    // Find the Approval URL to send our user to
                    var approvalUrl =
                        createdPayment.links.FirstOrDefault(
                            x => x.rel.Equals("approval_url", StringComparison.OrdinalIgnoreCase));

                    // Send the user to PayPal to approve the payment
                    return Ok(new { Url = approvalUrl.href});
               }
          }

          [HttpPost("return")]
          public ActionResult Return(string payerId, string paymentId)
          {
               var _payPalConfig = new Dictionary<string, string>()
                        {
                            { "clientId" , Configuration.GetSection("paypal:settings:clientId").Value },
                            { "clientSecret", Configuration.GetSection("paypal:settings:clientSecret").Value },
                            { "mode", Configuration.GetSection("paypal:settings:mode").Value },
                            { "business", Configuration.GetSection("paypal:settings:business").Value },
                           // { "merchantId", Configuration.GetSection("paypal:settings:merchantId").Value },
                        };
               var accessToken = new PayPal.Api.OAuthTokenCredential(_payPalConfig).GetAccessToken();


               var apiContext = new APIContext(accessToken);

               var paymentExecution = new PaymentExecution()
               {
                    payer_id = payerId
               };
               var payment = new Payment()
               {
                    id = paymentId
               };

               var executedPayment = payment.Execute(apiContext, paymentExecution);

               return Ok();
          }
          /*
          public APIContext GetApiContext()
          {

               return apiContext;
          }*/
     }
}
