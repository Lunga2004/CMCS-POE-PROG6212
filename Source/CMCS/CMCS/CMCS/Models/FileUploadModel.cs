namespace CMCS.Models
{
    public class FileUploadModel
    {
        public IFormFile File { get; set; }
        public int ClaimId { get; set; }
    }
}