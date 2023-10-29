namespace DAL.DTO;

public class HATEOASWrapper<T>
{
    public T Model { get; set; }

    public Dictionary<string, HATEOASLink> Links { get; set; }
}

public class HATEOASLink
{
    public string Link { get; set; }
}