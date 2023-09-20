using Smartwyre.DeveloperTest.Infrastructure.Services;
using Smartwyre.DeveloperTest.Models.Requests;
using Xunit;
using Smartwyre.DeveloperTest.Data.Repository;
using Smartwyre.DeveloperTest.Runner.Controller;
using Smartwyre.DeveloperTest.Tests.Settings;


namespace Smartwyre.DeveloperTest.Tests.WithDBContext
{
    public class FixedRateRebateTests
    {
        [Fact]
        public async void Test1() // FixedRateRebate, Rebate && Product != null, same flags
        {

            var request = new CalculateRebateRequest()
            {
                ProductIdentifier = "CAD",
                RebateIdentifier = "CAD",
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
            Assert.Equal(72, rebate.Amount);
        }

        [Fact]
        public async void Test2() // FixedRateRebate, Rebate && Product != null, diff flags
        {

            var request = new CalculateRebateRequest()
            {
                ProductIdentifier = "CAD2",
                RebateIdentifier = "CAD2",
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
            Assert.Equal(12, rebate.Amount);
        }

        [Fact]
        public async void Test3() // FixedRateRebate, Rebate && Product != null, diff flags 0 amount, volume, percentege
        {

            var request = new CalculateRebateRequest()
            {
                ProductIdentifier = "CAD3",
                RebateIdentifier = "CAD3",
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
            Assert.Equal(12, rebate.Amount);
        }


        [Fact]
        public async void Test4() // Rebate && Product = null
        {

            var request = new CalculateRebateRequest()
            {
                ProductIdentifier = "CAD4",
                RebateIdentifier = "CAD4",
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
