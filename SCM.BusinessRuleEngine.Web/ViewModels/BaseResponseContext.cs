using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SCM.BusinessRuleEngine.Web.ViewModels
{
    public abstract class BaseReponseContext
    {
        /// <summary>
        /// Gets or sets the error.
        /// </summary>
        /// <value>
        /// The List of errors which needs to be displayed to the user.
        /// </value>
        IEnumerable<Error> Error { get; set; }

        /// <summary>
        /// Gets or sets the status code.
        /// </summary>
        /// <value>
        /// The status code indicating the response status.
        /// </value>
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
    }
}
