using System;
using System.Collections.Generic;

namespace DotNet_WebAPI_Angular_Data.Models
{
    public partial class TblMemberRole
    {
        public int MemberRoleId { get; set; }
        public int? MemberId { get; set; }
        public int? RoleId { get; set; }
    }
}
