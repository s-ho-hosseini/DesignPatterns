

using System;

namespace ChainOfResponsibility 
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var compresser = new Compresser(null);
            var logger = new Logger(compresser);
            var autenticator = new Authenticator(logger);
            var server = new WebServer(autenticator);
            server.Handle(new HttpRequest("amir","salam"));
        }
    }

    public abstract class Handler
    {
        private Handler? next;

        public Handler(Handler? next)
        {
            this.next = next;
        }

        public void Handle(HttpRequest request)
        {
            if (Execute(request)) return;

            if (next != null) next.Handle(request);
        }

        public abstract bool Execute(HttpRequest request);
    }

    public class HttpRequest
    {
        public HttpRequest(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        public string UserName { get; }
        public string Password { get; }
    }

    public class WebServer
    {
        private Handler handler;

        public WebServer(Handler handler)
        {
            this.handler = handler; 
        }

        public void Handle(HttpRequest request)
        {
            handler.Handle(request);
        }
    }

    public class Authenticator : Handler
    {
        public Authenticator(Handler next) : base(next) { }


        public override bool Execute(HttpRequest request)
        {
            Console.WriteLine("Authenticate");
            return request.UserName != "amir" || request.Password != "salam";
        }
    }

    public class Compresser : Handler
    {
        public Compresser(Handler? next) : base(next)
        {
        }

        public override bool Execute(HttpRequest request)
        {
            Console.WriteLine("Compress");
            return false;
        }
    }

    public class Logger : Handler
    {
        public Logger(Handler next) : base(next)
        {
        }

        public override bool Execute(HttpRequest request)
        {
            Console.WriteLine("Log");

            return false;

        }

    }
}
