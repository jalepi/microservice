﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace MicroService.Models
{
    /// <summary>
    /// To post a sales date throughout the API
    /// </summary>
    [DataContract]
    public class SalesItem
    {
        /// <summary>
        /// Date and Time of the Sale
        /// </summary>
        [DataMember]
        public DateTime DateTime { get; set; }

        /// <summary>
        /// Article Number of the Sale
        /// Alphanumeric up to 32 characters
        /// </summary>
        [DataMember, MaxLength(32)]
        public string ArticleNumber { get; set; }

        /// <summary>
        /// Price of the Sale
        /// </summary>
        [DataMember]
        public decimal SalesPrice { get; set; }
    }
}
