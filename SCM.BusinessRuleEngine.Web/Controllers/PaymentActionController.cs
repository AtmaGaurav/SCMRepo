using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SCM.BusinessRuleEngine.Web.Models.Enums;
using SCM.BusinessRuleEngine.Web.Service.Interface;

namespace SCM.BusinessRuleEngine.Web.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    [ApiController]
    public class PaymentActionController : BaseController
    {
        private readonly IBusinessRuleEngineService _businessRuleEngineService;

        public PaymentActionController(IBusinessRuleEngineService businessRuleEngineService)
        {
            _businessRuleEngineService = businessRuleEngineService;
        }

        [HttpPost]
        [Route("ExecuteRule")]
        public async Task<IActionResult> Post([FromBody] string type)
        {
            try
            {
                PaymentForOrder foo = (PaymentForOrder)Enum.Parse(typeof(PaymentForOrder), type);
                _businessRuleEngineService.ExecuteAction(foo);
                return Ok();
            }
            catch (Exception ex)
            {
                return CustomResponse(ex, null,
                    "Could not execute the Rule. Please try again later or contact the administrator");
            }
        }
    }
}