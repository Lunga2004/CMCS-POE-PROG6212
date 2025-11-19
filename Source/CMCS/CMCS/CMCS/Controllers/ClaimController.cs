using Microsoft.AspNetCore.Mvc;
using CMCS.Models;
using System.Collections.Generic;

namespace CMCS.Controllers
{
    public class ClaimController : Controller
    {
        private static List<Claim> _claims = new List<Claim>();
        private static int _nextId = 1;
        private readonly IWebHostEnvironment _environment;

        public ClaimController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public IActionResult Index()
        {
            return View(_claims);
        }

        public IActionResult Submit()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Submit(Claim claim, List<IFormFile> files)
        {
            claim.Id = _nextId++;
            claim.TotalAmount = claim.HoursWorked * claim.HourlyRate;
            claim.Status = "Pending";
            claim.SubmittedDate = DateTime.Now;

            // Handle file uploads
            if (files != null && files.Count > 0)
            {
                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        // Validate file type
                        var allowedExtensions = new[] { ".pdf", ".docx", ".xlsx" };
                        var fileExtension = Path.GetExtension(file.FileName).ToLower();

                        if (!allowedExtensions.Contains(fileExtension))
                        {
                            ModelState.AddModelError("", "Only PDF, DOCX, and XLSX files are allowed.");
                            return View(claim);
                        }

                        // Validate file size (5MB limit)
                        if (file.Length > 5 * 1024 * 1024)
                        {
                            ModelState.AddModelError("", "File size cannot exceed 5MB.");
                            return View(claim);
                        }

                        // Create uploads directory if it doesn't exist
                        var uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads");
                        if (!Directory.Exists(uploadsFolder))
                        {
                            Directory.CreateDirectory(uploadsFolder);
                        }

                        // Generate unique filename
                        var uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                        var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                        // Save file
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            file.CopyTo(fileStream);
                        }

                        // Store document name
                        claim.DocumentNames.Add(file.FileName);
                    }
                }
            }

            _claims.Add(claim);
            return RedirectToAction("Index");
        }

        public IActionResult Approve(int id)
        {
            var claim = _claims.Find(c => c.Id == id);
            if (claim != null)
            {
                claim.Status = "Approved";
                claim.ProcessedDate = DateTime.Now;
                claim.ProcessedBy = "Coordinator";
            }
            return RedirectToAction("Index");
        }

        public IActionResult Reject(int id)
        {
            var claim = _claims.Find(c => c.Id == id);
            if (claim != null)
            {
                claim.Status = "Rejected";
                claim.ProcessedDate = DateTime.Now;
                claim.ProcessedBy = "Coordinator";
            }
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var claim = _claims.Find(c => c.Id == id);
            if (claim == null)
            {
                return NotFound();
            }
            return View(claim);
        }

        public IActionResult GetClaimStatus(int id)
        {
            var claim = _claims.Find(c => c.Id == id);
            if (claim == null)
            {
                return Json(new { status = "Not Found" });
            }

            return Json(new
            {
                status = claim.Status,
                submittedDate = claim.SubmittedDate.ToString("MMM dd, yyyy HH:mm"),
                processedDate = claim.ProcessedDate?.ToString("MMM dd, yyyy HH:mm") ?? "Not processed",
                processedBy = claim.ProcessedBy ?? "Not processed"
            });
        }
    }
}