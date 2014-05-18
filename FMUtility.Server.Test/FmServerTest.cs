using System.Net;
using System.Web.Http;
using FMUtility.Server.Configuration;
using Moq;
using NUnit.Framework;

namespace FMUtility.Server.Test
{
    [TestFixture]
    public class FmServerTest
    {
        private FmServer _fmServer;
        private Mock<IConfiguration> _configurationMock;
        private string _baseUrl;

        [SetUp]
        public void Setup()
        {
            _baseUrl = "http://localhost:9000/";
            _configurationMock = new Mock<IConfiguration>();
            _configurationMock.Setup(s => s.GetSetting("FmServer")).Returns(_baseUrl);

            _fmServer = new FmServer(_configurationMock.Object);
        }

        [Test]
        public void NameShouldBeFmServer()
        {
            Assert.AreEqual("Football Manager Server", _fmServer.Name);
        }

        [Test]
        public void StartShouldCreateConfigurationWithLocalhostBaseAddress()
        {
            _fmServer.Start();
            Assert.AreEqual(_baseUrl, _fmServer.HttpConfiguration.BaseAddress.ToString());
        }

        [Test]
        public void StartShouldCreateConfigurationWithDefaultRoute()
        {
            _fmServer.Start();

            var routeTemplate = _fmServer.HttpConfiguration.Routes["Default"].RouteTemplate;
            Assert.AreEqual("{controller}/{action}/{id}", routeTemplate);
        }

        [Test]
        public void StartShouldCreateConfigurationWithOptionalIdParameter()
        {
            _fmServer.Start();

            var id = _fmServer.HttpConfiguration.Routes["Default"].Defaults["id"];
            Assert.AreEqual(RouteParameter.Optional, id);
        }

        [Test]
        public void StartShouldCreateConfigurationWithHomeControllerDefault()
        {
            _fmServer.Start();

            var route = _fmServer.HttpConfiguration.Routes["Default"];
            Assert.AreEqual("Home", route.Defaults["controller"]);
        }

        [Test]
        public void StartShouldCreateConfigurationWithIndexActionDefault()
        {
            _fmServer.Start();

            var route = _fmServer.HttpConfiguration.Routes["Default"];
            Assert.AreEqual("Index", route.Defaults["action"]);
        }

        [Test]
        public void StartShouldCreateHttpSelfHostServer()
        {
            _fmServer.Start();
            PingServer();
            _fmServer.Stop();
        }

        [Test]
        [ExpectedException(typeof(WebException))]
        public void StopShouldStopHttpServer()
        {
            _fmServer.Start();
            _fmServer.Stop();
            PingServer();
        }

        [TearDown]
        public void Teardown()
        {
            _fmServer.Stop();
        }

        private static void PingServer()
        {
            using (var webClient = new WebClient())
            {
                var content = webClient.DownloadString("http://localhost:9000/");
                Assert.IsTrue(content.Contains("OK"));
            }
        }
    }
}
