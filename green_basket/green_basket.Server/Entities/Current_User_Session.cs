using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace green_basket.Server.Entities
{
    public class Current_User_Session
    {
        [Key]
        public  int Id { get; set; }
        [ForeignKey("user_id")]
        public int user_Id { get; set; }

        [Required]
        public Role role {  get; set; }
        [Required]
        public DateTime dateTime { get; set; }

        public  Current_User_Session() { }

        public Current_User_Session(int id, int user_Id, Role role, DateTime dateTime)
        {
            Id = id;
            this.user_Id = user_Id;
            this.role = role;
            this.dateTime = dateTime;
        }
    }
}
