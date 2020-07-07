using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCM.BusinessRuleEngine.Web.Models
{
    public class PackingSlip
    {
        public int PackingSlipId { get; set; }
        public int OrderId { get; set; }
        public string AddressDetails { get; set; }
        public PaymentItem ShippedItemDetails { get; set; }
 
    }
}
