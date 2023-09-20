using Moq;
using Smartwyre.DeveloperTest.Core.Entities;
using Smartwyre.DeveloperTest.Core.Enums;
using Smartwyre.DeveloperTest.Data;
using Smartwyre.DeveloperTest.Infrastructure.Services;
using Smartwyre.DeveloperTest.Models.Requests;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Smartwyre.DeveloperTest.Tests.WithMock
{

    public class AmountPerUomTestsWithMock
    {
        [Fact]
        public async void Test1() // AmountPerUom, Rebate && Product != null, same flags
        {

            var rebateRepo = new Mock<IRebateRepository>();
            var productRepo = new Mock<IProductRepository>();

            var request = new CalculateRebateRequest()
            {
                ProductIdentifier = "JPY",
                RebateIdentifier = "JPY",
                Volume = 2
            };
            var resultList = new List<RebateEntity>();

            var newRebate = new RebateEntity() { Identifier = "JPY", Amount = 46, Percentage = 3, Incentive = IncentiveType.AmountPerUom };

            rebateRepo.Setup(repo => repo.GetRebateByIdentifierAsync(request.RebateIdentifier).Result).Returns(DataOperator.GetRebate(request.RebateIdentifier).Result);
            rebateRepo.Setup(repo => repo.StoreCalculationResultAsync(DataOperator.GetRebate(request.RebateIdentifier).Result)).Returns(DataOperator.StoreCalculationUpdate(request.RebateIdentifier, newRebate, resultList));

            productRepo.Setup(repo => repo.GetProductByIdentifierAsync(request.ProductIdentifier).Result).Returns(DataOperator.GetProduct(request.ProductIdentifier));

            var rebateService = new RebateService(rebateRepo.Object, productRepo.Object);

            // Act
            var result = rebateService.CalculateAsync(request).Result;

            DataOperator.StoreCalculationUpdate(request.RebateIdentifier, newRebate, ref resultList);

            var rebate = resultList.FirstOrDefault(x => x.Identifier == request.RebateIdentifier);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.Equal(46, rebate.Amount);
        }

        [Fact]
        public async void Test2() // AmountPerUom, Rebate && Product != null, diff flags
        {

            var rebateRepo = new Mock<IRebateRepository>();
            var productRepo = new Mock<IProductRepository>();

            var request = new CalculateRebateRequest()
            {
                ProductIdentifier = "JPY2",
                RebateIdentifier = "JPY2",
                Volume = 2
            };
            var resultList = new List<RebateEntity>();

            var newRebate = new RebateEntity() { Identifier = "JPY2", Amount = 54, Percentage = 3, Incentive = IncentiveType.AmountPerUom };

            rebateRepo.Setup(repo => repo.GetRebateByIdentifierAsync(request.RebateIdentifier).Result).Returns(DataOperator.GetRebate(request.RebateIdentifier).Result);
            rebateRepo.Setup(repo => repo.StoreCalculationResultAsync(DataOperator.GetRebate(request.RebateIdentifier).Result)).Returns(DataOperator.StoreCalculationUpdate(request.RebateIdentifier, newRebate, resultList));

            productRepo.Setup(repo => repo.GetProductByIdentifierAsync(request.ProductIdentifier).Result).Returns(DataOperator.GetProduct(request.ProductIdentifier));

            var rebateService = new RebateService(rebateRepo.Object, productRepo.Object);

            // Act
            var result = rebateService.CalculateAsync(request).Result;

            DataOperator.StoreCalculationUpdate(request.RebateIdentifier, newRebate, ref resultList);

            var rebate = resultList.FirstOrDefault(x => x.Identifier == request.RebateIdentifier);

            // Assert
            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.Equal(54, rebate.Amount);
        }

        [Fact]
        public async void Test3() // AmountPerUom, Rebate && Product != null, diff flags 0 amount, volume, percentege
        {


            var rebateRepo = new Mock<IRebateRepository>();
            var productRepo = new Mock<IProductRepository>();

            var request = new CalculateRebateRequest()
            {
                ProductIdentifier = "JPY3",
                RebateIdentifier = "JPY3",
                Volume = 2
            };
            var resultList = new List<RebateEntity>();

            var newRebate = new RebateEntity() { Identifier = "JPY3", Amount = 0, Percentage = 3, Incentive = IncentiveType.AmountPerUom };

            rebateRepo.Setup(repo => repo.GetRebateByIdentifierAsync(request.RebateIdentifier).Result).Returns(DataOperator.GetRebate(request.RebateIdentifier).Result);
            rebateRepo.Setup(repo => repo.StoreCalculationResultAsync(DataOperator.GetRebate(request.RebateIdentifier).Result)).Returns(DataOperator.StoreCalculationUpdate(request.RebateIdentifier, newRebate, resultList));

            productRepo.Setup(repo => repo.GetProductByIdentifierAsync(request.ProductIdentifier).Result).Returns(DataOperator.GetProduct(request.ProductIdentifier));

            var rebateService = new RebateService(rebateRepo.Object, productRepo.Object);

            // Act
            var result = rebateService.CalculateAsync(request).Result;

            DataOperator.StoreCalculationUpdate(request.RebateIdentifier, newRebate, ref resultList);

            var rebate = resultList.FirstOrDefault(x => x.Identifier == request.RebateIdentifier);

            // Assert
            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.Equal(0, rebate.Amount);
        }


        [Fact]
        public async void Test4() // Rebate && Product = null
        {


            var rebateRepo = new Mock<IRebateRepository>();
            var productRepo = new Mock<IProductRepository>();

            var request = new CalculateRebateRequest()
            {
                ProductIdentifier = "JPY4",
                RebateIdentifier = "JPY4",
                Volume = 2
            };
            var resultList = new List<RebateEntity>();

            var newRebate = new RebateEntity() { Identifier = "JPY4", Amount = 12, Percentage = 3, Incentive = IncentiveType.AmountPerUom };

            rebateRepo.Setup(repo => repo.GetRebateByIdentifierAsync(request.RebateIdentifier).Result).Returns(DataOperator.GetRebate(request.RebateIdentifier).Result);
            rebateRepo.Setup(repo => repo.StoreCalculationResultAsync(DataOperator.GetRebate(request.RebateIdentifier).Result)).Returns(DataOperator.StoreCalculationUpdate(request.RebateIdentifier, newRebate, resultList));

            productRepo.Setup(repo => repo.GetProductByIdentifierAsync(request.ProductIdentifier).Result).Returns(DataOperator.GetProduct(request.ProductIdentifier));

            var rebateService = new RebateService(rebateRepo.Object, productRepo.Object);

            // Act
            var result = rebateService.CalculateAsync(request).Result;

            var rebate = resultList.FirstOrDefault(x => x.Identifier == request.RebateIdentifier);

            // Assert
            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.Null(rebate);
        }

    }
}
