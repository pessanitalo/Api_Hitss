using System.ComponentModel.DataAnnotations;

namespace Api_Hitss.Model
{
    public class Proposta
    {
        [Key]
        public int Id { get; set; }
        public decimal LoanAmount { get; set; }
        public decimal AnnualInterestRate { get; set; }
        public int NumberOfMonths { get; set; }
    }
}
