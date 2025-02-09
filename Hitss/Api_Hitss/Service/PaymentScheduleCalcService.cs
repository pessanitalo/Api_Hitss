using Api_Hitss.Interface;
using Api_Hitss.Model;

namespace Api_Hitss.Service
{
    public class PaymentScheduleCalcService : IPaymentScheduleCalcService
    {
        public decimal Amortizacao()
        {
            throw new NotImplementedException();
        }

        public decimal Juros(Proposta proposta)
        {
            return proposta.LoanAmount * (proposta.AnnualInterestRate / 12);
        }

        public decimal ParcelaMensalFixa(Proposta proposta)
        {
            decimal taxaJurosMensal = proposta.AnnualInterestRate /12;
            decimal expo = 1 + taxaJurosMensal;
            decimal ValorEmprestimo = proposta.LoanAmount;
 
            decimal exponente = CalculoExponencial(expo, proposta.NumberOfMonths);

            var primeiraParte = ValorEmprestimo * taxaJurosMensal * exponente;

            var segundaParte = exponente - 1;
            var parcelaMensalFixa = primeiraParte / segundaParte;
            var result = Math.Round(parcelaMensalFixa,2);
            return result;
        }


        static decimal CalculoExponencial(decimal baseValue, int exponent)
        {
            decimal result = 1;
            for (int i = 0; i < exponent; i++)
            {
                result *= baseValue;
            }
            return result;
        }
        public decimal SaldoAtual()
        {
            throw new NotImplementedException();
        }
    }
}
