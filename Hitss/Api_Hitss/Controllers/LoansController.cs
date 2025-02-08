using Api_Hitss.Context;
using Api_Hitss.Interface;
using Api_Hitss.Model;
using Microsoft.AspNetCore.Mvc;

namespace Api_Hitss.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        private readonly IPropostaService _service;
        private readonly IPaymentFlowSummaryRepository _paymentFlowSummaryRepository;
        private readonly IPaymentScheduleService _paymentScheduleService;

        public LoansController(IPropostaService service, IPaymentFlowSummaryRepository paymentFlowSummaryRepository,
                                 IPaymentScheduleService paymentScheduleService)
        {
            _service = service;
            _paymentFlowSummaryRepository = paymentFlowSummaryRepository;
            _paymentScheduleService = paymentScheduleService;
        }

        [HttpPost("simulate")]
        public IActionResult Simulate([FromBody] Proposta loans)
        {
            _service.Create(loans);

            PaymentFlowSummary payment = new PaymentFlowSummary();

            payment.TotalPayment = 56748;
            payment.TotalInterest = 6748;
            payment.MonthlyPayment = 236450;

            _paymentFlowSummaryRepository.Create(payment);

            _paymentScheduleService.Save(loans);

            return Ok("Ok");
        }

        //[HttpGet("paymentschedule")]
        //public IActionResult paymentSchedule([FromBody] PaymentFlowSummary paymentFlowSummary)
        //{
        //    return Ok(paymentFlowSummary);
        //}
    }
}
