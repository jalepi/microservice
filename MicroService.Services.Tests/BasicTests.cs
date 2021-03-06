using MicroService.Services.Tests.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;

namespace MicroService.Services.Tests
{
    [TestClass]
    public class BasicTests
    {
        [TestMethod]
        public async Task ConsolidatedInMemory_can_call_get_methods_without_exceptions()
        {
            await Implementations_can_call_get_methods_without_exceptions(new ConsolidatedInMemorySalesService());
        }

        [TestMethod]
        public async Task OnTheFlyInMemory_can_call_get_methods_without_exceptions()
        {
            await Implementations_can_call_get_methods_without_exceptions(new OnTheFlyInMemorySalesService());
        }

        static private async Task Implementations_can_call_get_methods_without_exceptions(ISalesService service)
        {
            await service.CanCallAllGetMethodsWithoutExceptionsAsync(default);

            await service.ApplySomeFixturesAsync(
                itemsPerDay: 100,
                daysCount: 1,
                articleNumbersCount: 25,
                salesPricesCount: 10,
                cancellationToken: default);

            await service.CanCallAllGetMethodsWithoutExceptionsAsync(default);
        }

        [TestMethod]
        public async Task ConsolidatedInMemory_fixtures_should_consolidate_correctly()
        {
            await Implementations_fixtures_should_consolidate_correctly(new ConsolidatedInMemorySalesService());
        }

        [TestMethod]
        public async Task OnTheFlyInMemory_fixtures_should_consolidate_correctly()
        {
            await Implementations_fixtures_should_consolidate_correctly(new OnTheFlyInMemorySalesService());
        }

        static private async Task Implementations_fixtures_should_consolidate_correctly(ISalesService service)
        {
            await service.CanCallAllGetMethodsWithoutExceptionsAsync(default);

            var itemsPerDay = 100;
            var daysCount = 5;
            var articleNumbersCount = 25;
            var salesPricesCount = 10;

            await service.ApplySomeFixturesAsync(
                itemsPerDay: itemsPerDay,
                daysCount: daysCount,
                articleNumbersCount: articleNumbersCount,
                salesPricesCount: salesPricesCount,
                cancellationToken: default);

            var t1 = await service.GetTotalRevenuesPerDayAsync(default);

            Assert.AreEqual(
                expected: daysCount,
                actual: t1.LongCount());

            var t2 = await service.GetTotalRevenuesPerSalesItemAsync(default);

            Assert.AreEqual(
                expected: articleNumbersCount,
                actual: t2.Count());

            var t3 = await service.GetTotalSalesItemsPerDayAsync(default);
            Assert.AreEqual(
                expected: daysCount,
                actual: t3.LongCount());
        }
    }
}
