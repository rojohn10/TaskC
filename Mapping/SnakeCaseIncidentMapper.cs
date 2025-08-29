using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskC.Dto;
using TaskC.Models;

namespace TaskC.Mapping
{
    public class SnakeCaseIncidentMapper : IIncidentMapper
    {
        public IncidentCreateRequest ToCreateRequest(IncidentForm form) => new()
        {
            IncidentTitle = form.Title?.Trim() ?? string.Empty,
            IncidentDescription = form.Description?.Trim() ?? string.Empty,
            IncidentPriority = form.Priority?.Trim() ?? string.Empty
        };
    }
}
