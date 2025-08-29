using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TaskC.Constants;
using TaskC.Dto;
using TaskC.Mapping;
using TaskC.Models;

namespace TaskC.Services
{
    public class IncidentService : IIncidentService
    {
        private readonly IApiClient _api;
        private readonly IIncidentMapper _mapper;
        public IncidentService(IApiClient api, IIncidentMapper mapper)
        { _api = api; _mapper = mapper; }


        public async Task<(bool isSuccess, string message)> CreateAsync(IncidentForm form, CancellationToken ct = default)
        {
            var dto = _mapper.ToCreateRequest(form);
            var response = await _api.PostJsonAsync(Endpoints.CreateIncident, dto, ct);


            if (response.IsSuccessStatusCode)
                return (true, "Incident created successfully.");


            var body = await response.Content.ReadAsStringAsync(ct);
            try
            {
                using var doc = JsonDocument.Parse(body);
                if (doc.RootElement.TryGetProperty("error", out var err))
                    return (false, err.GetString() ?? body);
            }
            catch { }
            return (false, $"Server returned {(int)response.StatusCode} {response.ReasonPhrase}: {body}");
        }
    }
}
