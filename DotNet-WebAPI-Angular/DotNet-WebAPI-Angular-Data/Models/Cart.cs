using System;
using System.Collections.Generic;

namespace DotNet_WebAPI_Angular_Data.Models
{
    public partial class Cart
    {
        public int CartId { get; set; }
        public int? ProductId { get; set; }
        public int? MemberId { get; set; }
        public int? CartStatusId { get; set; }

        public virtual Product Product { get; set; }
    }
}
