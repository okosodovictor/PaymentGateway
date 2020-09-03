using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PaymentGateway.API.Models;
using PaymentGateway.Application;
using PaymentGateway.Application.Business;
using PaymentGateway.Domain;
using System;
using System.Threading.Tasks;

namespace PaymentGateway.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly ILogger<PaymentsController> _logger;
        private readonly IPaymentService _service;

        public PaymentsController(IPaymentService service, ILogger<PaymentsController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PaymentRequest model)
        {
            try
            {
                var response = await _service.RequestPayment(model);
                return Ok(response);
            }
            catch (ArgumentException agex)
            {
                _logger.LogError(agex.Message);
                return BadRequest(agex);
            }
            catch (NotFoundException nfex)
            {
                _logger.LogError(nfex.Message);
                return NotFound(nfex.Message);
            }
        }

        [HttpGet("{reference}")]
        public async Task<IActionResult> Get(string reference)
        {
            if (string.IsNullOrEmpty(reference))
            {
                return BadRequest("Payment Reference is Empty");
            }
            var response = await _service.GetPaymentByReference(reference);
            if (response == null)
            {
                return NotFound($"No Payment exist with Reference Number:  {reference}");
            }
            else
            {
                return Ok(new PaymentDto
                {
                    Reference = response.Reference,
                    Status = response.Status.ToString(),
                    Amount = response.Amount,
                    CardNumber = response.CardNumber,
                    Currency = response.Currency,
                    CardHolderName = response.CardHolderName,
                    ExpiringDate = response.ExpiryMonth +"/"+ response.ExpiryYear
                });
            }
        }
    }
}
