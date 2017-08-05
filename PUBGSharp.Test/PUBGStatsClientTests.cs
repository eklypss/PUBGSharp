using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PUBGSharp.Net.Model;

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
        [ExpectedException(typeof(ArgumentException))]
        public async Task GetPlayerStatsAsync_ShouldRaiseArgumentException_WhenNoPlayerNameProvided()
        {
            //Arrange
            var client = new PUBGStatsClient("dummy");
            //Act
            StatsResponse responseTask = await client.GetPlayerStatsAsync(null).ConfigureAwait(false);
        }
    }
}