using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskC.Models;

namespace TaskC.Services
{
    public interface IIncidentService
    {
        Task<(bool isSuccess, string message)> CreateAsync(IncidentForm form, CancellationToken ct = default);
    }
}
