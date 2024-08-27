﻿using EShopper.IdentityServer.Dtos;
using EShopper.IdentityServer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EShopper.IdentityServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public RegistersController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(RegisterDto registerDto)
        {
            var user = new ApplicationUser  //manuel mapleme
            {
                Name = registerDto.Name,
                Surname = registerDto.Surname,
                UserName = registerDto.UserName,
                Email = registerDto.Email

            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if(result.Succeeded)
            {
                return Ok("Kullanıcı Başarıyla Oluşturuldu");
            }
            return BadRequest(result.Errors);
        }

    }
}
