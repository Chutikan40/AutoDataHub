namespace AutoDataHub.Models
{
    public class UserModel
    {
        public int Id { get; set; } // Primary Key
        public string Username { get; set; } // ชื่อผู้ใช้
        public string Email { get; set; } // อีเมล
        public string PasswordHash { get; set; } // รหัสผ่านที่เข้ารหัส
        public string Role { get; set; } // บทบาทของผู้ใช้ (ถ้าจำเป็น)
    }
}
