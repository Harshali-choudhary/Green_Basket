using green_basket.Server.Entities;


namespace green_basket.Server.Models
{
    public class UserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public Role Role { get; set; }
        public string Password { get; set; } 
        public string Email { get; set; }
        public string MobileNo { get; set; }
    }
}
