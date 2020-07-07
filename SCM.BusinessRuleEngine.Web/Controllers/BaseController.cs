using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SCM.BusinessRuleEngine.Web.ViewModels;
using System;
using System.Diagnostics;
using System.Net;

namespace SCM.BusinessRuleEngine.Web.Controllers
{
    [EnableCors]
    public class BaseController : ControllerBase
    {
        /// <summary>
        /// Creates the Web API output response for succesfull requests.
        /// </summary>
        /// <param name="responseContext">The response context. Needs the HttpStatusCode to be set according to the results.</param>
        /// <param name="data">The data which needs to be passed back to the user.</param>
        /// <returns></returns>
        protected IActionResult CustomResponse(BaseReponseContext responseContext, dynamic data = null)
        {
            return StatusCode((int)responseContext.StatusCode, data);
        }

        /// <summary>
        /// Creates the Web API output response when a handled exception occurs.
        /// </summary>
        /// <param name="ex">The Occurred exception.</param>
        /// <param name="data">The data if any which needs to be passed back to user</param>
        /// <param name="customErrorMessage">The custom error message to be displayed to the user.</param>
        /// <returns></returns>
        protected IActionResult CustomResponse(Exception ex, dynamic data = null, string customErrorMessage = "Internal Server Error")
        {
            LogException(ex);
            return StatusCode((int)HttpStatusCode.InternalServerError, new { data, customErrorMessage });
        }

        /// <summary>
        /// Logs the exception.
        /// </summary>
        /// <param name="ex">The exception which needs to be logged</param>
        protected void LogException(Exception ex)
        {
            Debug.WriteLine(ex);
        }
    }
}