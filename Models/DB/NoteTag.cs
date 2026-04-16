using System.ComponentModel.DataAnnotations.Schema;

namespace SocialAPI.Models;

public class NoteTag
{
    [System.ComponentModel.DataAnnotations.Key]
    public int Id { get; set; }
    
    public required string Name { get; set; }
    public string? Description { get; set; }
    
    public List<Note> TaggedNotes { get; } = [];
}