using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.BulkInsertTests.Domain
{
    public class Book: EnityBase
    {
        public Author Author { get; set; }

        public string Title { get; set; }
        public double? Price { get; set; }
    }
}
