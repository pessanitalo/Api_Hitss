using Api_Hitss.Interface;
using Api_Hitss.Model;

namespace Api_Hitss.Service
{
    public class PaymentFlowSummaryService : IPaymentFlowSummaryService
    {
        private readonly IPaymentFlowSummaryRepository _paymentFlowSummaryRepository;
        private readonly IPaymentScheduleCalcService _calcService;

        public PaymentFlowSummaryService(IPaymentFlowSummaryRepository paymentFlowSummaryRepository, IPaymentScheduleCalcService calcService)
        {
            _paymentFlowSummaryRepository = paymentFlowSummaryRepository;
            _calcService = calcService; 
        }

        public PaymentFlowSummary Save(Proposta proposta)
        {
            PaymentFlowSummary payment = new PaymentFlowSummary();
            payment.MonthlyPayment = _calcService.ParcelaMensalFixa(proposta);
            payment.TotalPayment = payment.MonthlyPayment * proposta.NumberOfMonths;
            payment.TotalInterest = payment.TotalPayment - proposta.LoanAmount;
            
            _paymentFlowSummaryRepository.Create(payment);
            return payment;
        }
    }
}
