using GraphQL;
using GraphQL.Types;
using GraphQLDotNetCore.GraphQL333.GraphQLQueries;

namespace GraphQLDotNetCore.GraphQL333.GraphQLSchema
{
    public class AppSchema : Schema
    {
        public AppSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<AppQuery>();
        }
    }
}