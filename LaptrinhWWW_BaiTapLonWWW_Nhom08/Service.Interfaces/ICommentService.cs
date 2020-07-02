using EntityFrameworks.Model;

namespace Service.Interfaces
{
    public interface ICommentService : IBaseService<Comment>
    {
        Comment AddComment(Comment comment);
        Comment UpdateComment(Comment comment);
        bool DeleteComment(object id);
    }
}
