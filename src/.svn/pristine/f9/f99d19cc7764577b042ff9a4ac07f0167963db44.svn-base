using EntityFramework.BulkInsertTests.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.BulkInsertTests
{
    public class BookContext : DbContext
    {
        public BookContext() : base("Default")
        {

        }

        public DbSet<Author> Author { get; set; }
        public DbSet<Book> Book { get; set; }

    }
}
