using System;
using System.Linq;
using AutoMapper;
using TwitterClone.Application.Common.Mappings;

namespace TwitterClone.Application.Posts.Queries.GetPost
{
    public class PostDto
    {
        public int Id { get; set; }
        public int? AnswerToId { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }
        public UserDto CreatedBy { get; set; }
        public string MediaId { get; set; }
        public bool LikedByMe { get; set; }
        public int Likes { get; set; }
        public bool RePostedByMe { get; set; }
        public int RePosts { get; set; }
        public int Answers { get; set; }

        private class Mapping : Profile
        {
            public Mapping()
            {
                int userId = 0;

                CreateMap<Post, PostDto>()
                    .ForMember(dto => dto.LikedByMe, opt => opt.MapFrom(Post.IsLikedBy(userId)))
                    .ForMember(dto => dto.Likes, opt => opt.MapFrom(p => p.Likes.Count()))
                    .ForMember(dto => dto.RePostedByMe, opt => opt.MapFrom(Post.IsRePostedBy(userId)))
                    .ForMember(dto => dto.RePosts, opt => opt.MapFrom(p => p.RePosts.Count()))
                    .ForMember(dto => dto.Answers, opt => opt.MapFrom(p => p.Answers.Count()));
            }
        }
    }
}