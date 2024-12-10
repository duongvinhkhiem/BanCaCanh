using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BanCaCanh.dto.comment;
using BanCaCanh.helper;
using BanCaCanh.models;

namespace BanCaCanh.Interface
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetAllAsync(CommentQueryObject queryObject);
        Task<Comment> CreateAsync(Comment commentModel);
    }
}