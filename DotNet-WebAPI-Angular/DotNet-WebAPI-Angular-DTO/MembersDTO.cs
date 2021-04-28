using System;
using System.Collections.Generic;
using System.Text;

namespace DotNet_WebAPI_Angular_DTO
{
    public class MembersDTO
    {
        public int MemberId { get; set; }
        public string FristName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

        //public ICollection<ShippingDetails> ShippingDetails { get; set; }
    }
}
