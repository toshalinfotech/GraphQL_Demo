using GraphQL.Types;
using GraphQL_Demo.Models;

namespace GraphQL_Demo.Controllers.GraphQL
{
    public class SingleUserInfoType : ObjectGraphType<UserInfo>
    {
        public SingleUserInfoType()
        {
            Name = "User";

            Field(x => x.Id, type: typeof(IdGraphType));
            Field(x => x.Name, true);
            Field(x => x.Phone, true);
            Field(x => x.Email, true);
            Field(x => x.EnvironmentName, true);
            Field(x => x.CreatedOn, true);
            Field(x => x.DisplayName, true);
        }
    }

}
