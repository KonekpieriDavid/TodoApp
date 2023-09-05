using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APIAuthentication.Repository;
using APIAuthentication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Net.Mail;


namespace APIAuthentication.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
   
    public class PayController : ControllerBase
    {
        public static UserLogin userLogin = new UserLogin();
       public static UserPayment userPayment = new UserPayment();

        private readonly IPayManagerRepository _payManagerRepository;

        public PayController(IPayManagerRepository payManagerRepository)
        {

            _payManagerRepository = payManagerRepository;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<User>> Login (UserLogin userLogin, string EmailAddress ,string Password)
        {

            userLogin.EmailAddress = EmailAddress;
            userLogin.Password = Password;
            var token = _payManagerRepository.Authenticate(EmailAddress, Password);
            if (token == null)
            {
                return Unauthorized();
            }
            //return Ok(userLogin);
            return Ok(token);
        
        }
        [HttpPost]
        [Route("paymentrequest")]
        public async Task<ActionResult<PaymentRequest>> Payment([FromBody] PaymentRequest paymentRequest)
        {
            if (paymentRequest == null)
                return Unauthorized();
            else return Ok(paymentRequest);
        }



        [HttpPost]
        [Route("sendmobilemoney")]
       
        public async Task <ActionResult<UserPayment>> Payment([FromBody]UserPayment  userPayment  
           
            )
        {
            /* userPayment.order.CustomerPhoneNumber = "";
           userPayment.order.CustomerPhoneNumber = "";
           userPayment.order.CustomerEmailAddress = "";
           userPayment.order.TransactionReferance = "";
           userPayment.order.Amount =0 ;
           userPayment.order.Currency = "";
           userPayment.destination.Provider = "";
           userPayment.destination.WalletID = "";
           */
            return Ok(userPayment);
        }






    }
}
