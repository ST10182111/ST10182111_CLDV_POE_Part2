using System.ComponentModel.DataAnnotations;

namespace ST10182111_2024POE.Models
{
    public class UserPaymentEntity
    {
        [Key]
        public int user_Payment_ID { get; set; }
        public required string MethodOfPayment { get; set; }
    }
}
