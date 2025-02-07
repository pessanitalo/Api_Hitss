using System.ComponentModel.DataAnnotations;

namespace Api_Hitss.Model
{
    public class PaymentFlowSummary
    {
        [Key]
        public int Id { get; set; }
        public decimal MonthlyPayment { get; set; }
        public decimal TotalInterest { get; set; }
        public decimal TotalPayment { get; set; }
        public IEnumerable<PaymentSchedule> PaymentSchedule { get; set; }
    }
}
