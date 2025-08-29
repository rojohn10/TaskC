using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TaskC.Dto
{
    public class IncidentCreateRequest
    {
        [JsonPropertyName("incident_title")]
        public string IncidentTitle { get; set; } = string.Empty;


        [JsonPropertyName("incident_description")]
        public string IncidentDescription { get; set; } = string.Empty;


        [JsonPropertyName("incident_priority")]
        public string IncidentPriority { get; set; } = string.Empty;
    }
}
