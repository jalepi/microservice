using System.ComponentModel.DataAnnotations;

namespace MicroService.Models
{
    public class TotalRevenuePerSalesItem
    {
        [Required, MaxLength(SalesItem.MaxArticleNumberLength)]
        public string ArticleNumber { get; set; }
        public decimal Value { get; set; }
    }
}
