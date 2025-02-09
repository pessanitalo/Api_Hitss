using Api_Hitss.Model;

namespace Api_Hitss.Interface
{
    public interface IPaymentFlowSummaryService
    {
        PaymentFlowSummary Save(Proposta proposta);
        PaymentFlowSummary Detalhe();

    }
}
