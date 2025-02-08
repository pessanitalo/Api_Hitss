using Api_Hitss.Model;

namespace Api_Hitss.Interface
{
    public interface IPaymentScheduleRepository
    {
        void Save(IEnumerable<PaymentSchedule> paymentSchedule);
    }
}
