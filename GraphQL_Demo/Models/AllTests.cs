using System.Collections.Generic;

namespace GraphQL_Demo.Models
{
    public class AllUsers
    {
        public List<UserInfo> Results { get; set; }

        public int Total { get; set; }
    }
}
