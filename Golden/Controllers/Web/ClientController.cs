using Golden.Entities;
using Golden.Model;
using Golden.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using static Golden.Model.ClientLoginModel;

namespace Golden.Controllers.Web
{
    [Route("api/Web/[controller]/[Action]")]
   
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _Clientservice;
        private readonly ApplicationDbContext _db;
        //private readonly IStringLocalizer<CategoryController> _localization;


        public ClientController(ApplicationDbContext db, IClientService clientservice)
        {
            _Clientservice = clientservice;
            _db = db;
            //_localization = localization;

        }
        [HttpPost]

        public IActionResult Login(LoginModel model)
        {


            var obj = _db.clients.FirstOrDefault(u => u.Email == model.Email);


            if (obj == null)
            {

                return Unauthorized();

            }

            var obj1 = _db.clients.FirstOrDefault(u => u.Password == model.Password && u.Email == model.Email); ;
            if (obj1 == null)
                return BadRequest("wrong password!");

            var AccessToken = GenerateAccessToken(obj1.ClientId);
            obj1.Token = AccessToken;

            _db.SaveChanges();

            var dto = new LoginDto()
            {
                AccessToken = AccessToken,

            };


            return Ok(dto);

        }


        //[HttpPost("{token},{email}")]
        //[AllowAnonymous]
        //public async Task<IActionResult> Verfiy([FromRoute] string token, [FromRoute] string email)
        //{
        //    var DecodePass = decrypt(token);
        //    var user = _db.Users.FirstOrDefault(u => u.VertificationToken == DecodePass && u.Email == email);
        //    if (user == null)
        //    {
        //        return BadRequest("Invalid Token");
        //    }
        //    user.Verified = DateTime.Now;

        //    _db.SaveChanges();
        //    return Ok("User-Vertified");

        //}

        [HttpPost]

        public async Task<IActionResult> Register([FromForm] RegisterModel obj)
        {


            if (_db.clients.Any(u => u.Email == obj.Email))
            {
                return BadRequest("Email is already exist");
            }
            var rand = new Random();

            var client = new Client()
            {
                ClientName = obj.ClientName,
                Email = obj.Email,
                Password = obj.Password,
                PhoneNumber = obj.PhoneNumber,

                //VertificationToken = CreateRandomToken(),


            };

            _db.clients.Add(client);
            _db.SaveChanges();

            //var fileName = _mediaHelper.SaveFile(obj.Photo);

            //var EncodePass = encrypt(client.VertificationToken);
            //string url = "https://ros-ta-web.trendy-tech.co/" + "api/Web/User/Verfiy?" + EncodePass + "&" + user.Email;
            //string body = string.Format(@"<div stye='text-align:center;'>
            //<h1>Welcome Our Website</h1>
            //<h3>Click Below For Verify Your Email Id </h3>
            //<form method='post' Action='{0}' 
            // style='display:inline;'>
            // <button type='submit'
            //  style='display: block;
            //  text-align: centre;
            //  font-weight: bold;
            //  background-color: #000CBA;
            //  color: #ffffff;
            //  cursor: pointer;
            //  width: 45%;
            //  height: 0px;
            //  padding: 10%;
            //  border-radius: 14px;'>
            //            Confirm Mail
            //            </button>
            //            </form>
            //            </div> ", url, EncodePass, user.Email);

            //var email = new MimeMessage();
            //email.From.Add(MailboxAddress.Parse("resturent.ty@gmail.com"));

            //email.To.Add(MailboxAddress.Parse(obj.Email));
            //email.Subject = " Vertificated Email ";
            //email.Body = new TextPart(TextFormat.Html)
            //{
            //    Text = body
            //};
            //try
            //{
            //    //send email
            //    using var smtp = new SmtpClient();
            //    smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            //    smtp.Authenticate("resturent.ty@gmail.com", "rbxjaujvpwhvmqsv");
            //    smtp.Send(email);
            //    smtp.Disconnect(true);
            //}
            //catch (Exception e)
            //{
            //    return Ok(e);
            //}
            return Ok();
        }

