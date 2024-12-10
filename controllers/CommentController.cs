using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BanCaCanh.data;
using BanCaCanh.dto.comment;
using BanCaCanh.extensions;
using BanCaCanh.helper;
using BanCaCanh.Interface;
using BanCaCanh.mappers;
using BanCaCanh.models;
using BanCaCanh.repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BanCaCanh.controllers
{
    [Route("api/comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly UserManager<AppUser> _usermanager;
        private readonly ICommentRepository _commentRepo;
        private readonly IProductRepository _productRepo;
        public CommentController(UserManager<AppUser> userManager, ICommentRepository commentRepo, IProductRepository productRepo)
        {
            _usermanager = userManager;
            _commentRepo = commentRepo;
            _productRepo = productRepo;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllComment([FromQuery] CommentQueryObject queryObject)
        {
            var comments = await _commentRepo.GetAllAsync(queryObject);
            var commentsDto = new List<CommentDto>();
            foreach (var item in comments)
            {
                var appUser = await _usermanager.FindByIdAsync(item.AppUserId);
                var dto = item.ToCommentDto(appUser.UserName);
                commentsDto.Add(dto);
            }

            return Ok(commentsDto);
        }

        [HttpPost("{productId}")]
        [Authorize]
        public async Task<IActionResult> CreateComment([FromRoute] int productId, [FromBody] CreateCommentDto commentDto)
        {
            var username = User.GetUsername();
            var appUser = await _usermanager.FindByNameAsync(username);
            var product = await _productRepo.GetByIdAsync(productId);
            if (product == null) return NotFound(new { message = "Sản phẩm không tồn tại" });
            var commentModel = new Comment
            {
                AppUserId = appUser.Id,
                ProductId = productId,
                Content = commentDto.Content
            };
            var comment = await _commentRepo.CreateAsync(commentModel);
            return Ok(comment.ToCommentDto(username));
        }
    }
}