using GraphQL.Types;
using GraphQL_Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphQL_Demo.Controllers.GraphQL
{
    public class AllUsersQuery : ObjectGraphType<AllUsers>
    {
        private readonly MyDBContext _context;

        public AllUsersQuery(MyDBContext dbcontext)
        {
            _context = dbcontext;

            AllUsers allRecords = new AllUsers();
            var data = _context.UserInfo.ToList<UserInfo>();

            this.Field<AllUsersType>(
             "getAll",
             arguments: new QueryArguments(
                 new QueryArgument<IdGraphType> { Name = "id", Description = "The ID of the user." },
               new QueryArgument<StringGraphType> { Name = "name", Description = "The name of the user." },
               new QueryArgument<BooleanGraphType> { Name = "and", Description = "and condition" }),
             resolve: context =>
             {
                 var id = context.GetArgument<int>("id");
                 var name = context.GetArgument<string>("name");
                 var and = context.GetArgument<bool>("and");
                 if (and)
                 {
                     allRecords.Results = data.Where(x => x.Name == name && x.Id == id).ToList();
                 }
                 else
                 {
                     allRecords.Results = data.Where(x => x.Name == name || x.Id == id).ToList();
                 }
                 allRecords.Total = allRecords.Results.Count;
                 return allRecords;
             });
        }
    }
}
