using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using SocialAPI.Models;
using SocialAPI.Models.Requests;

namespace SocialAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NoteController : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<Note>> Get(NoteDbContext dbCtx)
    {
        var count = await dbCtx.Notes.CountAsync();
        return new Note {Title = $"Title example (total notes: {count})", Content = "This is some content!",  CreatedAt = DateTime.Now, Id = 1, UpdatedAt = DateTime.Now};
    }
    
    // TODO: Add authentication for get all endpoint
    [HttpGet("all")]
    public async Task<ActionResult<List<Note>>> GetAllNotes(NoteDbContext dbCtx)
    {
        var notes = await dbCtx.Notes.ToListAsync();
        
        return Ok(notes);
    }

    [HttpGet("{id:int}")]
    public ActionResult<Note> GetWithId(int id)
    {
        var note = new Note{Title = "Title example", Content = "This is some content!", CreatedAt = DateTime.Now, Id = 1, UpdatedAt = DateTime.Now};

        return Ok(note);
    }

    [HttpPost]
    public async Task<ActionResult> InsertNote(NoteDbContext dbCtx, [Required][FromBody] NoteInsertRequest requestedNote)
    {
        await dbCtx.Notes.AddAsync(new Note {Title =  requestedNote.Title, Content = requestedNote.Content});
        await dbCtx.SaveChangesAsync();
        return Ok();
    }
}