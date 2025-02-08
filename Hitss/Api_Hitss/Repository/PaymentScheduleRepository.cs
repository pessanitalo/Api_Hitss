using Api_Hitss.Context;
using Api_Hitss.Interface;
using Api_Hitss.Model;

namespace Api_Hitss.Repository
{
    public class PaymentScheduleRepository : IPaymentScheduleRepository
    {
        private readonly DataContext _context;

        public PaymentScheduleRepository(DataContext context)
        {
            _context = context;
        }

        public void Save(IEnumerable<PaymentSchedule> paymentSchedule)
        {
            _context.AddRange(paymentSchedule);
            _context.SaveChanges();
        }
    }
}
