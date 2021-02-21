using MasterChechBot.Core.Enum;
using MasterChechBot.Core.Services;
using System;
using Xunit;

namespace IntegrationTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var service = new MessageOnKitchen(null);
            var responseEnum = service.CommandForBot("/command");

            Assert.True(responseEnum == ResponseForUser.None);
        }
    }
}
