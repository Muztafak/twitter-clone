using System;
using MediatR;

namespace TwitterClone.Application.Medias.Queries.GetMedia
{
    public class GetMediaQuery : IRequest<Media>
    {
        public Guid Id { get; set; }
    }
}