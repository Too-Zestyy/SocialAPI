using System.ComponentModel.DataAnnotations.Schema;

namespace SocialAPI.Models;

[Table("note_tags")]
public class NoteTag
{
    [System.ComponentModel.DataAnnotations.Key]
    [Column("id")] 
    public int Id { get; set; }
    [Column("name")]
    public required string Name { get; set; }
    [Column("description")]
    public string? Description { get; set; }
    public List<Note> TaggedNotes { get; } = [];
}