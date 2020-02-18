using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace MicroService.Api.V1.Schema
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
        [DataMember, Required, MaxLength(32)]
        public string ArticleNumber { get; set; }

        /// <summary>
        /// Total Revenue of the sales item
        /// </summary>
        [DataMember]
        public decimal Value { get; set; }
    }
}
