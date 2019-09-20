using GraphQL.Types;
using GraphQL_Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphQL_Demo.Controllers.GraphQL
{
    public class SingleUserQuery : ObjectGraphType<UserInfo>
    {
        private readonly MyDBContext _context;

        public SingleUserQuery(MyDBContext dbcontext)
        {
            _context = dbcontext;

            UserInfo selectedData = null;
            var data = _context.UserInfo.ToList<UserInfo>();

            Field<SingleUserInfoType>(
              "getById",
              arguments: new QueryArguments(
                new QueryArgument<IdGraphType> { Name = "id", Description = "The ID of the user." }),
              resolve: context =>
              {
                  var id = context.GetArgument<int>("id");
                  selectedData = data.FirstOrDefault(x => x.Id == id);
                  return selectedData;
              });

            Field<SingleUserInfoType>(
             "getByName",
             arguments: new QueryArguments(
               new QueryArgument<StringGraphType> { Name = "name", Description = "The name of the user." }),
             resolve: context =>
             {
                 var name = context.GetArgument<string>("name");
                 selectedData = data.FirstOrDefault(x => x.Name == name);
                 return selectedData;
             });
        }
    }
}
