using Microsoft.AspNetCore.Mvc;
using CMCS.Models;
using System.Collections.Generic;

namespace CMCS.Controllers
{
    public class ClaimController : Controller
    {
        private static List<Claim> _claims = new List<Claim>();
        private static int _nextId = 1;

        public IActionResult Index()
        {
            return View(_claims);
        }

        public IActionResult Submit()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Submit(Claim claim)
        {
            claim.Id = _nextId++;
            claim.TotalAmount = claim.HoursWorked * claim.HourlyRate;
            claim.Status = "Pending";

            _claims.Add(claim);
            return RedirectToAction("Index");
        }

        public IActionResult Approve(int id)
        {
            var claim = _claims.Find(c => c.Id == id);
            if (claim != null)
            {
                claim.Status = "Approved";
            }
            return RedirectToAction("Index");
        }

        public IActionResult Reject(int id)
        {
            var claim = _claims.Find(c => c.Id == id);
            if (claim != null)
            {
                claim.Status = "Rejected";
            }
            return RedirectToAction("Index");
        }
    }
}