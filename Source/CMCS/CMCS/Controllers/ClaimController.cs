using Microsoft.AspNetCore.Mvc;
using CMCS.Models;
using System.Collections.Generic;

namespace CMCS.Controllers
{
    public class ClaimController : Controller
    {
        private static List<Claim> _claims = new List<Claim>();
        private static int _nextId = 1;

        // View all claims
        public IActionResult Index()
        {
            return View(_claims);
        }

        // Show submit form
        public IActionResult Submit()
        {
            var claim = new Claim();
            return View(claim);
        }

        // Handle form submission
        [HttpPost]
        public IActionResult Submit(string LecturerName, string Month, decimal HoursWorked, decimal HourlyRate, string Notes)
        {
            // Basic validation
            if (string.IsNullOrEmpty(LecturerName) || HoursWorked <= 0 || HourlyRate <= 0)
            {
                ViewBag.Error = "Please fill in all required fields correctly.";
                var claim = new Claim
                {
                    LecturerName = LecturerName,
                    Month = Month,
                    HoursWorked = HoursWorked,
                    HourlyRate = HourlyRate,
                    Notes = Notes
                };
                return View(claim);
            }

            // Create new claim
            var newClaim = new Claim
            {
                Id = _nextId++,
                LecturerName = LecturerName,
                Month = Month,
                HoursWorked = HoursWorked,
                HourlyRate = HourlyRate,
                TotalAmount = HoursWorked * HourlyRate,
                Status = "Pending",
                Notes = Notes ?? "",
                SubmittedDate = DateTime.Now
            };

            _claims.Add(newClaim);
            return RedirectToAction("Index");
        }

        // Approve claim
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

        // Reject claim
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

        // View claim details
        public IActionResult Details(int id)
        {
            var claim = _claims.Find(c => c.Id == id);
            if (claim == null)
            {
                return RedirectToAction("Index");
            }
            return View(claim);
        }
    }
}