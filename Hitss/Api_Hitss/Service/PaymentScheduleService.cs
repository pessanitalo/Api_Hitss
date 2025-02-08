using Api_Hitss.Interface;
using Api_Hitss.Model;

namespace Api_Hitss.Service
{
    public class PaymentScheduleService : IPaymentScheduleService
    {
        public readonly IPaymentScheduleRepository _repository;

        public PaymentScheduleService(IPaymentScheduleRepository repository)
        {
            _repository = repository;
        }

        public void Save(Proposta proposta)
        {
            List<PaymentSchedule> paymentSchedules = new List<PaymentSchedule>();

            var numeroParcela = 1;

            var quantidadePaymente = proposta.NumberOfMonths;

            for (int i = 0; i < quantidadePaymente; i++)
            {
                PaymentSchedule paymentSchedule = new PaymentSchedule
                {
                    Month = numeroParcela + i,
                    Principal = 186450,
                    Interest = 500,
                    Balance = 4813550,
                };

                paymentSchedules.Add(paymentSchedule);
            }
            _repository.Save(paymentSchedules);
        }

    }
}
