using Api_Hitss.Interface;
using Api_Hitss.Model;

namespace Api_Hitss.Service
{
    public class PaymentScheduleCalcService : IPaymentScheduleCalcService
    {
        public decimal Juros(Proposta proposta)
        {
            return proposta.LoanAmount * TaxaJurosMensal(proposta);
        }

        public decimal TaxaJurosMensal(Proposta proposta)
        {
            return  proposta.AnnualInterestRate / 12;
        }

        public decimal ParcelaMensalFixa(Proposta proposta)
        {
            decimal taxaJurosMensal = TaxaJurosMensal(proposta);
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
        public decimal SaldoAtual(Proposta proposta)
        {
            var saldo = proposta.LoanAmount;
            var valorAmortizado = Amortizacao(proposta);
            return saldo - valorAmortizado;
        }

        public decimal Amortizacao(Proposta proposta)
        {
            var parcelaFixaMensal = ParcelaMensalFixa(proposta);
            var jurosMensal = Juros(proposta);
            return parcelaFixaMensal - jurosMensal;
        }


    }
}
