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
        private readonly IPaymentScheduleService _paymentScheduleService;
        private readonly IPaymentFlowSummaryService _paymentService;
        private readonly IPaymentScheduleCalcService _calcService;

        public LoansController(IPropostaService service,
                               IPaymentScheduleService paymentScheduleService,
                               IPaymentFlowSummaryService paymentService,
                               IPaymentScheduleCalcService calcService)
        {
            _service = service;
            _paymentScheduleService = paymentScheduleService;
            _paymentService = paymentService;
            _calcService = calcService; 
        }

        [HttpPost("simulate")]
        public IActionResult Simulate([FromBody] Proposta loans)
        {
            _service.Create(loans);
            _paymentService.Save(loans);
            _paymentScheduleService.Save(loans);

            var resultado = _calcService.ParcelaMensalFixa(loans);

            return Ok("Ok");
        }
    }
}
