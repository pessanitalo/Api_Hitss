using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Api_Hitss.Model
{
    public class Proposta
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "O valor do empréstimo deve ser maior que 0.")]
        [DefaultValue(0)]
        public decimal LoanAmount { get; set; }


        [Required(ErrorMessage = "Campo Obrigatório.")]
        [Range(0.01, int.MaxValue, ErrorMessage = "A taxa deve ser maior que 0.")]
        [DefaultValue(0)]
        public decimal AnnualInterestRate { get; set; }


        [Required(ErrorMessage = "Campo Obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "O numero de parcelas deve ser maior que 0.")]
        [DefaultValue(0)]
        public int NumberOfMonths { get; set; }
    }
}
