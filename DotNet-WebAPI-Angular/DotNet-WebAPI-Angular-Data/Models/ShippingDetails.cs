using System;
using System.Collections.Generic;

namespace DotNet_WebAPI_Angular_Data.Models
{
    public partial class ShippingDetails
    {
        public int ShippingDetailId { get; set; }
        public int? MemberId { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public int? OrderId { get; set; }
        public decimal? AmountPaid { get; set; }
        public string PaymentType { get; set; }

        public virtual Members Member { get; set; }
    }
}
