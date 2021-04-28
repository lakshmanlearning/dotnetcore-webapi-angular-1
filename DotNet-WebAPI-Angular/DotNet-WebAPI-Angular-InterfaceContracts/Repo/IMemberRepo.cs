using DotNet_WebAPI_Angular_Data.Models;
using DotNet_WebAPI_Angular_InterfaceContracts.Generic;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotNet_WebAPI_Angular_InterfaceContracts.Repo
{
    public interface IMemberRepo : IGenericRepo<Members>
    {
        Task<IEnumerable<Members>> GetActiveMembers();
    }
}
