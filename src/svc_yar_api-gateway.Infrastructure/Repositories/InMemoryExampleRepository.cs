using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using svc_yar_api_gateway.Domain.Entities;
using svc_yar_api_gateway.Domain.Ports;

namespace svc_yar_api_gateway.Infrastructure.Repositories
{
    public class InMemoryExampleRepository : IExampleRepository
    {
        private readonly ConcurrentDictionary<Guid, ExampleAggregate> _store = new();

        public Task AddAsync(ExampleAggregate entity, CancellationToken cancellationToken = default)
        {
            _store[entity.Id] = entity;
            return Task.CompletedTask;
        }

        public Task<ExampleAggregate?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            _store.TryGetValue(id, out var entity);
            return Task.FromResult(entity);
        }
    }
}
