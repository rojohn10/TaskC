using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskC.Models;

namespace TaskC.Validation
{
    public class IncidentFormValidator : IFormValidator
    {
        private static readonly string[] AllowedPriorities = new[] { "Low", "Medium", "High" };
        public string? Validate(IncidentForm form)
        {
            if (string.IsNullOrWhiteSpace(form.Title)) return "Title is required.";
            if (string.IsNullOrWhiteSpace(form.Description)) return "Description is required.";
            if (string.IsNullOrWhiteSpace(form.Priority)) return "Priority is required.";


            if (form.Title.Length > 100) return "Title must be 100 characters or less.";
            if (form.Description.Length > 1000) return "Description must be 1000 characters or less.";


            if (!AllowedPriorities.Contains(form.Priority))
                return $"Priority must be one of: {string.Join(", ", AllowedPriorities)}.";


            return null; // valid
        }
    }
}
