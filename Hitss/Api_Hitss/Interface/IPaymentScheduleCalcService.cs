using Api_Hitss.Model;

namespace Api_Hitss.Interface
{
    public interface IPaymentScheduleCalcService
    {
        Decimal Juros(decimal saldoAtual, Proposta proposta);
        Decimal Amortizacao(decimal saldoAtual, Proposta proposta);
        Decimal SaldoAtual(decimal saldoAtual, Proposta proposta);
        Decimal ParcelaMensalFixa(Proposta proposta);
        Decimal TaxaJurosMensal(Proposta proposta);
    }
}
