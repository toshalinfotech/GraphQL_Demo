using GraphQL.Types;
using GraphQL_Demo.Models;

namespace GraphQL_Demo.Controllers.GraphQL
{
    public class AllUsersType : ObjectGraphType<AllUsers>
    {
        public AllUsersType()
        {
            Field(x => x.Total);
            Field<ListGraphType<SingleUserInfoType>>("Results").DefaultValue = new ListGraphType<SingleUserInfoType>();
        }
    }
}
