using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace green_basket.Server.Entities
{
    public class Orders
    {
        [Key]
        public int order_id { get; set; }
        [ForeignKey("user_Id")]
        public int user_id { get; set; }

        [Required]
        public Status status { get; set; }
        [Required(ErrorMessage = "Order date is required.")]
        public DateTime order_date { get; set; }
        [Required(ErrorMessage ="Shipping date is required.")]
        public DateTime shipping_date { get; set; }
        [Required(ErrorMessage ="Shipping Address is required.")]
        public string shipping_address { get; set; }
        [Range(0.01,double.MaxValue,ErrorMessage ="Total amount must be greater than 0")]
        public decimal total_amount { get; set; }

        public Orders() { 
        }
       
    }
}
