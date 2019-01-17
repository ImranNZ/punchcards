using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
    public class PunchCardController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IPunchCardService _punchCardService;

        public PunchCardController(IMapper mapper, IPunchCardService punchCardService)
        {
            _mapper = mapper;
            _punchCardService = punchCardService;
        }

        // GET: api/punchcard
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PunchCardViewModel>>> GetPunchCards()
        {
            return _mapper.Map<List<PunchCardViewModel>>(await _punchCardService.GetPunchCardsAsync(Convert.ToInt32(User.Identity.Name)));
        }

        // GET: api/punchcard/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PunchCardViewModel>> GetPunchCard(int id)
        {
            var punchCard = _mapper.Map<PunchCardViewModel>(await _punchCardService.GetPunchCardAsync(id, Convert.ToInt32(User.Identity.Name)));

            if (punchCard == null)
            {
                return NotFound();
            }

            return punchCard;
        }

        // POST: api/punchcard
        [HttpPost]
        public async Task<ActionResult> PostPunchCard([FromBody] PunchCardViewModel model)
        {
            var punchCard = _mapper.Map<PunchCard>(model);

            punchCard.UserId = Convert.ToInt32(User.Identity.Name);

            await _punchCardService.CreatePunchCardAsync(punchCard);

            // Actually we want to return the token
            return CreatedAtAction("GetPunchCard", new { id = punchCard.Id }, model);
        }
    }
}