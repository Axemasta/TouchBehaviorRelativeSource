namespace TouchBehaviorRelativeBinding.Models;

public class DisplayItem
{
    public int Id { get; set; }
    
    public int? ParentId { get; set; }
    
    public ItemType Type { get; set; }
    
    public required string Title { get; set; }
    
    public DateTime Created { get; set; }
    
    public DateTime? LastModified { get; set; }
    
    public int? FileKilobytes { get; set; }
    
    public required string FileExtension { get; set; }
}

public enum ItemType
{
    File = 0,
    Folder = 1,
}