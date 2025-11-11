using System;
using System.Threading.Tasks;
using Xunit;
using svc_yar_api_gateway.Infrastructure.Repositories;
using svc_yar_api_gateway.Domain.Entities;

namespace svc_yar_api_gateway.Infrastructure.IntegrationTests
{
    public class InMemoryRepoTests
    {
        [Fact]
        public async Task AddAndGet_ReturnsEntity()
        {
            var repo = new InMemoryExampleRepository();
            var agg = new ExampleAggregate("name");

            await repo.AddAsync(agg);
            var fetched = await repo.GetByIdAsync(agg.Id);

            Assert.NotNull(fetched);
            Assert.Equal(agg.Id, fetched!.Id);
        }
    }
}
