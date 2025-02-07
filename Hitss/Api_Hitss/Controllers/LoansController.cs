using Api_Hitss.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_Hitss.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        [HttpPost("simulate")]
        public IActionResult Simulate([FromBody] Proposta loans)
        {
            return Ok(loans);
        }

        [HttpGet("paymentschedule")]
        public IActionResult paymentSchedule([FromBody] PaymentFlowSummary paymentFlowSummary)
        {
            return Ok(paymentFlowSummary);
        }
    }
}
