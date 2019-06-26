using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLDotNetCore.Contracts;
using GraphQLDotNetCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraphQLDotNetCore.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationContext _context;

        public AccountRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<Account> GetAll()
        {
            return _context.Accounts.ToList();
        }

        public IEnumerable<Account> GetAccountsByOwner(Guid ownerId)
        {
            return _context.Accounts.Where(x => x.OwnerId == ownerId).ToList();
        }

        public async Task<ILookup<Guid, Account>> GetAccountsByOwnerIds(IEnumerable<Guid> ownerIds)
        {
            var accounts = await _context.Accounts.Where(x => ownerIds.Contains(x.OwnerId)).ToListAsync();

            return accounts.ToLookup(x => x.OwnerId);
        }
    }
}
