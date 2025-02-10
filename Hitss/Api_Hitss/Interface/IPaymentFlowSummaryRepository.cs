using Api_Hitss.Model;

namespace Api_Hitss.Interface
{
    public interface IPaymentFlowSummaryRepository
    {
        PaymentFlowSummary Create(PaymentFlowSummary paymentFlowSummary);
        IEnumerable<PaymentFlowSummary> Detalhes(int id);
    }
}
