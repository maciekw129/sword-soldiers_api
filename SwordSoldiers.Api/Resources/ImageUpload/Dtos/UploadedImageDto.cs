namespace SwordSoldiers.Api.Resources.ImageUpload;

public class UploadedImageDto
{
    public string FileName { get; set; }
    public string Extension { get; set; }
    public string Url { get; set; }
    public int Size { get; set; }
}