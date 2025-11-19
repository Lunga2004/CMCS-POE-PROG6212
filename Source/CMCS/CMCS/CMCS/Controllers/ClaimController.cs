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

        // GET: /Claim - View all claims
        public IActionResult Index()
        {
            return View(_claims);
        }

        // GET: /Claim/Submit - Show claim submission form
        public IActionResult Submit()
        {
            return View();
        }

        // POST: /Claim/Submit - Process claim submission
        [HttpPost]
        public IActionResult Submit(Claim claim, List<IFormFile> files)
        {
            if (ModelState.IsValid)
            {
                claim.Id = _nextId++;
                claim.TotalAmount = claim.HoursWorked * claim.HourlyRate;
                claim.Status = "Pending";
                claim.SubmittedDate = DateTime.Now;

                // Handle file uploads
                if (files != null && files.Count > 0)
                {
                    claim.DocumentNames = new List<string>();
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

                            // Store document name
                            claim.DocumentNames.Add(file.FileName);
                        }
                    }
                }

                _claims.Add(claim);
                return RedirectToAction("Index");
            }
            return View(claim);
        }

        // GET: /Claim/Approve/{id} - Approve a claim
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

        // GET: /Claim/Reject/{id} - Reject a claim
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

        // GET: /Claim/Details/{id} - Show claim details
        public IActionResult Details(int id)
        {
            var claim = _claims.Find(c => c.Id == id);
            if (claim == null)
            {
                return NotFound();
            }
            return View(claim);
        }

        // GET: /Claim/GetClaimStatus/{id} - API endpoint for status
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