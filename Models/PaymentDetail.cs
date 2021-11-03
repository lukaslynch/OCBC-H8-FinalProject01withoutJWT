using System;
using System.ComponentModel.DataAnnotations;

namespace _004_LukasHansel_FinalProject.Models
{
    public class PaymentDetail
    {
        [Key]
        public int paymentDetailId { get; set; }
        public string cardOwnerName { get; set; }
        public string cardNumber { get; set; }
        public string expirationDate { get; set; }
        public string securityCode { get; set; }
    }
}
