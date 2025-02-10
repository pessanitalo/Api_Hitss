using Api_Hitss.Context;
using Api_Hitss.Interface;
using Api_Hitss.Model;
using Microsoft.EntityFrameworkCore;


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

        public IEnumerable<PaymentFlowSummary> Detalhes(int PaymentFlowSummary_Id)
        {
            var lista = _context.PaymentFlowSummary.Include(c => c.PaymentSchedule)
                    .Where(x => x.PaymentFlowSummary_Id == PaymentFlowSummary_Id)
                    .ToList();
            return lista;
        }
    }
}
