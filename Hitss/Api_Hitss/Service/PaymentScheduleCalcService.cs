using Api_Hitss.Interface;
using Api_Hitss.Model;

namespace Api_Hitss.Service
{
    public class PaymentScheduleCalcService : IPaymentScheduleCalcService
    {
 
        public decimal ParcelaMensalFixa(Proposta proposta)
        {
            decimal taxaJurosMensal = TaxaJurosMensal(proposta);
            decimal expo = 1 + taxaJurosMensal;
            decimal ValorEmprestimo = proposta.LoanAmount;

            decimal exponente = CalculoExponencial(expo, proposta.NumberOfMonths);

            var primeiraParte = ValorEmprestimo * taxaJurosMensal * exponente;

            var segundaParte = exponente - 1;
            var parcelaMensalFixa = primeiraParte / segundaParte;
            var result = Math.Round(parcelaMensalFixa, 2);
            return result;
        }

        public decimal TaxaJurosMensal(Proposta proposta)
        {
            var taxaMensal = proposta.AnnualInterestRate / 12;
            return taxaMensal;
        }

        public decimal Juros(decimal saldoAtual, Proposta proposta)
        {
            var juros = saldoAtual * TaxaJurosMensal(proposta);
            return juros;
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

        public decimal Amortizacao(decimal saldoAtual, Proposta proposta)
        {
            var parcelaFixaMensal = ParcelaMensalFixa(proposta);
            var jurosMensal = Juros(saldoAtual, proposta);
            decimal valorAmortizado = parcelaFixaMensal - jurosMensal;
            return valorAmortizado;
        }

        public decimal SaldoAtual(decimal saldoAtual, Proposta proposta)
        {
            decimal saldo;
            var valorAmortizado = Amortizacao(saldoAtual, proposta);
            saldo = saldoAtual - valorAmortizado;
            return saldo;
        }
    }
}
