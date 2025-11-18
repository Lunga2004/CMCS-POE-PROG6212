namespace CMCS.Models
{
    public class Claim
    {
        public int Id { get; set; }
        public string LecturerName { get; set; } = "";
        public string Month { get; set; } = "";
        public decimal HoursWorked { get; set; }
        public decimal HourlyRate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } = "Pending";
        public string Notes { get; set; } = "";
        public DateTime SubmittedDate { get; set; } = DateTime.Now;
        public DateTime? ProcessedDate { get; set; }
        public string ProcessedBy { get; set; } = "";
    }
}