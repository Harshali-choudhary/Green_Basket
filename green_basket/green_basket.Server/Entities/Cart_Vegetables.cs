using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace green_basket.Server.Entities
{
    public class Cart_Vegetables
    {
        [Required(ErrorMessage="Cart ID is required")]
        [Range(1,int.MaxValue,ErrorMessage ="Cart ID must be a positive integer.")]
        public int vcart_id { get; set; }
        [ForeignKey("vegetable_id")]
        public int vegetables_id { get; set; }
        [Required(ErrorMessage ="Name is required")]
        [StringLength(100,ErrorMessage ="Name can't be longer than 100 characters. ")]
        public string name { get; set; }
        [Url(ErrorMessage ="Invalid URL format")]
        public string image_url { get; set; }
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be grater than 0.")]
        public decimal price { get; set; }
        [Range(1,int.MaxValue,ErrorMessage ="Quantity must be at least 1")]
        public int quantity { get; set; }

        public Cart_Vegetables() {
        }

        public Cart_Vegetables(int vcart_id, int vegetables_id, string name, string image_url, decimal price, int quantity)
        {
            this.vcart_id = vcart_id;
            this.vegetables_id = vegetables_id;
            this.name = name;
            this.image_url = image_url;
            this.price = price;
            this.quantity = quantity;
        }
    }
}
