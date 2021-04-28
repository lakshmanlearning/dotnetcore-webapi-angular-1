using DotNet_WebAPI_Angular_DTO;
using DotNet_WebAPI_Angular_InterfaceContracts.Repo;
using DotNet_WebAPI_Angular_InterfaceContracts.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using DotNet_WebAPI_Angular_Data.Models;
using DotNet_WebAPI_Angular_InterfaceContracts.Generic;

namespace DotNet_WebAPI_Angular_APIServices
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepo _memberRepo;
        public MemberService(IMemberRepo memberRepo)
        {
            _memberRepo = memberRepo;
        }

        public async Task<IEnumerable<MembersDTO>> GetAllMembers()
        {
            var members = await _memberRepo.GetAll();
            return members.ToList().Select(x => new MembersDTO()
            {
                MemberId = x.MemberId,
                FristName = x.FristName,
                LastName = x.LastName,
                EmailId = x.EmailId,
                Password = x.Password,
                IsActive = x.IsActive,
                IsDelete = x.IsDelete,
                CreatedOn = x.CreatedOn,
                ModifiedOn = x.ModifiedOn
            }).ToList();
        }

        public async Task<IEnumerable<MembersDTO>> GetActiveMembers()
        {
            var members = await _memberRepo.GetActiveMembers();
            return members.ToList().Select(x => new MembersDTO()
            {
                MemberId = x.MemberId,
                FristName = x.FristName,
                LastName = x.LastName,
                EmailId = x.EmailId,
                Password = x.Password,
                IsActive = x.IsActive,
                IsDelete = x.IsDelete,
                CreatedOn = x.CreatedOn,
                ModifiedOn = x.ModifiedOn
            }).ToList();
        }
    }
}
