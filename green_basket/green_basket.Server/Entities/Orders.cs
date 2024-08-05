using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace green_basket.Server.Entities
{
    public class Orders
    {
        [Required(ErrorMessage ="Order ID is required.")]
        [Range(1,int.MaxValue,ErrorMessage ="Order ID must be greater than 1.")]
        public int order_id { get; set; }
        [ForeignKey("user_Id")]
        public int user_Id { get; set; }
        [Required(ErrorMessage ="Order date is required.")]
        public DateTime order_date { get; set; }
        [Required(ErrorMessage ="Shipping date is required.")]
        public DateTime shipping_date { get; set; }
        [Required(ErrorMessage ="Shipping Address is required.")]
        public string shipping_address { get; set; }
        [Range(0.01,double.MaxValue,ErrorMessage ="Total amount must be greater than 0")]
        public decimal total_amount { get; set; }

        public Orders() { 
        }
        public Orders(int order_id, int user_id, DateTime order_date, DateTime shipping_date, string shipping_address, decimal total_amount)
        {
            this.order_id = order_id;
            this.user_Id = user_id;
            this.order_date = order_date;
            this.shipping_date = shipping_date;
            this.shipping_address = shipping_address;
            this.total_amount = total_amount;
        }
    }
}
