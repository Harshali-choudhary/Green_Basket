using System.ComponentModel.DataAnnotations;

namespace green_basket.Server.Entities
{
    public enum TransactionMode
    {
        [Display(Name = "Cash on delivery")]
        CashOnDelivery,
        UPI,
        [Display(Name = "Credit Card")]
        CreditCard,
        [Display(Name = "Debit Card")]
        DebitCard
    }
}
