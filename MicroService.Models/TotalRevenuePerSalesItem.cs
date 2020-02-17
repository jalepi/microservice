using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace MicroService.Models
{
    /// <summary>
    /// Total Revenue of a sales item
    /// </summary>
    [DataContract]
    public class TotalRevenuePerSalesItem
    {
        /// <summary>
        /// Article number of the sales item
        /// </summary>
        [DataMember]
        public string ArticleNumber { get; set; }

        /// <summary>
        /// Total Revenue of the sales item
        /// </summary>
        [DataMember]
        public decimal Value { get; set; }
    }
}
