using System;

namespace GraphQL_Demo.Models
{
    public class UserInfo
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string DisplayName { get; set; }

        public Types Type { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public DateTime CreatedOn { get; set; }

        public string EnvironmentName { get; set; }

    }

    public enum Types
    {
        EndUser = 1,
        Admin = 2
    }
}
