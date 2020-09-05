using System;
using System.Linq;
using Core.Context;
using Core.Messages;
using Core.Repositories;
using Xunit;

namespace UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var message = new MessageOnShipBusiness(new UnitOfWork(new Context("")));

            var primeiro = message.ResponsePhrases.FirstOrDefault();

            Assert.True(primeiro != null);
        }
    }
}
