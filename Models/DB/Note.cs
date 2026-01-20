using System.ComponentModel.DataAnnotations.Schema;
namespace SocialAPI.Models;

[Table("notes")]
public class Note
{
    
    [System.ComponentModel.DataAnnotations.Key]
    [Column("id")] 
    public int Id { get; set; }
    [Column("title")]
    public required string Title { get; set; }
    [Column("content")]
    public string? Content { get; set; }
    [Column("created_at")]
    
    public List<NoteTag> Tags { get; } = [];
    
    public DateTime CreatedAt { get; set; }
    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }
    
}