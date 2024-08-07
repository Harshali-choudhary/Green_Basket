using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace green_basket.Server.Entities
{
    public class Cart_Vegetables
    {
        [Key]
        public int vcart_id { get; set; }
        [ForeignKey("vegetable_id")]
        public int vegetable_id { get; set; }
        
        

        public Cart_Vegetables() {
        }

       
    }
}
