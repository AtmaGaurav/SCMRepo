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

        //Dependency injection for unit of Work pattern
        public BusinessRuleEngineService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Execute Action has switch case to execute appropriate action based on Payment type
        /// </summary>
        /// <param name="type">Enum value of the selected payment type</param>
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

        /// <summary>
        /// Method for generating PackingSlip details
        /// </summary>
        /// <param name="orderId">Order Id number</param>
        /// <returns>PackingSlipResponseContext</returns>
        public PackingSlipResponseContext GeneratePackingSlip(int orderId)
        {

            PackingSlip pckslip = new PackingSlip() { PackingSlipId = System.Guid.NewGuid(), OrderId = orderId, AddressDetails = "Test Address", ShippedItemDetails = new PaymentItem() { ItemId = 1, ItemName = "DrugsContainer", Price = 60000 } };
            PackingSlipResponseContext taskReponseContext = new PackingSlipResponseContext
            {
                PackingSlipDetails = pckslip
                // PackingSlipDetails = _unitOfWork.PackingSlipRepository.GetById(x => x.OrderId == OrderId)
            };
            return taskReponseContext;
        }

        /// <summary>
        /// Method for generating Duplicate PackingSlip details for Royalty Department
        /// </summary>
        /// <param name="orderId">Order Id number</param>
        /// <returns>PackingSlipResponseContext</returns>

        public PackingSlipResponseContext GenerateDuplicatePackingSlip(int orderId)
        {

            PackingSlip pckslip = new PackingSlip() { PackingSlipId = System.Guid.NewGuid(), OrderId = orderId, AddressDetails = "Sample Address",DepartmentDetails = new Department { DepartmentId=1,DepartmentName ="Royalty"}, ShippedItemDetails = new PaymentItem() { ItemId = 1, ItemName = "Drugs", Price = 6000 } };
            PackingSlipResponseContext taskReponseContext = new PackingSlipResponseContext
            {
                PackingSlipDetails = pckslip
            };
            return taskReponseContext;
        }
        /// <summary>
        /// Method that will have logic to implement Activate Memebership
        /// </summary>
        /// <param name="customerId">CustomerId Number</param>

        public void ActivateMembership(int customerId)
        {
            // Method intentionally left empty.
        }

        /// <summary>
        /// Method that will have logic to implement Upgrade Memebership
        /// </summary>
        /// <param name="customerId">CustomerId Number</param>
        public void UpgradeMembership(int customerId)
        {
            // Method intentionally left empty.
        }

        /// <summary>
        /// NotifyOwnerForMembershipOrUpgrade method has logic to notify Owner and upgrade membership
        /// </summary>
        /// <param name="type"></param>
        public void NotifyOwnerForMembershipOrUpgrade(PaymentForOrder type)
        {
            // Method intentionally left empty.
        }

        /// <summary>
        /// AddFirstAidVideotoPackingSlip method has logic to add firstadidvideo to packing Slip
        /// </summary>
        /// <param name="type"></param>
        public void AddFirstAidVideotoPackingSlip(PaymentForOrder type)
        {
            // Method intentionally left empty.
            PackingSlip pckslip = new PackingSlip() { PackingSlipId = System.Guid.NewGuid(), OrderId = 1, AddressDetails = "Test Address", ShippedItemDetails = new PaymentItem() { ItemId = 2, ItemName = "First Aid", Price = 0 } };
            PackingSlipResponseContext taskReponseContext = new PackingSlipResponseContext
            {
                PackingSlipDetails = pckslip
            };
          
        }

        /// <summary>
        /// Method to Generate the Commision for Agent
        /// </summary>
        /// <param name="type"></param>
        public void GenerateCommisionPaymentForAgent(PaymentForOrder type)
        {
            // Method intentionally left empty.
        }

    }
}
