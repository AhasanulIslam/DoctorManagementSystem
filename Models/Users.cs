using System.ComponentModel.DataAnnotations;

namespace DoctorManagement.Models
{
    public class Users
    {
    
        [Key]
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname {get; set; }
        public string Contrct {get; set; }
        public string Email { get; set; }
        public string  Phone { get; set; }
        public string Password  { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Token { get; set; } 

    }
}