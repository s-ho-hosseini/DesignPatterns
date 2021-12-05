using System;

namespace Facade
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var service = new NotificationService();
            service.Send("","");
        }

        public class Message
        {
            private string _contet;

            public Message(string contet)
            {
                _contet = contet;
            }
        }

        public class NotificationService
        {
            public void Send(string message, string taregt)
            {
                var server = new NotificationServer();
                var connection = server.Connect("ip");
                var authToken = server.Authentication("appId", "key");
                server.Send(authToken, new Message(message), taregt);
                connection.Disconnect();
            }
        }

        public class NotificationServer
        {
            public Connection Connect(string ipAddress)
            {
                return new Connection();
            }

            public AuthToken Authentication(string appId, string key)
            {
                return new AuthToken();
            }

            public void Send(AuthToken authToken, Message message, string target)
            {
                Console.WriteLine("Sending a message");
            }
        }

        public class Connection
        {
            public void Disconnect()
            {
            }
        }

        public class AuthToken
        {
        }
    }
}