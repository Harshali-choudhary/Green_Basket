using System.ComponentModel.DataAnnotations;

namespace green_basket.Server.Entities
{
    public class Vegetables
    {
        [Required(ErrorMessage ="Vegetable ID is required")]
        [Range(1,int.MaxValue,ErrorMessage ="Vegetable ID must be a positive integer.")]
        public int vegetable_id {  get; set; }
        [Url(ErrorMessage ="Invalid URl format.")]
        public string image_url { get; set; }
        [Required(ErrorMessage ="Vegetable name is required.")]
        [StringLength(100,ErrorMessage ="Vegetable name can't be longer than 100 characters.")]
        public string vegetable_name { get; set; }
        [Range(0.01,double.MaxValue,ErrorMessage ="Vegetable Price must be greater than 0.")]
        public decimal vegetable_price { get; set; }
        [Range(1,int.MaxValue,ErrorMessage ="Quantity must be at least 1.")]
        public int quantity { get; set; }

        public Vegetables() { }

        public Vegetables(int vegetable_id, string image_url, string vegetable_name, decimal vegetable_price, int quantity)
        {
            this.vegetable_id = vegetable_id;
            this.image_url = image_url;
            this.vegetable_name = vegetable_name;
            this.vegetable_price = vegetable_price;
            this.quantity = quantity;
        }
    }
}
