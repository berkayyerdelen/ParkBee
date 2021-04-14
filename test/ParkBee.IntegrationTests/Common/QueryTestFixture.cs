using Microsoft.Extensions.Options;
using ParkBee.Infrastructure;
using ParkBee.Infrastructure.Repositories.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ParkBee.IntegrationTests.Common
{
    public class QueryTestFixture : IDisposable
    {
        public ApplicationContext Context { get; private set; }
        public QueryTestFixture()
        {
            Context = ApplicationContextFactory.Create();
        }
        public void Dispose()
        {
           ApplicationContextFactory.Destroy(Context);
        }
    }
    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture>{ }
}
