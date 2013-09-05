using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PickANick.Core.ViewModels;
using PickANick.Core;

namespace PickANick.Tests
{
    [TestClass]
    public class NickViewModelTests
    {
        private NickViewModel _nickViewModel;

        [TestInitialize]
        public void TestInitialize()
        {
            ServiceContainer.Register<INickServer>(() => new FakeNickServer());

            _nickViewModel = new NickViewModel();
        }

        [TestMethod]
        public void GetNicks()
        {
            var task = _nickViewModel.GetNicks();

            task.Wait();

            Assert.IsNotNull(_nickViewModel.Nicks);
            Assert.AreNotEqual(0, _nickViewModel.Nicks.Length);
        }

        [TestMethod, ExpectedException(typeof(AggregateException))]
        public void GetLocationNoNick()
        {
            _nickViewModel.PickedNick = null;

            var task = _nickViewModel.GetLocation();

            task.Wait();
        }
    }
}
