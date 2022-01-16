namespace Domain;
public class AppUserActivity
{
    public string AppUSerId { get; set; }
    public AppUser AppUser { get; set; }
    public Guid ActiviyId { get; set; }
    public Activity Activity { get; set; }
    public bool IsHost { get; set; }
}