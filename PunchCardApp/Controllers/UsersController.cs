using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PunchCardApp.Data;
using PunchCardApp.Models;
using PunchCardApp.Services;
using PunchCardApp.ViewModels;

namespace PunchCardApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IAuthService authService, IMapper mapper)
        {
            _userService = userService;
            _authService = authService;
            _mapper = mapper;
        }

        // GET: api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserViewModel>>> GetUsers()
        {
            return _mapper.Map<List<UserViewModel>>(await _userService.GetUsersAsync());
        }

        // GET: api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserViewModel>> GetUser(int id)
        {
            var user = _mapper.Map<UserViewModel>(await _userService.GetUserAsync(id));

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // POST: api/users/register
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult<User>> Register([FromBody] RegisterViewModel model)
        {
            var user = await _userService.CreateUserAsync(_mapper.Map<User>(model));

            if (user == null) return BadRequest(new { message = "Email address already exists" });

            return CreatedAtAction("GetUser", new { id = user.Id });
        }

        // POST: api/users/login
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginViewModel model)
        {
            var token = await _authService.Authenticate(model.Email, model.Password);

            if (token == null) return BadRequest(new { message = "Email or password is incorrect" });

            return Ok(new { success = true, token = $"bearer {token}" });
        }
    }
}