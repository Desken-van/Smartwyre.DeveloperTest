using System;
using Smartwyre.DeveloperTest.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Smartwyre.DeveloperTest.Core.Entities;
using Smartwyre.DeveloperTest.Tests.Settings;

namespace Smartwyre.DeveloperTest.Tests
{
    public static class DataOperator
    {
        public static async Task<Rebate> GetRebate(string identifier)
        {
            var list = DBStore.GetRebateEntityList();

            var entity = list.FirstOrDefault(x => x.Identifier == identifier);

            if (entity != null)
            {
                var result = new Rebate()
                {
                    Identifier = entity.Identifier,
                    Incentive = entity.Incentive,
                    Amount = entity.Amount,
                    Percentage = entity.Percentage,
                };

                return result;
            }

            return null;
        }

        public static async Task StoreCalculationUpdate(string identifier, RebateEntity newRebate, List<RebateEntity> result)
        {
            var list = DBStore.GetRebateEntityList();

            var rebate = await GetRebate(identifier);

            var index = list.FindIndex(
                delegate (RebateEntity rebate)
                {
                    return rebate.Identifier.Equals(rebate.Identifier, StringComparison.Ordinal);
                });

            list[index] = newRebate;

            result = list;
        }

        public static void StoreCalculationUpdate(string identifier, RebateEntity newRebate, ref List<RebateEntity> result)
        {
            var list = DBStore.GetRebateEntityList();

            var rebate = GetRebate(identifier);

            var index = list.FindIndex(
                delegate (RebateEntity rebate)
                {
                    return rebate.Identifier.Equals(rebate.Identifier, StringComparison.Ordinal);
                });

            list[index] = newRebate;

            result = list;
        }

        public static Product GetProduct(string identifier)
        {
            var list = DBStore.GetProductEntityList();

            var entity = list.FirstOrDefault(x => x.Identifier == identifier);

            if (entity != null)
            {
                var result = new Product()
                {
                    SupportedIncentives = entity.SupportedIncentives,
                    Id = entity.Id,
                    Identifier = entity.Identifier,
                    Uom = entity.Uom,
                    Price = entity.Price
                };

                return result;
            }

            return null;
        }
    }
}
