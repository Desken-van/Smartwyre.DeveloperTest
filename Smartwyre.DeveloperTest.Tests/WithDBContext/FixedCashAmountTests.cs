using Smartwyre.DeveloperTest.Data.Repository;
using Smartwyre.DeveloperTest.Infrastructure.Services;
using Smartwyre.DeveloperTest.Models.Requests;
using Smartwyre.DeveloperTest.Runner.Controller;
using Smartwyre.DeveloperTest.Tests.Settings;
using Xunit;

namespace Smartwyre.DeveloperTest.Tests.WithDBContext
{
    public class FixedCashAmountTests
    {
        [Fact]
        public async void Test1() // FixedCashAmount, Rebate && Product != null, same flags
        {

            var request = new CalculateRebateRequest()
            {
                ProductIdentifier = "USD",
                RebateIdentifier = "USD",
                Volume = 2
            };

            var dbContext = await DBStore.GetDatabaseContext();
            var mapper = MapperConfig.InitializeAutomapper();

            var rebateRepo = new RebateRepository(dbContext, mapper);
            var productRepo = new ProductRepository(dbContext, mapper);

            var rebateService = new RebateService(rebateRepo, productRepo);

            var _rebateController = new RebateController(rebateService);

            // Act
            var result = _rebateController.CalculateRebate(request).Result;

            var rebate = await rebateRepo.GetRebateByIdentifierAsync(request.RebateIdentifier);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.Equal(23, rebate.Amount);
        }

        [Fact]
        public async void Test2() // FixedCashAmount, Rebate && Product != null, diff flags
        {

            var request = new CalculateRebateRequest()
            {
                ProductIdentifier = "USD2",
                RebateIdentifier = "USD2",
                Volume = 2
            };

            var dbContext = await DBStore.GetDatabaseContext();
            var mapper = MapperConfig.InitializeAutomapper();

            var rebateRepo = new RebateRepository(dbContext, mapper);
            var productRepo = new ProductRepository(dbContext, mapper);

            var rebateService = new RebateService(rebateRepo, productRepo);

            var _rebateController = new RebateController(rebateService);

            // Act
            var result = _rebateController.CalculateRebate(request).Result;

            var rebate = await rebateRepo.GetRebateByIdentifierAsync(request.RebateIdentifier);

            // Assert
            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.Equal(54, rebate.Amount);
        }

        [Fact]
        public async void Test3() // FixedCashAmount, Rebate && Product != null, diff flags 0 amount, volume, percentege
        {

            var request = new CalculateRebateRequest()
            {
                ProductIdentifier = "USD3",
                RebateIdentifier = "USD3",
                Volume = 0
            };

            var dbContext = await DBStore.GetDatabaseContext();
            var mapper = MapperConfig.InitializeAutomapper();

            var rebateRepo = new RebateRepository(dbContext, mapper);
            var productRepo = new ProductRepository(dbContext, mapper);

            var rebateService = new RebateService(rebateRepo, productRepo);

            var _rebateController = new RebateController(rebateService);

            // Act
            var result = _rebateController.CalculateRebate(request).Result;

            var rebate = await rebateRepo.GetRebateByIdentifierAsync(request.RebateIdentifier);

            // Assert
            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.Equal(0, rebate.Amount);
        }


        [Fact]
        public async void Test4() // Rebate && Product = null
        {

            var request = new CalculateRebateRequest()
            {
                ProductIdentifier = "USD4",
                RebateIdentifier = "USD4",
                Volume = 0
            };

            var dbContext = await DBStore.GetDatabaseContext();
            var mapper = MapperConfig.InitializeAutomapper();

            var rebateRepo = new RebateRepository(dbContext, mapper);
            var productRepo = new ProductRepository(dbContext, mapper);

            var rebateService = new RebateService(rebateRepo, productRepo);

            var _rebateController = new RebateController(rebateService);

            // Act
            var result = _rebateController.CalculateRebate(request).Result;

            var rebate = await rebateRepo.GetRebateByIdentifierAsync(request.RebateIdentifier);

            // Assert
            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.Null(rebate);
        }
    }
}
