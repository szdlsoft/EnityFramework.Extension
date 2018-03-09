using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;

#if NET45
#if EF6
using System.Data.Entity.Spatial;
#endif
#if EF5
using System.Data.Spatial;
#endif
#endif

using System.Diagnostics;
using EntityFramework.BulkInsert.Extensions;
using EntityFramework.BulkInsert.Helpers;
using EntityFramework.BulkInsert.Providers;
using EntityFramework.BulkInsert.Test.CodeFirst;
using EntityFramework.BulkInsert.Test.Domain;
using EntityFramework.BulkInsert.Test.Domain.ComplexTypes;
using EntityFramework.MappingAPI;
using EntityFramework.MappingAPI.Extensions;
using NUnit.Framework;
using System.Threading.Tasks;
using System.Linq;

namespace EntityFramework.BulkInsert.Test
{
    [TestFixture]
    public class BulkInsertTest : TestBase<TestBaseContext>
    {
        protected static IEnumerable<Page> CreatePage(int count)
        {
            for (int i = 0; i < count; ++i)
            {
                yield return new Page { Title = "title" + i, Content = "content" + i, CreatedAt = DateTime.Now };
            }
        }
        protected override TestBaseContext GetContext()
        {
            return new SqlContext();
        }

        [Test]
        public void BulkInsertTestSimple()
        {
            var Pages = CreatePage(2);

            int itemsCount = Pages.Count();
            var sw = new Stopwatch();
            using( var ctx = new SqlContext())
            {
                sw.Start();
                ctx.BulkInsert(Pages);
                sw.Stop();
            }
            Console.WriteLine("Bulk insert with {0} items elapsed: {1}ms", itemsCount, TimeSpan.FromTicks(sw.ElapsedTicks).TotalMilliseconds);

        }
    }
}