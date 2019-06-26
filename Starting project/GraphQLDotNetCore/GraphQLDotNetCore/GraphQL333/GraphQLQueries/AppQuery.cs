using System;
using GraphQL.Types;
using GraphQLDotNetCore.Contracts;
using GraphQLDotNetCore.Entities;

namespace GraphQLDotNetCore.GraphQL333.GraphQLQueries
{
    public class AppQuery : ObjectGraphType
    {
        public AppQuery(IOwnerRepository ownerRepository, IAccountRepository accountRepository)
        {
            Field<ListGraphType<OwnerType>>("owners",
                resolve: context => ownerRepository.GetAll());

            Field<OwnerType>("owner",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> {Name = "ownerId"}),
                resolve: context =>
                {
                    var id = context.GetArgument<Guid>("ownerId");
                    return ownerRepository.GetById(id);
                });

            Field<ListGraphType<AccountType>>("accounts",
                resolve: x => accountRepository.GetAll());
        }
    }
}