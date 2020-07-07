using Moq;
using SCM.BusinessRuleEngine.Web.Controllers;
using SCM.BusinessRuleEngine.Web.DataAccess;
using SCM.BusinessRuleEngine.Web.Models.Enums;
using SCM.BusinessRuleEngine.Web.Service;
using SCM.BusinessRuleEngine.Web.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SCM.BusinessRuleEngine.Test
{
    public class BusinessRuleServiceTests
    {
      
        private Mock<IUnitOfWork> mock;
        private BusinessRuleEngineService sut;


        public BusinessRuleServiceTests()
        {
           // mock = new Mock<IBusinessRuleEngineService>();
            mock = new Mock<IUnitOfWork>();
            sut = new BusinessRuleEngineService(mock.Object);
            //mock1 = new Mock<BusinessRuleEngineService>();

        }

        [Fact]
        public void ExecuteAction()
        {
            // Mock<FraudValidator> mockfraud = new Mock<FraudValidator>();
            //mockfraud.Setup(x => x.isFraudValidator(It.IsAny<CreditCardApplication>())).Returns(true);
            // Mock<IFrequentFlyerValidator> mock = new Mock<IFrequentFlyerValidator>();
            // var sut = new CreditCardApplicationEvaluator(mock.Object, mockfraud.Object);

            string paymentType = "Book";
            PaymentForOrder foo = (PaymentForOrder)Enum.Parse(typeof(PaymentForOrder), paymentType);
            sut.ExecuteAction(foo);
            mock.Verify(x => x.PackingSlipRepository.GetAllAsync(), Times.Never);
            //void decision = mock1.ExecuteAction(foo);
            //Assert.Equal(CreditCardApplicationDecision.AutoAccepted, decision);

        }
    }
}
