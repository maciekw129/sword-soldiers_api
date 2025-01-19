namespace SwordSoldiers.Api.Resources.ImageUpload;

public class ImgBbResponseDto
{
    public Data Data { get; set; } 
    public bool Success { get; set; } 
    public int Status { get; set; }
}

public class Data
{
    public string Id { get; set; } 
    public string Title { get; set; } 
    public string UrlViewer { get; set; } 
    public string Url { get; set; } 
    public string DisplayUrl { get; set; } 
    public int Width { get; set; } 
    public int Height { get; set; } 
    public int Size { get; set; } 
    public long Time { get; set; } 
    public int Expiration { get; set; } 
    public Image Image { get; set; } 
    public Thumb Thumb { get; set; } 
    public Medium Medium { get; set; } 
    public string DeleteUrl { get; set; }
}

public class Image
{
    public string Filename { get; set; } 
    public string Name { get; set; } 
    public string Mime { get; set; } 
    public string Extension { get; set; } 
    public string Url { get; set; }
}

public class Thumb
{
    public string Filename { get; set; } 
    public string Name { get; set; } 
    public string Mime { get; set; } 
    public string Extension { get; set; } 
    public string Url { get; set; }
}

public class Medium
{
    public string Filename { get; set; } 
    public string Name { get; set; } 
    public string Mime { get; set; } 
    public string Extension { get; set; } 
    public string Url { get; set; }
}