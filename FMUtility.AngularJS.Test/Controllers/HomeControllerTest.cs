using System.Web.Mvc;
using FMUtility.AngularJS.Controllers;
using NUnit.Framework;

namespace FMUtility.AngularJS.Test.Controllers
{
    [TestFixture]
    public class HomeControllerTest
    {
        [Test]
        public void IndexShouldGetViewResult()
        {
            var controller = new HomeController();
            var result = controller.Index();
            Assert.IsInstanceOf<ViewResult>(result);
        }
    }
}