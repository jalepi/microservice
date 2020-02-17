using MicroService.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MicroService.Services
{
    public class ConsolidatedInMemorySalesService : ISalesService
    {
        readonly private ConcurrentDictionary<string, SalesItem> _salesItems;
        readonly private ConcurrentDictionary<DateTime, decimal> _totalRevenuePerDay;
        readonly private ConcurrentDictionary<string, decimal> _totalRevenuePerSalesItem;
        readonly private ConcurrentDictionary<DateTime, long> _totalSalesItemPerDay;

        public ConsolidatedInMemorySalesService()
        {
            _salesItems = new ConcurrentDictionary<string, SalesItem>();
            _totalRevenuePerDay = new ConcurrentDictionary<DateTime, decimal>();
            _totalRevenuePerSalesItem = new ConcurrentDictionary<string, decimal>();
            _totalSalesItemPerDay = new ConcurrentDictionary<DateTime, long>();
        }

        public async Task<string> AddSalesItemAsync(SalesItem salesItem, CancellationToken cancellationToken)
        {
            await Task.Yield();

            var id = $"{Guid.NewGuid()}";
            var date = salesItem.DateTime.Date;
            var price = salesItem.SalesPrice;

            _salesItems.TryAdd(id, salesItem);
            _totalRevenuePerDay.AddOrUpdate(date, price, (k, v) => v + price);
            _totalRevenuePerSalesItem.AddOrUpdate(salesItem.ArticleNumber, price, (k, v) => v + price);
            _totalSalesItemPerDay.AddOrUpdate(date, 1L, (k, v) => v + 1L);

            return id;
        }

        public async Task<IEnumerable<TotalRevenuePerDay>> GetTotalRevenuesPerDayAsync(CancellationToken cancellationToken)
        {
            await Task.Yield();

            var query = from kvp in _totalRevenuePerDay
                        select new TotalRevenuePerDay
                        {
                            Date = kvp.Key,
                            Value = kvp.Value,
                        };

            return query;
        }

        public async Task<IEnumerable<TotalRevenuePerSalesItem>> GetTotalRevenuesPerSalesItemAsync(CancellationToken cancellationToken)
        {
            await Task.Yield();

            var query = from kvp in _totalRevenuePerSalesItem
                        select new TotalRevenuePerSalesItem
                        {
                            ArticleNumber = kvp.Key,
                            Value = kvp.Value,
                        };

            return query;
        }

        public async Task<IEnumerable<TotalSalesItemPerDay>> GetTotalSalesItemsPerDayAsync(CancellationToken cancellationToken)
        {
            await Task.Yield();

            var query = from kvp in _totalSalesItemPerDay
                        select new TotalSalesItemPerDay
                        {
                            Date = kvp.Key,
                            Count = kvp.Value,
                        };

            return query;
        }
    }
}
