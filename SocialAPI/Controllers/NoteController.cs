using Microsoft.AspNetCore.Mvc;
using SocialAPI.Models;

namespace SocialAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NoteController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Note>> Get()
    {
        var note = new Note{Title = "Title example", Content = "This is some content!", CreatedAt = DateTime.Now, Id = 1, UpdatedAt = DateTime.Now};

        return Ok(note);
    }
}