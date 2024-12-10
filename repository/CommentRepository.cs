using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BanCaCanh.data;
using BanCaCanh.dto.comment;
using BanCaCanh.helper;
using BanCaCanh.Interface;
using BanCaCanh.models;
using Microsoft.EntityFrameworkCore;

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

        public async Task<List<Comment>> GetAllAsync(CommentQueryObject queryObject)
        {
            if (queryObject.ProductId == null)
            {
                return null;
            }
            var skip = (queryObject.Page - 1) * queryObject.PageSize;
            var comments = await _context.Comments
            .Where(s => s.ProductId == queryObject.ProductId)
            .OrderByDescending(p => p.CreateAt)
            .Skip(skip).Take(queryObject.PageSize)
            .ToListAsync();

            return comments;
        }
    }
}