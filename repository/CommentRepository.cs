using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BanCaCanh.data;
using BanCaCanh.dto.comment;
using BanCaCanh.helper;
using BanCaCanh.Interface;
using BanCaCanh.models;

namespace BanCaCanh.repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly AppDbContext _context;
        public CommentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Comment> CreateAsync(Comment commentModel)
        {
            await _context.Comments.AddAsync(commentModel);
            await _context.SaveChangesAsync();
            return commentModel;
        }

        public Task<List<CommentDto>> GetAllAsync(CommentQueryObject queryObject)
        {
            throw new NotImplementedException();
        }
    }
}