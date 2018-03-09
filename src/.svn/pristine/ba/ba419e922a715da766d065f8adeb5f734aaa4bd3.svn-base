using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntityFramework.BulkInsert.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using EntityFramework.BulkInsertTests.Domain;
using System.Linq.Expressions;
using System.Diagnostics;

namespace EntityFramework.BulkInsertTests
{
    [TestClass()]
    public class BulkInsertExtensionTests
    {
        [TestMethod()]
        public void BulkInsertTest()
        {
            Author author = new Author()
            {
                Name = "aaaaa_"+ DateTime.Now
            };


           
            using( var ctx = new BookContext())
            {
                ctx.Author.Add(author);
                ctx.SaveChanges();

                int count = 10;
                IEnumerable<Book> books = CreateBooks(count, author);

                var sw = new Stopwatch();
                sw.Start();

                ctx.BulkInsert(books);
                ctx.SaveChanges();

                Console.WriteLine("Bulk insert with {0} items elapsed: {1}ms", count, TimeSpan.FromTicks(sw.ElapsedTicks).TotalMilliseconds);


            }
        }

        [TestMethod()]
        public void BulkInsertNullTest()
        {          

            using (var ctx = new BookContext())
            {
                int count = 2;
                IEnumerable<Book> books = CreateBooks(count, null);

                ctx.BulkInsert(books);
                ctx.SaveChanges();            }
        }

        private IEnumerable<Book> CreateBooks(int count, Author author)
        {

            for (int i = 0; i < count; ++i)
            {
                yield return new Book
                {
                    Author = author,
                    Title = i + "fn",
                    Price =  i,
                };
            }
        }

        [TestMethod()]
        public void ExpressionTest()
        {
            var baseType = typeof(object);
            var x = Expression.Parameter(baseType, "x");
            var expression = Expression.Lambda<Func<object, object>>(Expression.Convert(Expression.Constant("1"), typeof(object)), x);
            var f = expression.Compile();

            var result = f("2");
            var result2 = f(null);

            Console.WriteLine("result =" + result);
            Console.WriteLine("result2 =" + result2);
        }

        [TestMethod()]
        public void ExpressionTest2()
        {
            var baseType = typeof(Author);
            var x = Expression.Parameter(baseType, "x");

            var propNames = "Name";
            Expression propertyExpression = Expression.PropertyOrField(x, propNames);
            Expression convertExpression = Expression.Convert(propertyExpression, typeof(object));

            var expression = Expression.Lambda<Func<Author, object>>(convertExpression, x);
            var selector = expression.Compile();

            var f1 = Expression.Lambda<Func<Author, object>>(propertyExpression, x).Compile();

            Author author = new Author()
            {
                Name = "hello"
            };

            Author author2 = new Author()
            {
                Name = "hello2"
            };

            var result = selector(author);
            var result2 = selector(author2);

            Console.WriteLine("result =" + result);
            Console.WriteLine("result2 =" + result2);

            Console.WriteLine("result3 =" + f1(author2));

        }
    }



   

}