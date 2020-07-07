using SCM.BusinessRuleEngine.Web.DataAccess;
using SCM.BusinessRuleEngine.Web.Models;
using SCM.BusinessRuleEngine.Web.Models.Enums;
using SCM.BusinessRuleEngine.Web.Service.Interface;
using SCM.BusinessRuleEngine.Web.ViewModels;

namespace SCM.BusinessRuleEngine.Web.Service
{
    public class BusinessRuleEngineService : IBusinessRuleEngineService
    {
        private readonly IUnitOfWork _unitOfWork;
        public BusinessRuleEngineService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public PackingSlipResponseContext GeneratePackingSlip(int orderId)
        {

            PackingSlip pckslip = new PackingSlip() { PackingSlipId = 1, OrderId = orderId, AddressDetails = "Test Address", ShippedItemDetails = new PaymentItem() { ItemId = 1, ItemName = "Ship", Price = 6000 } };
            //pckslip.Add(new PackingSlip { PackingSlipId = 1, OrderId = 1, AddressDetails = "Test Address", ShippedItemDetails = new PaymentItem() { ItemId = 1, ItemName = "Ship", Price = 6000 } });
            //pckslip.Add(new PackingSlip { PackingSlipId = 1, OrderId = 1, AddressDetails = "Test Address", ShippedItemDetails = new PaymentItem() { ItemId = 1, ItemName = "Ship", Price = 6000 } });
            //pckslip.Add(new PackingSlip { PackingSlipId = 1, OrderId = 1, AddressDetails = "Test Address", ShippedItemDetails = new PaymentItem() { ItemId = 1, ItemName = "Ship", Price = 6000 } });

            PackingSlipResponseContext taskReponseContext = new PackingSlipResponseContext
            {
                PackingSlipDetails = pckslip
                // PackingSlipDetails = _unitOfWork.PackingSlipRepository.GetById(x => x.OrderId == OrderId)
            };
            return taskReponseContext;
        }

        public PackingSlipResponseContext GenerateDuplicatePackingSlip(int orderId)
        {

            PackingSlip pckslip = new PackingSlip() { PackingSlipId = 1, OrderId = orderId, AddressDetails = "Test Address", ShippedItemDetails = new PaymentItem() { ItemId = 1, ItemName = "Ship", Price = 6000 } };
            PackingSlipResponseContext taskReponseContext = new PackingSlipResponseContext
            {
                PackingSlipDetails = pckslip
                // PackingSlipDetails = _unitOfWork.PackingSlipRepository.GetById(x => x.OrderId == OrderId)
            };
            return taskReponseContext;
        }

        public void ActivateMembership(int customerId)
        {
            // Method intentionally left empty.
        }

        public void UpgradeMembership(int customerId)
        {
            // Method intentionally left empty.
        }

        public void NotifyOwnerForMembershipOrUpgrade(PaymentForOrder type)
        {
            // Method intentionally left empty.
        }

        public void AddFirstAidVideotoPackingSlip(PaymentForOrder type)
        {
            // Method intentionally left empty.
        }

        public void GenerateCommisionPaymentForAgent(PaymentForOrder type)
        {
            // Method intentionally left empty.
        }

        public void ExecuteAction(PaymentForOrder type)
        {
            switch (type)
            {
                case PaymentForOrder.PhysicalProduct:
                    GeneratePackingSlip(1);
                    break;
                case PaymentForOrder.Book:
                    GenerateDuplicatePackingSlip(1);
                    break;

                case PaymentForOrder.Membership:
                    ActivateMembership(1);
                    break;

                case PaymentForOrder.Upgrade:
                    UpgradeMembership(1);
                    break;

                case PaymentForOrder.MembershipUpgrade:
                    NotifyOwnerForMembershipOrUpgrade(PaymentForOrder.MembershipUpgrade);
                    break;

                case PaymentForOrder.LearningtoSki:
                    AddFirstAidVideotoPackingSlip(PaymentForOrder.LearningtoSki);
                    break;

                case PaymentForOrder.PhysicalProductBook:
                    GenerateCommisionPaymentForAgent(PaymentForOrder.PhysicalProductBook);
                    break;

              
            }

        }

    }
}
