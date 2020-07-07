using SCM.BusinessRuleEngine.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCM.BusinessRuleEngine.Web.ViewModels
{
    public class PackingSlipResponseContext:BaseReponseContext
    {
        public Models.PackingSlip PackingSlipDetails { get; set; }
       
    }
}
