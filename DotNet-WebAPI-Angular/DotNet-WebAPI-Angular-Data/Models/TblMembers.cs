using System;
using System.Collections.Generic;

namespace DotNet_WebAPI_Angular_Data.Models
{
    public partial class TblMembers
    {
        public TblMembers()
        {
            TblShippingDetails = new HashSet<TblShippingDetails>();
        }

        public int MemberId { get; set; }
        public string FristName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual ICollection<TblShippingDetails> TblShippingDetails { get; set; }
    }
}
