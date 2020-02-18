using System;
using System.ComponentModel.DataAnnotations;

namespace MicroService.Models
{
    public class SalesItem
    {
        public const int MaxArticleNumberLength = 32;

        public DateTime DateTime { get; set; }

        [Required, MaxLength(MaxArticleNumberLength)]
        public string ArticleNumber { get; set; }

        public decimal SalesPrice { get; set; }
    }
}
