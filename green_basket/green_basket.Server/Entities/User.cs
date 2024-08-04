using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace green_basket.Server.Entities
{
    public class User
    {
        [Key]
        public int user_Id { get; set; }
        [Required(ErrorMessage = "first name is required")]
        [StringLength(50, ErrorMessage = "first name cann't be longer than 50 character")]
        public string first_name { get; set; }
        [Required(ErrorMessage = "last name is required")]
        [StringLength(50, ErrorMessage = "last name cann't be longer than 50 character")]
        public string last_name { get; set; }
        [Required(ErrorMessage = "email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [StringLength(100,MinimumLength =6,ErrorMessage ="Password must be atleast 6 letter long")]
        public string password { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string address { get; set; }
        [Required(ErrorMessage ="Mobile no is required")]
        [Phone(ErrorMessage ="Invalid Mobile no")]
        public string mobile_no { get; set; }
        [Required(ErrorMessage ="Role Should be Customer or Admin")]
        public Role role { get; set; }

        public User() { }

        public User(int userId,string firstname,string lastname,string Email,string Password,string Address,string phone,Role role)
        {
            user_Id=userId;
            first_name=firstname;
            last_name=lastname;
            email = Email;
            password = Password;
            address = Address;
            mobile_no=phone;
            this.role = role;
        }

    }
}
