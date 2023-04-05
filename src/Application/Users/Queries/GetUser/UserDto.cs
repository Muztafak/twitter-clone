using TwitterClone.Application.Common.Mappings;

namespace TwitterClone.Application.Users.Queries.GetUser
{
    public class UserDto : IMapFrom<User>
    { 
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Username { get; set; }
    }
}