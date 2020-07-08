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
           mock = new Mock<IUnitOfWork>();
           sut = new BusinessRuleEngineService(mock.Object);
         }

        [Fact]
        public void ExecuteAction()
        {
  
            string paymentType = "Book";
            PaymentForOrder foo = (PaymentForOrder)Enum.Parse(typeof(PaymentForOrder), paymentType);
            sut.ExecuteAction(foo);
            mock.Verify(x => x.PackingSlipRepository.GetAllAsync(), Times.Never);
     
        }
    }
}
