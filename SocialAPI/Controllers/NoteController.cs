using Microsoft.AspNetCore.Mvc;
using Npgsql;
using SocialAPI.Models;

namespace SocialAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NoteController : ControllerBase
{
    [HttpGet]
    public ActionResult<Note> Get(NoteDbContext dbCtx)
    {
        var count = dbCtx.Notes.Count();
        
        return new Note {Title = $"Title example (total notes: {count})", Content = "This is some content!",  CreatedAt = DateTime.Now, Id = 1, UpdatedAt = DateTime.Now};
    }

    [HttpGet("{id:int}")]
    public ActionResult<Note> GetWithId(int id)
    {
        var note = new Note{Title = "Title example", Content = "This is some content!", CreatedAt = DateTime.Now, Id = 1, UpdatedAt = DateTime.Now};

        return Ok(note);
    }
}