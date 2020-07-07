using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCM.BusinessRuleEngine.Web.ViewModels
{
    public class Error
    {
        public string UserMessage { get; set; }

        public string Internalmessage { get; set; }

        public int ErrorCode { get; set; }
    }
}
