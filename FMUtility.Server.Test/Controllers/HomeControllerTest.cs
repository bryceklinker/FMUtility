using FMUtility.Server.Controllers;
using NUnit.Framework;

namespace FMUtility.Server.Test.Controllers
{
    [TestFixture]
    public class HomeControllerTest
    {
        private HomeController _homeController;

        [SetUp]
        public void Setup()
        {
            _homeController = new HomeController();
        }

        [Test]
        public void IndexShouldGetContentOfOk()
        {
            var content = _homeController.Index();
            Assert.AreEqual("OK", content.Content);
        }
    }
}
