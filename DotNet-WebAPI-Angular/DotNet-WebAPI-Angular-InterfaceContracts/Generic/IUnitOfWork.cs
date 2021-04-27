using DotNet_WebAPI_Angular_Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotNet_WebAPI_Angular_InterfaceContracts.Generic
{
    public interface IUnitOfWork //: IDisposable
    {
        MyOnlineShoppingContext Context { get; }

        void Commit();

        Task CommitAsync();
    }
}
