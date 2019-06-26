using GraphQL.Types;
using GraphQLDotNetCore.Entities;

namespace GraphQLDotNetCore.GraphQL333
{
    public class AccountEnumType : EnumerationGraphType<TypeOfAccount>
    {
        public AccountEnumType()
        {
            Name = "TypeOfAccount";
            Description = "Enum for account";
        }
    }
}