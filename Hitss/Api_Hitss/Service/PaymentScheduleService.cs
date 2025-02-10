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

        public void Save(Proposta proposta, int id)
        {
            List<PaymentSchedule> paymentSchedules = new List<PaymentSchedule>();

            var numeroParcela = 1;
            decimal saldoAtual = proposta.LoanAmount;
            var quantidadePaymente = proposta.NumberOfMonths;

            for (int i = 0; i < quantidadePaymente; i++)
            {
                decimal teste = 0;
                PaymentSchedule paymentSchedule = new PaymentSchedule
                {
                    PaymentFlowSummary_Id = id,
                    Month = numeroParcela + i,
                    Principal = _calcService.Amortizacao(saldoAtual, proposta),
                    Interest = _calcService.Juros(saldoAtual, proposta),
                    Balance = _calcService.SaldoAtual(saldoAtual, proposta),
                };
                saldoAtual = paymentSchedule.Balance;
                paymentSchedules.Add(paymentSchedule);
            }
            _repository.Save(paymentSchedules);
        }

    }
}
