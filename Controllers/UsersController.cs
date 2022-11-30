using System;
using System.Collections.Generic;
using System.Linq;
//using System.Linq.Async;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System.Net;
using System.Net.Mail;

namespace WebApplication2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserContext _context;

        public UserController(UserContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public IEnumerable<User> Getusers()
        {
            return _context.users;
        }

        //Получение профиля пользователя
        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _context.users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }


        //обновление профиля
        // PUT: api/Users/
        [HttpPut]
        public async Task PutUser([FromBody] Dictionary<string, string> userData)
        {
            int id = Convert.ToInt32(userData["id"]);
            var user = await _context.users.FindAsync(id);

            user.email = userData["email"];
            user.name = userData["name"];

            //_context.SaveChanges();
            await _context.SaveChangesAsync();

            /*try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    
                }
                else
                {
                    throw;
                }
            }*/

        }

        // POST: api/Users
        /*
        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.id }, user);
        }
        */

        //удаление профиля
        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _context.users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.users.Remove(user);
            await _context.SaveChangesAsync();

            return Ok(user);
        }

        //не уверен, что это используется
        private bool UserExists(int id)
        {
            return _context.users.Any(e => e.id == id);
        }
    }


    //получение отзывов, которые оставил пользователь
    [Route("user/{id}/reviews")]
    [ApiController]
    public class UsersReviewController : Controller
    {
        private readonly UserContext _userContext;
        private readonly ReviewContext _reviewContext;

        public UsersReviewController(UserContext userContext, ReviewContext reviewContext)
        {
            _userContext = userContext;
            _reviewContext = reviewContext;
        }

        [HttpGet]
        public async Task<string> ShowUserReviews(int id)
        {
            string result;
            List<Review> reviews = new List<Review>();
            //User user = _userContext.users.Where(u => u.id == id).FirstOrDefault();      
            var revFL = _reviewContext.reviews.Where(r => r.idUser == id);

            List<ReviewForUserReviewList> resultList = new List<ReviewForUserReviewList>();
            foreach (Review fullFieldReview in revFL)
            {
                resultList.Add(new ReviewForUserReviewList
                {
                    id = fullFieldReview.id,
                    idHookah = fullFieldReview.idHookah,
                    comment = fullFieldReview.comment,
                    rating = fullFieldReview.rating,
                    dateCreate = fullFieldReview.dateCreate
                }
                );
            }

            result = JsonConvert.SerializeObject(resultList);
            return result;
        }

    }

    //не делаю асинхронным, т.к. это вызываем только мы
    //получение списка пользователей
    [Route("users/list")]
    [ApiController]
    public class UsersListController : Controller
    {
        private readonly UserContext _context;

        public UsersListController(UserContext context)
        {
            _context = context;
        }

        // POST: получение списка пользователей
        [HttpPost]
        public List<User> ShowUsersList()
        {
            return _context.users.ToList();
        }

    }


    // POST: авторизация пользователя по почте и паролю
    [Route("auth/login")]
    [ApiController]
    public class LoginController : Controller
    {

        private readonly UserContext _context;

        public LoginController(UserContext context)
        {
            _context = context;
        }

        //авторизация пользователя
        [HttpPost]
        public async Task<IActionResult> AutorizationUser([FromBody] Dictionary<string, string> dictUsersData)
        {
            string auth_user_email = dictUsersData["email"];
            string auth_user_password = dictUsersData["password"];

            bool weHaveThisUser = false;
            bool mustGenerateToken = default;
            string result = "пользователь с таким email не обнаружен";

            var userLoc = _context.users.Where(h => h.email == auth_user_email);
            if (userLoc != null)//или false?)
                weHaveThisUser = true;

            if (weHaveThisUser)
            {
                //выполняется верификация хэша
                PasswordHasher<User> ph = new PasswordHasher<User>();

                foreach (User userd in userLoc)
                {
                    PasswordVerificationResult resultComp = ph.VerifyHashedPassword(userd, userd.user_password_hash, auth_user_password);

                    if (resultComp != PasswordVerificationResult.Failed)
                    {
                        result = "добро пожаловать (хэш совпадает)";

                        mustGenerateToken = true;

                        break;
                    }
                    else
                        result = "неверный пароль";
                }
            }

            if(mustGenerateToken)
            {
                //тут генерируем токен, тк авторизация успешно пройдена
            }

            if (result == "неверный пароль" || result == "пользователь с таким email не обнаружен")
                return NotFound(result);
            return Ok(result);

        }

    }

    //регистрация пользователя
    [Route("auth/registration")]
    [ApiController]
    public class RegistrationController : Controller
    {
        private readonly UserContext _context;

        public RegistrationController(UserContext context)
        {
            _context = context;
        }

        public async Task SendMail() // отправка на почту верификационного письма
        {
            // отправитель - устанавливаем адрес и отображаемое в письме имя
            MailAddress from = new MailAddress("robertakhmetov@bk.ru", "Rob");
            // кому отправляем
            MailAddress to = new MailAddress("leadersclub777@gmail.com");
            // создаем объект сообщения
            MailMessage m = new MailMessage(from, to);
            // тема письма
            m.Subject = "Подтверждение почты для регистрации WhereHookah";
            // текст письма
            m.Body = "<h2>Добрый день! Чтобы подтвердить вашу почту, перейдите по ссылке ниже:</h2>";
            // письмо представляет код html
            m.IsBodyHtml = true;
            // адрес smtp-сервера и порт, с которого будем отправлять письмо
            SmtpClient smtp = new SmtpClient("smtp.mail.ru", 587);
            // логин и пароль
            smtp.Credentials = new NetworkCredential("robertakhmetov@bk.ru", "JFZGHTwqAxs60thkfAct");
            smtp.EnableSsl = true;

            //smtp.Send(m);
            await smtp.SendMailAsync(m);
        }

        // POST: регистрация пользователя
        [HttpPost]
        public async Task<IActionResult> RegistrationUser([FromBody] Dictionary<string, string> dictRegUserData)
        {
            var userFindAnalogEmail = _context.users.Where(h => h.email == dictRegUserData["email"]);
            if (userFindAnalogEmail.Any())
                return NotFound("пользователь с таким email уже существует!");

            User newUser = new User
            {
                name = dictRegUserData["name"],
                email = dictRegUserData["email"],
                user_password_hash = dictRegUserData["password"]
            };

            //тут отправим на почту
            await SendMail();

            //хэшируем пароль (v2)
            PasswordHasher<User> ph = new PasswordHasher<User>();
            newUser.user_password_hash = ph.HashPassword(newUser, dictRegUserData["password"]);


            //сохраняем в БД
            await _context.users.AddRangeAsync(newUser);
            await _context.SaveChangesAsync();

            return Ok("вы успешно зарегистрировались!");

        }

    }


    //сброс пароля
    [Route("auth/reset-password")]
    [ApiController]
    public class ResetPasswordController : Controller
    {
        private readonly UserContext _context;

        public ResetPasswordController(UserContext context)
        {
            _context = context;
        }

        // POST: сброс пароля
        [HttpPost]
        public async Task<string> ResetPasswordUser([FromBody] Dictionary<string, string> dictUserData)
        {
            var user = _context.users.Where(h => h.email == dictUserData["email"]);
            if (!user.Any())
                return "пользователь с таким email не был зарегистрирован";


            /* далее реализоввываетвя сборка токена, отправка на почту формы, смена пароля */
            return "процесс сброса пароля начался!";
        }

    }



    //изменение пароля
    [Route("auth/change-password")]
    [ApiController]
    public class ChangePasswordController : Controller
    {
        private readonly UserContext _context;

        public ChangePasswordController(UserContext context)
        {
            _context = context;
        }

        // PUT: смена пароля
        [HttpPut]
        public async Task<string> ChangePasswordUser([FromBody] Dictionary<string, string> dictUserData)
        {

            int id = Convert.ToInt32(dictUserData["idUser"]);
            var user = await _context.users.FindAsync(id);

            //хэшируем новый пароль
            PasswordHasher<User> ph = new PasswordHasher<User>();
            user.user_password_hash = ph.HashPassword(user, dictUserData["password"]);

            //сохраняем в БД
            await _context.SaveChangesAsync();

            return "пароль успешно изменен!";

        }

    }


}
