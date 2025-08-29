using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskC.Services
{
    public interface IApiClient
    {
        Task<HttpResponseMessage> PostJsonAsync<T>(string relativeUrl, T body, CancellationToken ct = default);
    }
}
