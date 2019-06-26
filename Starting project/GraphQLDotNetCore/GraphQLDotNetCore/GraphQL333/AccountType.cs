using GraphQL.Types;
using GraphQLDotNetCore.Entities;

namespace GraphQLDotNetCore.GraphQL333
{
    public class AccountType : ObjectGraphType<Account>
    {
        public AccountType()
        {
            Field(x => x.Id, type:typeof(IdGraphType)).Description("Id from account");

            //Field(x => x.Type, type:typeof(EnumerationGraphType));

            Field(x => x.Description);

            Field(x => x.Owner, type:typeof(OwnerType));

            Field(x => x.OwnerId, type:typeof(IdGraphType));

            // this is valid too
            //Field(x => x.Type, type: typeof(AccountEnumType));

            // from example
            Field<AccountEnumType>("Type", "enum for acc");
        }
    }
}