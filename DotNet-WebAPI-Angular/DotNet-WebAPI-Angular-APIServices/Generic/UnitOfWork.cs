using DotNet_WebAPI_Angular_Data.Models;
using DotNet_WebAPI_Angular_InterfaceContracts.Generic;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotNet_WebAPI_Angular_APIServices.Generic
{
    public class UnitOfWork : IUnitOfWork
    {
        public MyOnlineShoppingContext Context { get; }

        public UnitOfWork(MyOnlineShoppingContext context)
        {
            Context = context;
        }

        public void Commit()
        {
            Context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await Context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
