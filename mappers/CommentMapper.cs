using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BanCaCanh.dto.comment;
using BanCaCanh.models;

namespace BanCaCanh.mappers
{
    public static class CommentMapper
    {
        public static CommentDto ToCommentDto(this Comment commentModel, string username)
        {
            return new CommentDto
            {
                Id = commentModel.Id,
                Content = commentModel.Content,
                ProductId = commentModel.ProductId,
                CreateAt = commentModel.CreateAt,
                Username = username
            };
        }
    }
}