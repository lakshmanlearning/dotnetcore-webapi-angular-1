using DotNet_WebAPI_Angular_DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotNet_WebAPI_Angular_InterfaceContracts.Service
{
    public interface IMemberService
    {
        Task<IEnumerable<MembersDTO>> GetAllMembers();

        Task<IEnumerable<MembersDTO>> GetActiveMembers();
    }
}
