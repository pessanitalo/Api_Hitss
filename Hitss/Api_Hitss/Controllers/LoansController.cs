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
        private readonly IPaymentFlowSummaryService _resumoTaxService;

        public LoansController(IPropostaService service,
                               IPaymentScheduleService paymentScheduleService,
                               IPaymentFlowSummaryService paymentService)
        {
            _service = service;
            _paymentScheduleService = paymentScheduleService;
            _resumoTaxService = paymentService;
        }

        [HttpPost("simulate")]
        public IActionResult Simulate([FromBody] Proposta loans)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _service.Create(loans);
            var resumoTaxa = _resumoTaxService.Save(loans);
            _paymentScheduleService.Save(loans, resumoTaxa.PaymentFlowSummary_Id);
            var listaDetalhes = _resumoTaxService.Detalhes(resumoTaxa.PaymentFlowSummary_Id);

            return Ok(listaDetalhes);
        }
    }
}
