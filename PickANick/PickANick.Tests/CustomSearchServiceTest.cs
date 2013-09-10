using Microsoft.VisualStudio.TestTools.UnitTesting;
using PickANick.Core.Google;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickANick.Tests
{
    [TestClass]
    public class CustomSearchServiceTest
    {
        private CustomSearchService _service;

        [TestInitialize]
        public void TestInitialize()
        {
            _service = new CustomSearchService
            {
                Key = "AIzaSyDLsMKnW4JfyHB_y5loy-NTiTi-sCLEQkc",
                CX = "002750746776631512750:q6vczylwrbi"
            };
        }

        [TestMethod]
        public void Search()
        {
            var task = _service.Search("chuck norris");

            task.Wait();

            Assert.IsNotNull(task.Result);
        }

        [TestMethod]
        public void GetLocation()
        {
            var task = _service.GetLocation("mexico");

            task.Wait();

            var location = task.Result;
            Assert.IsTrue(location.Name.Contains("Mexico"));
        }
    }
}
