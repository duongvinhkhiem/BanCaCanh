using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BanCaCanh.data;
using BanCaCanh.dto.comment;
using BanCaCanh.extensions;
using BanCaCanh.models;
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
        private readonly AppDbContext _context;
        public CommentController(UserManager<AppUser> userManager, AppDbContext context)
        {
            _usermanager = userManager;
            _context = context;
        }
        [HttpPost("{productId}")]
        [Authorize]
        public async Task<IActionResult> CreateComment([FromRoute] int productId, [FromBody] CreateCommentDto commentDto)
        {
            var username = User.GetUsername();
            var appUser = await _usermanager.FindByNameAsync(username);
            var commentModel = new Comment
            {
                AppUserId = appUser.Id,
                ProductId = productId,
                Content = commentDto.Content
            };
            var comment = await _context.Comments.AddAsync(commentModel);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}