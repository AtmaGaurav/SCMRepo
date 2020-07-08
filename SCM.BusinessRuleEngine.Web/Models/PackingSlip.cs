using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCM.BusinessRuleEngine.Web.Models
{
    /// <summary>
    /// packing Slip class and its property
    /// </summary>
    public class PackingSlip
    {
        public Guid PackingSlipId { get; set; }
        public int OrderId { get; set; }
        public string AddressDetails { get; set; }
        public Department DepartmentDetails { get; set; }
        public PaymentItem ShippedItemDetails { get; set; }
 
    }
}
