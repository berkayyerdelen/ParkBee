using ParkBee.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkBee.IntegrationTests.Common
{
    public class CommandTestBase:IDisposable
    {
        protected readonly ApplicationContext _context;
        public CommandTestBase()
        {
            _context = ApplicationContextFactory.Create();

        }

        public void Dispose()
        {
            ApplicationContextFactory.Destroy(_context);
        }
    }
}
