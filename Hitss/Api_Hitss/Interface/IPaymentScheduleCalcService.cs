using Api_Hitss.Model;

namespace Api_Hitss.Interface
{
    public interface IPaymentScheduleCalcService
    {
        Decimal Juros(Proposta proposta);
        Decimal Amortizacao();
        Decimal SaldoAtual();
        Decimal ParcelaMensalFixa(Proposta proposta);
    }
}
