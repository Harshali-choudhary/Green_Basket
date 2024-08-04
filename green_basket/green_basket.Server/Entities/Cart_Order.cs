using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace green_basket.Server.Entities
{
    public class Cart_Order
    {
        [Key]
        public int Ocart_Id { get; set; }
        [ForeignKey("order_id")]
        public int order_Id { get; set; }

        public Cart_Order() { }

        public Cart_Order(int Ocart_Id, int order_Id)
        {
            this.Ocart_Id = Ocart_Id;
            this.order_Id = order_Id;
        }


    }
}
