using System;
using GraphQL.DataLoader;
using GraphQL.Types;
using GraphQLDotNetCore.Contracts;
using GraphQLDotNetCore.Entities;

namespace GraphQLDotNetCore.GraphQL333
{
    public class OwnerType : ObjectGraphType<Owner>
    {
        public OwnerType(IAccountRepository accountRepository, IDataLoaderContextAccessor dataLoader)
        {
            Field(x => x.Id, type: typeof(IdGraphType)).Description("Id from owner object");
            Field(x => x.Name).Description("Name from owner obj");
            Field(x => x.Address).Description("Address from o obj");
            Field<ListGraphType<AccountType>>("accounts",
                resolve: x =>
                {
                    var loader = dataLoader.Context
                        .GetOrAddCollectionBatchLoader<Guid, Account>("laluvulu",
                        accountRepository.GetAccountsByOwnerIds);
                    return loader.LoadAsync(x.Source.Id);
                });
        }
    }
}