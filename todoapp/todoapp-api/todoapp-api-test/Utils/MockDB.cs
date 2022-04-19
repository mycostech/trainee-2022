using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using todoapp_api.Data;

namespace todoapp_api_test.Utils
{
    public static class MockDB
    {
        public static todoapp_apiContext CreateDatabase(string name)
        {
            var options = new DbContextOptionsBuilder<todoapp_apiContext>().UseInMemoryDatabase(databaseName: name).Options;
            var db = new todoapp_apiContext(options);
            return db;
        }
    }
}
