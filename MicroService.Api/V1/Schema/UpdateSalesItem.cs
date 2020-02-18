﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace MicroService.Api.V1.Schema
{
    /// <summary>
    /// To post a sales date throughout the API
    /// </summary>
    [DataContract]
    public class UpdateSalesItem
    {
        /// <summary>
        /// Id of the Sale
        /// </summary>
        [DataMember]
        public string Id { get; set; }

        /// <summary>
        /// Date and Time of the Sale
        /// </summary>
        [DataMember]
        public DateTime DateTime { get; set; }

        /// <summary>
        /// Article Number of the Sale
        /// Alphanumeric up to 32 characters
        /// </summary>
        [DataMember, Required, MaxLength(32)]
        public string ArticleNumber { get; set; }

        /// <summary>
        /// Price of the Sale
        /// </summary>
        [DataMember]
        public decimal SalesPrice { get; set; }
    }
}
