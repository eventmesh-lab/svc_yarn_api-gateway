using System;
using System.Threading;
using System.Threading.Tasks;
using svc_yar_api_gateway.Domain.Entities;

namespace svc_yar_api_gateway.Domain.Ports
{
    public interface IExampleRepository
    {
        Task AddAsync(ExampleAggregate entity, CancellationToken cancellationToken = default);
        Task<ExampleAggregate?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
