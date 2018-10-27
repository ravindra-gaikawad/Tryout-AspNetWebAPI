using System;
using BooksAPI.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Books.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var controller = new BooksController();

            var result = controller.GetBook(1);
            Assert.IsNotNull(result);
        }
    }
}
