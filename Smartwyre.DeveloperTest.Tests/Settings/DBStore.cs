using Microsoft.EntityFrameworkCore;
using Smartwyre.DeveloperTest.Core.Entities;
using Smartwyre.DeveloperTest.Core.Enums;
using Smartwyre.DeveloperTest.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Smartwyre.DeveloperTest.Tests.Settings
{
    public static class DBStore
    {
        public static async Task<SWContext> GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<SWContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var databaseContext = new SWContext(options);
            databaseContext.Database.EnsureCreated();

            var productList = GetProductEntityList();

            foreach (var product in productList)
            {
                databaseContext.Products.Add(product);
            }

            var rebateList = GetRebateEntityList();

            foreach (var rebate in rebateList)
            {
                databaseContext.Rebates.Add(rebate);
            }

            await databaseContext.SaveChangesAsync();

            return databaseContext;
        }

        public static List<RebateEntity> GetRebateEntityList()
        {
            var result = new List<RebateEntity>
            {
                new RebateEntity { Identifier="CAD", Amount = 12, Percentage = 3, Incentive = IncentiveType.FixedRateRebate},
                new RebateEntity { Identifier="CAD2", Amount = 12, Percentage = 3, Incentive = IncentiveType.FixedRateRebate},
                new RebateEntity { Identifier="CAD3", Amount = 12, Percentage = 0, Incentive = IncentiveType.FixedRateRebate},
                new RebateEntity { Identifier="JPY", Amount = 23, Percentage = 2, Incentive = IncentiveType.AmountPerUom},
                new RebateEntity { Identifier="JPY2", Amount = 54, Percentage = 3, Incentive = IncentiveType.AmountPerUom},
                new RebateEntity { Identifier="JPY3", Amount = 0, Percentage = 0, Incentive = IncentiveType.AmountPerUom},
                new RebateEntity { Identifier="USD", Amount = 23, Percentage = 2, Incentive = IncentiveType.FixedCashAmount},
                new RebateEntity { Identifier="USD2", Amount = 54, Percentage = 3, Incentive = IncentiveType.FixedCashAmount},
                new RebateEntity { Identifier="USD3", Amount = 0, Percentage = 0, Incentive = IncentiveType.FixedCashAmount}
            };

            return result;
        }

        public static List<ProductEntity> GetProductEntityList()
        {
            var result = new List<ProductEntity>
            {
                new ProductEntity { Id=1, Identifier="CAD", Price = 12, Uom = "Points", SupportedIncentives = SupportedIncentiveType.FixedRateRebate},
                new ProductEntity { Id=2, Identifier="CAD2", Price = 12, Uom = "Points", SupportedIncentives = SupportedIncentiveType.AmountPerUom},
                new ProductEntity { Id=3, Identifier="CAD3", Price = 0, Uom = "Points", SupportedIncentives = SupportedIncentiveType.FixedRateRebate},
                new ProductEntity { Id=4, Identifier="JPY", Price = 12, Uom = "Points", SupportedIncentives = SupportedIncentiveType.AmountPerUom},
                new ProductEntity { Id=5, Identifier="JPY2", Price = 12, Uom = "Points", SupportedIncentives = SupportedIncentiveType.FixedCashAmount},
                new ProductEntity { Id=6, Identifier="JPY3", Price = 0, Uom = "Points", SupportedIncentives = SupportedIncentiveType.AmountPerUom},
                new ProductEntity { Id=7, Identifier="USD", Price = 12, Uom = "Points", SupportedIncentives = SupportedIncentiveType.FixedCashAmount},
                new ProductEntity { Id=8, Identifier="USD2", Price = 12, Uom = "Points", SupportedIncentives = SupportedIncentiveType.FixedRateRebate},
                new ProductEntity { Id=9, Identifier="USD3", Price = 0, Uom = "Points", SupportedIncentives = SupportedIncentiveType.FixedCashAmount}
            };

            return result;
        }
    }
}
