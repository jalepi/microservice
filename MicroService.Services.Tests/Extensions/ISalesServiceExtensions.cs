using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MicroService.Services.Tests.Extensions
{
    static public class ISalesServiceExtensions
    {
        static public async Task CanCallAllGetMethodsWithoutExceptionsAsync(this ISalesService service, CancellationToken cancellationToken)
        {
            var result = new
            {
                TotalRevenuesPerDay = (await service.GetTotalRevenuesPerDayAsync(cancellationToken)).ToArray(),
                TotalRevenuesPerSalesItem = (await service.GetTotalRevenuesPerSalesItemAsync(cancellationToken)).ToArray(),
                TotalSalesItemsPerDay = (await service.GetTotalSalesItemsPerDayAsync(cancellationToken)).ToArray(),
            };
        }

        static public async Task ApplySomeFixturesAsync(this ISalesService service, int itemsPerDay, int daysCount, int articleNumbersCount, int salesPricesCount, CancellationToken cancellationToken = default)
        {
            var random = new Random();

            var dateTimes = (
                from item in Enumerable.Range(0, itemsPerDay)
                from day in Enumerable.Range(0, daysCount)
                select new DateTime(2000, 1, 1).AddDays(day).AddMinutes(random.Next(0, 23 * 60)));

            var articleNumbers = (
                from index in Enumerable.Range(0, articleNumbersCount)
                select $"{Guid.NewGuid()}");

            var salePrices = (
                from index in Enumerable.Range(0, salesPricesCount)
                select 1000.0m * (decimal)random.NextDouble());

            var items = (
                from articleNumber in articleNumbers
                from dateTime in dateTimes
                from salePrice in salePrices
                select new Models.SalesItem
                {
                    ArticleNumber = articleNumber,
                    DateTime = dateTime,
                    SalesPrice = salePrice,
                }).OrderBy(item => item.SalesPrice).ThenBy(item => item.ArticleNumber).ThenBy(item => item.DateTime);

            var tasks = (
                from item in items
                select service.AddSalesItemAsync(item, cancellationToken));

            await Task.WhenAll(tasks);
        }
    }
}
