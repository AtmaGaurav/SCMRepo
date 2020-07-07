using SCM.BusinessRuleEngine.Web.Models.Enums;
using SCM.BusinessRuleEngine.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCM.BusinessRuleEngine.Web.Service.Interface
{
    public interface IBusinessRuleEngineService
    {
        PackingSlipResponseContext GeneratePackingSlip(int OrderId);

        PackingSlipResponseContext GenerateDuplicatePackingSlip(int OrderId);

        void ActivateMembership(int CustomerId);
        void UpgradeMembership(int CustomerId);

        void NotifyOwnerForMembershipOrUpgrade(PaymentForOrder type);

        void AddFirstAidVideotoPackingSlip(PaymentForOrder type);

        void GenerateCommisionPaymentForAgent(PaymentForOrder type);

        void ExecuteAction(PaymentForOrder type);
    }
}
