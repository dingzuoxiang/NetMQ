using NetMQ.Sockets;
using System;

namespace NetMQ.Intermediary
{
    class Program
    {
        static void Main(string[] args)
        {
            Intermediary();
        }

        private static void Intermediary()
        {
            using var xpubSocket = new XPublisherSocket("@tcp://localhost:1234");
            using var xsubSocket = new XSubscriberSocket("@tcp://127.0.0.1:5678");
            Console.WriteLine("Intermediary started, and waiting for messages");
            // proxy messages between frontend / backend
            var proxy = new Proxy(xsubSocket, xpubSocket);
            // blocks indefinitely
            proxy.Start();
        }
    }
}
