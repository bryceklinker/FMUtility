using System;
using System.Web.Http;
using System.Web.Http.SelfHost;
using FMUtility.Server.Configuration;

namespace FMUtility.Server
{
    public interface IServer : IDisposable
    {
        string Name { get; }
        void Start();
        void Stop();
    }

    public class FmServer : IServer
    {
        private HttpSelfHostConfiguration _httpConfiguration;
        private HttpSelfHostServer _server;
        private readonly IConfiguration _configuration;

        public HttpSelfHostConfiguration HttpConfiguration
        {
            get { return _httpConfiguration; }
        }

        public string Name
        {
            get { return "Football Manager Server"; }
        }

        public FmServer() : this(Configuration.Configuration.Instance)
        {

        }

        public FmServer(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Start()
        {
            _httpConfiguration = CreateConfiguration();
            _server = new HttpSelfHostServer(_httpConfiguration);
            _server.OpenAsync();
        }

        public void Stop()
        {
            if (_server != null)
                _server.CloseAsync().Wait();
        }

        public void Dispose()
        {
            if (_server != null)
                _server.Dispose();
        }

        private HttpSelfHostConfiguration CreateConfiguration()
        {
            var config = new HttpSelfHostConfiguration(_configuration.GetSetting("FmServer"));
            config.Routes.MapHttpRoute("Default", "{controller}/{action}/{id}", new
            {
                controller = "Home",
                action = "Index",
                id = RouteParameter.Optional
            });
            return config;
        }
    }
}
