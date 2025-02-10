using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Api_Hitss.Model
{
    public class PaymentSchedule
    {
        [Key]
        public int PaymentSchedule_Id { get; set; }
        public int PaymentFlowSummary_Id { get; set; }
        public int Month { get; set; }
        public decimal Principal { get; set; }
        public decimal Interest { get; set; }
        public decimal Balance { get; set; }
        [JsonIgnore]
        public PaymentFlowSummary PaymentFlowSummary { get; set; }
    }
}
