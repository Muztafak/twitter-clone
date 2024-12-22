using TwitterClone.Application.Common.Mappings;

namespace TwitterClone.Application.Notifications.Queries.GetNotifications
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public string PictureId { get; set; }
        public bool IsCertified { get; set; }

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<User, UserDto>();
            }
        }
    }
}