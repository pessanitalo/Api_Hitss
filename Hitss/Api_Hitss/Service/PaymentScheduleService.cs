using Api_Hitss.Interface;
using Api_Hitss.Model;

namespace Api_Hitss.Service
{
    public class PaymentScheduleService : IPaymentScheduleService
    {
        public readonly IPaymentScheduleRepository _repository;
        private readonly IPaymentScheduleCalcService _calcService;

        public PaymentScheduleService(IPaymentScheduleRepository repository, IPaymentScheduleCalcService calcService)
        {
            _repository = repository;
            _calcService = calcService;
        }

        public void Save(Proposta proposta)
        {
            List<PaymentSchedule> paymentSchedules = new List<PaymentSchedule>();

            var numeroParcela = 1;
            decimal saldoAtual = 0;
            var quantidadePaymente = proposta.NumberOfMonths;

            for (int i = 0; i < quantidadePaymente; i++)
            {
                PaymentSchedule paymentSchedule = new PaymentSchedule
                {
                    PaymentFlowSummary_Id = proposta.Id,
                    Month = numeroParcela + i,
                    Principal = _calcService.Amortizacao(proposta),
                    Interest = _calcService.Juros(proposta),
                    Balance = _calcService.SaldoAtual(proposta)
                };
                paymentSchedules.Add(paymentSchedule);
                proposta.LoanAmount = paymentSchedule.Balance;
            }
            _repository.Save(paymentSchedules);
        }

    }
}
