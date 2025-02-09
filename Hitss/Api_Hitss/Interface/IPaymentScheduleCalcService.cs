using Api_Hitss.Model;

namespace Api_Hitss.Interface
{
    public interface IPaymentScheduleCalcService
    {
        Decimal Juros(Proposta proposta);
        Decimal Amortizacao(Proposta proposta);
        Decimal SaldoAtual(Proposta proposta);
        Decimal ParcelaMensalFixa(Proposta proposta);
        Decimal TaxaJurosMensal(Proposta proposta);
    }
}
