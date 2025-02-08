using Api_Hitss.Context;
using Api_Hitss.Interface;
using Api_Hitss.Model;


namespace Api_Hitss.Repository
{
    public class PaymentFlowSummaryRepository : IPaymentFlowSummaryRepository
    {
        private readonly DataContext _context;
        public PaymentFlowSummaryRepository(DataContext context)
        {
            _context = context;
        }
        public PaymentFlowSummary Create(PaymentFlowSummary paymentFlowSummary)
        {
            _context.Add(paymentFlowSummary);
            _context.SaveChanges();
            return paymentFlowSummary;
        }
    }
}
