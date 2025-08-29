using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskC.Models;

namespace TaskC.Validation
{
    public interface IFormValidator
    {
        /// Returns null if valid; otherwise an error message to show the user.
        string? Validate(IncidentForm form);
    }
}
