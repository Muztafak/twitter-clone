using AutoMapper;
using TwitterClone.Application.Common.Mappings;

namespace TwitterClone.Application.Notifications.Queries.GetNotifications
{
    public class NotificationDto
    {
        public int Id { get; set; }
        public bool Read { get; set; }
        public int PostId { get; set; }
        public string PostContent { get; set; }
        public UserDto CreatedBy { get; set; }
        public NotificationType Type { get; set; }

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<Notification, NotificationDto>()
                    .ForMember(dto => dto.PostContent, opt => opt.MapFrom(n => n.Post.Content));
            }
        }
    }
}