        private string GenerateAccessToken(int userId)
            {

            var TokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("hdscjasjfhklasjfhSSdfjfjsdjr884237hwd58W73R3QWEJD");
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                        //new Claim(ClaimTypes.Role,role),
                        new Claim(ClaimTypes.Name,userId.ToString()),

                }),
                Expires = DateTime.UtcNow.AddDays(6),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),


            };
            var token = TokenHandler.CreateToken(tokenDescription);

            return TokenHandler.WriteToken(token);


        }
        ///// <summary>
        ///// this two function to encrypt password and decrupt password 
        ///// </summary>

        private string encrypt(string str)
        {
            string _result = string.Empty;
            char[] temp = str.ToCharArray();
            foreach (var _singleChar in temp)
            {
                var i = (int)_singleChar;
                i = i - 2;
                _result += (char)i;
            }
            return _result;
        }
        private string decrypt(string str)
        {
            string _result = string.Empty;
            char[] temp = str.ToCharArray();
            foreach (var _singleChar in temp)
            {
                var i = (int)_singleChar;
                i = i + 2;
                _result += (char)i;
            }
            return _result;
        }


        //[HttpPost]
        //[AllowAnonymous]
        //public async Task<IActionResult> ForgotPassword(string email1)
        //{
        //    var user = _db.Users.FirstOrDefault(u => u.Email == email1);
        //    if (user == null)
        //    {
        //        return BadRequest("Email Not Found");
        //    }

        //    var rand = new Random();

        //    user.PasswordResetToken = rand.Next(1000, 10000).ToString();
        //    user.ResetTokenExpires = DateTime.Now.AddDays(1);
        //    string body = user.PasswordResetToken;

        //    var email = new MimeMessage();
        //    email.From.Add(MailboxAddress.Parse("resturent.ty@gmail.com"));

        //    email.To.Add(MailboxAddress.Parse(email1));
        //    email.Subject = " Code For Reset Password ";
        //    email.Body = new TextPart(TextFormat.Html)
        //    {
        //        Text = body
        //    };
        //    try
        //    {
        //        //send email
        //        using var smtp = new SmtpClient();
        //        smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
        //        smtp.Authenticate("resturent.ty@gmail.com", "rbxjaujvpwhvmqsv");
        //        smtp.Send(email);
        //        smtp.Disconnect(true);
        //    }
        //    catch (Exception e)
        //    {
        //        return Ok(e);
        //    }
        //    _db.SaveChanges();
        //    return Ok(" you may now reset your password");


        //}
        ////[HttpPost]
        ////[AllowAnonymous]
        ////public IActionResult SendEmail()
        ////{


        ////    string body = CreateRandomToken();

        ////    var email = new MimeMessage();
        ////    email.From.Add(MailboxAddress.Parse("santos23@ethereal.email"));

        ////    email.To.Add(MailboxAddress.Parse("santos23@ethereal.email"));
        ////    email.Subject = "Test Email Subject";
        ////    email.Body = new TextPart(TextFormat.Html)
        ////    { 
        ////        Text = body
        ////    };
        ////    //send email
        ////    using var smtp = new SmtpClient();
        ////    smtp.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
        ////    smtp.Authenticate("santos23@ethereal.email", "gNPqxNFANWfuVd5s2A");
        ////    smtp.Send(email);
        ////    smtp.Disconnect(true);
        ////    return Ok();


        ////}
        [HttpPost("{Email}")]
        [AllowAnonymous]
        public async Task<IActionResult> VerfiyCode(VerifyModel model, [FromRoute] string Email)
        {
            var user = _db.clients.FirstOrDefault(u => u.PasswordResetToken == model.Token && u.Email == Email);
            if (user == null || user.ResetTokenExpires < DateTime.Now)
            {
                return BadRequest("Invalid Token");
            }

            return Ok("User-Vertified");

        }

        //[HttpPost("{Email}")]
        //[AllowAnonymous]
        //public async Task<IActionResult> ResetPassword(ForgotPasswordRegister register, [FromRoute] string Email)
        //{
        //    var user = _db.Users.FirstOrDefault(x => x.Email == Email);
        //    if (user == null || user.ResetTokenExpires < DateTime.Now)
        //    {
        //        return BadRequest("Invalid Token");
        //    }
        //    //CreatePassword(register.Password, out string password);
        //    user.ResetTokenExpires = null;
        //    user.PasswordResetToken = null;
        //    user.Password = register.Password;
        //    _db.SaveChanges();
        //    return Ok(" you had reset your password successfully?");


        //}

        ////private void CreatePassword(string password1, out string password2)
        ////{
        ////    using (var hmac=new HMACSHA512()) 
        ////    {
        ////        string j = Convert.ToString(hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password1)));
        ////        password2 = j;

        ////    }

        ////}


        private string CreateRandomToken()
        {
            return Convert.ToHexString(RandomNumberGenerator.GetBytes(4));
        }

        //[HttpGet]
        //[Authorize]
        //public IActionResult DisplayOrder()
        //{
        //    var SiteUrl = Configuration["SiteUrl"];
        //    var userId = Convert.ToInt32(User.Identity.Name);
        //    var customer = _db.Customers.FirstOrDefault(x => x.UsersId == userId);
        //    //var cart = _db.Carts.FirstOrDefault(x=>x.UserId == userId);
        //    var orders = _db.Orders.Where(x => x.CustomerId == customer.Id).ToList();
        //    if (orders == null)
        //    {
        //        return BadRequest();
        //    }


        //    var listOrder = new List<SimpleOrderDto>();


        //    foreach (var order in orders)
        //    {
        //        var listItems = new List<ListMealDto>();
        //        var carts = _db.ListMeals.Where(c => c.OrderId == order.Id).ToList();

        //        var item = new SimpleOrderDto()
        //        {
        //            OrderId = order.Id,
        //            Amount = order.Amount,
        //            TotalPrice = order.TotalPrice,
        //            OrderStatus = order.OrderStatus,
        //            DeleveryType = order.Type,

        //        };

        //        foreach (var item1 in carts)
        //        {

        //            var meal = _db.Meals.FirstOrDefault(x => x.Id == item1.MealsId);
        //            var image = _db.Images.FirstOrDefault(x => x.MealsId == item1.MealsId);

        //            var obj1 = new ListMealDto()
        //            {
        //                Id = item1.Id,
        //                MealId = item1.MealsId,
        //                Price = item1.Price,
        //                Amount = item1.AmountOfMeal,
        //                TotalPriceOfMeal = item1.Price * item1.AmountOfMeal,
        //                Name = meal.Name,
        //                Photo = SiteUrl + "Images/" + image.Imag

        //            };
        //            listItems.Add(obj1);


        //        }
        //        item.ListMeals = listItems;
        //        listOrder.Add(item);

        //    }


        //    return Ok(listOrder);
        //}

        //[HttpPost]
        //[Authorize]
        //public IActionResult DeviceId([FromForm] string Token)
        //{
        //    var userId = Convert.ToInt32(User.Identity.Name);
        //    var user = _db.Customers.FirstOrDefault(x => x.UsersId == userId);
        //    if (user == null)
        //    {
        //        return BadRequest();
        //    }
        //    user.FireBaseToken = Token;
        //    _db.SaveChanges();
        //    return Ok();
        //}



    }
}
