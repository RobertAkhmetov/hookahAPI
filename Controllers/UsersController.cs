using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiForHookahv1._0.Models;

namespace WebApiForHookahv1._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserContext _context;

        public UsersController(UserContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public IEnumerable<User> Getusers()
        {
            return _context.users;
        }

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

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser([FromRoute] int id, [FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
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

        // POST: авторизация пользователя
        [HttpPost]
        public string AutorizationUser(string email, string password)
        {
            int id = 1;
            bool weHaveThisUser = false;
            string result;

            //попробуем найти пользователя с такой почтой
            for (int i=1;i<10;i++)
            {
                var userLoc = _context.users.Find(i);
                if (userLoc != null && userLoc.user_email == email)
                {
                    weHaveThisUser = true;
                    id = i;
                }        
            }

            if (weHaveThisUser)
            {
                var user = _context.users.Find(id);
                if (user.user_password == password)
                    {
                        result = "добро пожаловать";
                    }
                    else
                        result = "отказано в доступе";
            }
            else
                result = "отказано в доступе";
                return result;
        }

        // POST: регистрация пользователя
        [Route("/registration")]
        [HttpPost]
        public string RegistrationUser(string name, string email, string password)
        {
            _context.users.AddRange(
                 new User
                 {
                     user_name = name,
                     user_email = email,
                     user_password = password
                 });
            _context.SaveChanges();
            return "вы успешно зарегистрировались!";

        }

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

        private bool UserExists(int id)
        {
            return _context.users.Any(e => e.id == id);
        }
    }
}