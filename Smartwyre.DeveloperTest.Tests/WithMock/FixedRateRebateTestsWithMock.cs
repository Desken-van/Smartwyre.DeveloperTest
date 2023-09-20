using System.Collections.Generic;
using System.Linq;
using Moq;
using Smartwyre.DeveloperTest.Core.Entities;
using Smartwyre.DeveloperTest.Core.Enums;
using Smartwyre.DeveloperTest.Data;
using Smartwyre.DeveloperTest.Infrastructure.Services;
using Smartwyre.DeveloperTest.Models.Requests;
using Xunit;

namespace Smartwyre.DeveloperTest.Tests.WithMock
{
    public class FixedRateRebateTestsWithMock
    {
        [Fact]
        public async void Test1() // FixedRateRebate, Rebate && Product != null, same flags
        {

            var rebateRepo = new Mock<IRebateRepository>();
            var productRepo = new Mock<IProductRepository>();

            var request = new CalculateRebateRequest()
            {
                ProductIdentifier = "CAD",
                RebateIdentifier = "CAD",
                Volume = 2
            };
            var resultList = new List<RebateEntity>();

            var newRebate = new RebateEntity() { Identifier = "CAD", Amount = 72, Percentage = 3, Incentive = IncentiveType.FixedRateRebate };

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
            Assert.Equal(72, rebate.Amount);
        }

        [Fact]
        public async void Test2() // FixedRateRebate, Rebate && Product != null, diff flags
        {

            var rebateRepo = new Mock<IRebateRepository>();
            var productRepo = new Mock<IProductRepository>();

            var request = new CalculateRebateRequest()
            {
                ProductIdentifier = "CAD2",
                RebateIdentifier = "CAD2",
                Volume = 2
            };
            var resultList = new List<RebateEntity>();

            var newRebate = new RebateEntity() { Identifier = "CAD2", Amount = 12, Percentage = 3, Incentive = IncentiveType.FixedRateRebate };

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
            Assert.Equal(12, rebate.Amount);
        }

        [Fact]
        public async void Test3() // FixedRateRebate, Rebate && Product != null, diff flags 0 amount, volume, percentege
        {


            var rebateRepo = new Mock<IRebateRepository>();
            var productRepo = new Mock<IProductRepository>();

            var request = new CalculateRebateRequest()
            {
                ProductIdentifier = "CAD3",
                RebateIdentifier = "CAD3",
                Volume = 2
            };
            var resultList = new List<RebateEntity>();

            var newRebate = new RebateEntity() { Identifier = "CAD3", Amount = 12, Percentage = 3, Incentive = IncentiveType.FixedRateRebate };

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
            Assert.Equal(12, rebate.Amount);
        }


        [Fact]
        public async void Test4() // Rebate && Product = null
        {


            var rebateRepo = new Mock<IRebateRepository>();
            var productRepo = new Mock<IProductRepository>();

            var request = new CalculateRebateRequest()
            {
                ProductIdentifier = "CAD4",
                RebateIdentifier = "CAD4",
                Volume = 2
            };
            var resultList = new List<RebateEntity>();

            var newRebate = new RebateEntity() { Identifier = "CAD4", Amount = 12, Percentage = 3, Incentive = IncentiveType.FixedRateRebate };

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
