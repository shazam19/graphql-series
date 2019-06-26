using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLDotNetCore.Entities;

namespace GraphQLDotNetCore.Contracts
{
    public interface IAccountRepository
    {
        IEnumerable<Account> GetAll();

        IEnumerable<Account> GetAccountsByOwner(Guid ownerId);

        Task<ILookup<Guid, Account>> GetAccountsByOwnerIds(IEnumerable<Guid> ownerIds);
    }
}
