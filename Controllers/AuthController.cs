using AutoDataHub.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutoDataHub.Controllers
{
    public class AuthController : Controller
    {
        // POST: api/auth/register
        [HttpPost("register")]
        public IActionResult Register([FromBody] UserModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // ปลอมข้อมูลการลงทะเบียน (ในโค้ดจริงให้ใช้บริการจัดการผู้ใช้และฐานข้อมูล)
            // ตัวอย่าง: AddUserToDatabase(model);

            return Ok(new { Message = "Registration successful" });
        }

        // POST: api/auth/login
        [HttpPost("login")]
        public IActionResult Login([FromBody] UserModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // การตรวจสอบข้อมูลเข้าสู่ระบบ (ในโค้ดจริงให้ตรวจสอบข้อมูลกับฐานข้อมูล)
            // ตัวอย่าง: var user = AuthenticateUser(model.Username, model.Password);

            bool isAuthenticated = AuthenticateUser(model.Username, model.PasswordHash); // ปลอมการตรวจสอบ

            if (!isAuthenticated)
            {
                return Unauthorized(new { Message = "Invalid credentials" });
            }

            // ส่งคืน token หรือข้อมูลที่เกี่ยวข้องกับการเข้าสู่ระบบ
            return Ok(new { Message = "Login successful", Token = "dummy-token" });
        }

        // ปลอมการตรวจสอบข้อมูลผู้ใช้
        private bool AuthenticateUser(string username, string password)
        {
            // ในการทำงานจริงให้ตรวจสอบข้อมูลผู้ใช้จากฐานข้อมูลหรือบริการจัดการผู้ใช้
            // ตัวอย่างนี้จะรับทุกคนที่ใช้ username "testuser" และ password "password123"
            return username == "testuser" && password == "password123";
        }
    }
}
