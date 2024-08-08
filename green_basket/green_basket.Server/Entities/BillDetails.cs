using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace green_basket.Server.Entities
{
    public class BillDetails
    {
        [Key]
        public int bill_id { get; set; }
        [ForeignKey("user_Id")]
        public int user_id { get; set; }
        [ForeignKey("order_id")]
        public int order_Id { get; set; }
        [Required]
        public DateTime transactonDate { get; set; }
        [Required]
        public TransactionMode transactionMode { get; set; }
        [Required]
        public TransactionStatus status { get; set; }

        public BillDetails()
        {

        }

        public BillDetails(int bill_id, int user_id, int order_Id, DateTime transactonDate, TransactionMode transactionMode, TransactionStatus status)
        {
            this.bill_id = bill_id;
            this.user_id = user_id;
            this.order_Id = order_Id;
            this.transactonDate = transactonDate;
            this.transactionMode = transactionMode;
            this.status = status;
        }
    }
}
