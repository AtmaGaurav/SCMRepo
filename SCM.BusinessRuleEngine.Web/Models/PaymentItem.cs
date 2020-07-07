using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCM.BusinessRuleEngine.Web.Models
{
    public class PaymentItem
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public Decimal Price { get; set; }
    }
}
