using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PUBGSharp.Test
{
    [TestClass]
    public class PUBGStatsClientTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PUBGStatsClientConstructor_ShouldRaiseArgumentException_WhenNoKeyProvided()
        {
            //Arrange
            //Act
            var client = new PUBGStatsClient(null);
            //Assert
        }

        [TestMethod]
        public void GetPlayerStatsAsync_ShouldRaiseArgumentException_WhenNoPlayerNameProvided()
        {
            //Arrange
            var client = new PUBGStatsClient("dummy");
            //Act
            try
            {
                StatsResponse responseTask = client.GetPlayerStatsAsync(null).Result;
            }
            catch (Exception e)
            {
                //Assert
                //In case of awaitable tasks, aggregate exception is thrown, which should contain expected ArgumentException.
                Assert.IsInstanceOfType(e.InnerException, typeof(ArgumentException));
            }
        }
    }
}