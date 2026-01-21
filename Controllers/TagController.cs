using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialAPI.Models;
using SocialAPI.Models.Requests;

namespace SocialAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TagController : ControllerBase
{
    [HttpGet("all")]
    public async Task<ActionResult<List<NoteTag>>> GetAllNotes(NoteDbContext dbCtx)
    {
        var note_tags = await dbCtx.NoteTags.ToListAsync();
        
        return Ok(note_tags);
    }
}