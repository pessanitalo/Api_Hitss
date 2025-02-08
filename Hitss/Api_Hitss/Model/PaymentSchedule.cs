using System.ComponentModel.DataAnnotations;

namespace Api_Hitss.Model
{
    public class PaymentSchedule
    {
        [Key]
        public int PaymentSchedule_Id { get; set; }
        public int Month { get; set; }
        public int Principal { get; set; }
        public int Interest { get; set; }
        public int Balance { get; set; }
    }
}
