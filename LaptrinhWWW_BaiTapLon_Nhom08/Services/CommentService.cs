using EntityFrameworks.Model;
using Repository;
using Service.Interfaces;
using System;
using System.Collections.Generic;

namespace Services
{
    public class CommentService : ICommentService
    {
        private NewsRepository<Comment> repository;
        public CommentService()
        {
            repository = new NewsRepository<Comment>();
        }
        public Comment AddComment(Comment comment)
        {
            return repository.Add(comment);
        }

        public bool DeleteComment(object id)
        {
            repository.Delete(id);
            return true;
        }

        public IEnumerable<Comment> GetAll()
        {
            return repository.GetByWhere(x => true);
        }

        public Comment GetById(object id)
        {
            return repository.GetById(id);
        }

        public Comment UpdateComment(Comment comment)
        {
            var exits = repository.GetByCondition(x => x.CommentId.Equals(comment.CommentId));
            if (exits != null)
            {
                exits.Time = comment.Time;
                exits.Role = comment.Role;
                exits.NewsId = comment.NewsId;
                exits.Image = comment.Image;
                exits.Description = comment.Description;
                exits.AccountName = comment.AccountName;
                exits.Active = comment.Active;
                repository.Update(exits);
            }
            return null;
        }
    }
    }
