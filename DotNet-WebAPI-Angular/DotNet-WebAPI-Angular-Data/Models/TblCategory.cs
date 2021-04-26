using System;
using System.Collections.Generic;

namespace DotNet_WebAPI_Angular_Data.Models
{
    public partial class TblCategory
    {
        public TblCategory()
        {
            TblProduct = new HashSet<TblProduct>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }

        public virtual ICollection<TblProduct> TblProduct { get; set; }
    }
}
