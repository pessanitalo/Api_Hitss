using Api_Hitss.Interface;
using Api_Hitss.Model;

namespace Api_Hitss.Service
{
    public class PaymentFlowSummaryService : IPaymentFlowSummaryService
    {
        private readonly IPaymentFlowSummaryRepository _paymentFlowSummaryRepository;

        public PaymentFlowSummaryService(IPaymentFlowSummaryRepository paymentFlowSummaryRepository)
        {
            _paymentFlowSummaryRepository = paymentFlowSummaryRepository;
        }

        public PaymentFlowSummary Save(Proposta proposta)
        {
            PaymentFlowSummary payment = new PaymentFlowSummary();
            payment.TotalPayment = 56748;
            payment.TotalInterest = 6748;
            payment.MonthlyPayment = 236450;

            _paymentFlowSummaryRepository.Create(payment);
            return payment;
        }
    }
}
