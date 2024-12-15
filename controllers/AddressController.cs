using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BanCaCanh.dto.order;
using BanCaCanh.extensions;
using BanCaCanh.Interface;
using BanCaCanh.mappers;
using BanCaCanh.models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BanCaCanh.controllers
{
    [Route("api/address")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IAddressRepository _addressRepo;
        public AddressController(UserManager<AppUser> userManager, IAddressRepository addressRepo)
        {
            _userManager = userManager;
            _addressRepo = addressRepo;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateUserAddress([FromBody] CreateAddressDto createAddressDto)
        {
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);
            if (appUser == null)
            {
                return BadRequest(new { message = "Người dùng không tồn tại" });
            }
            var addressModel = createAddressDto.ToCreateAddressDto(appUser.Id);
            await _addressRepo.CreateUserAddress(addressModel);
            return Ok(addressModel.ToAddressDto());
        }
    }
}