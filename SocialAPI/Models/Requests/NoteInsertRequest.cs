namespace SocialAPI.Models.Requests;

public class NoteInsertRequest
{
    public required string Title { get; set; }
    
    public string? Content { get; set; }
}