using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskC.Dto;
using TaskC.Models;

namespace TaskC.Mapping
{
    public interface IIncidentMapper
    {
        IncidentCreateRequest ToCreateRequest(IncidentForm form);
    }
}
