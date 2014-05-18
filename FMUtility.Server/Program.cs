using System;

namespace FMUtility.Server
{
    public class Program
    {
        private readonly IServer _server;
        private static Program _instance;

        public static Program Instance
        {
            get { return _instance ?? (_instance = new Program()); }
        }

        private Program() : this(new FmServer())
        {

        }

        public Program(IServer server)
        {
            _server = server;
        }

        public static void Main(string[] args)
        {
            Instance.Start();
            Console.ReadLine();
            Instance.Stop();
        }

        public void Start()
        {
            _server.Start();
        }

        public void Stop()
        {
            _server.Stop();
            _server.Dispose();
        }
    }
}
