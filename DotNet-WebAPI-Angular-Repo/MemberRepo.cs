using DotNet_WebAPI_Angular_Data.Models;
using DotNet_WebAPI_Angular_InterfaceContracts.Generic;
using DotNet_WebAPI_Angular_InterfaceContracts.Repo;
using DotNet_WebAPI_Angular_Repo.Generic;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DotNet_WebAPI_Angular_Repo
{
    public class MemberRepo : GenericRepo<Members>, IMemberRepo
    {
        private readonly IUnitOfWork _unitOfWork;

        public MemberRepo(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Members>> GetActiveMembers()
        {
            return await _unitOfWork.Context.Members.Where(x => x.IsActive == true).ToListAsync();
        }
    }
}
