using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TwitterClone.Application.Common.Interfaces;
using TwitterClone.Domain.Events;

namespace TwitterClone.Application.Posts.Commands.CreatePost
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, int>
    {
        private readonly IApplicationDbContext _context;
        
        public CreatePostCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var post = new Post { Content = request.Content, MediaId = request.MediaId, AnswerToId = request.AnswerToId };
            
            post.DomainEvents.Add(new PostCreatedEvent(post));

            _context.Posts.Add(post);
            await _context.SaveChangesAsync(cancellationToken);

            return post.Id;
        }
    }
}