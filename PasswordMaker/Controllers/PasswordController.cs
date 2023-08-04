using Microsoft.AspNetCore.Mvc;

namespace PasswordMaker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordController : ControllerBase
    {
        [HttpPost]
        [Route("generate")]
        public ActionResult<string> GeneratePassword([FromBody] PasswordOptions options)
        {
            if (options == null)
            {
                return BadRequest("Invalid input");
            }

            string password = GenerateRandomPassword(options);
            return Ok(password);
        }
        private string GenerateRandomPassword(PasswordOptions options)
        {
            string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789@#$";
            var random = new Random();
            char[] passwordArray = new char[options.Length];

            for (int i = 0; i < options.Length; i++)
            {
                passwordArray[i] = characters[random.Next(characters.Length)];
            }

            var password = new string(passwordArray);
            return password;
        }
    }

    public class PasswordOptions
    {
        public int Length { get; set; }
    }
}
