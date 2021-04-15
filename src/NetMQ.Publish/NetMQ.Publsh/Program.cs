using NetMQ.Sockets;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NetMQ.Publsh
{
    class Program
    {
        static void Main(string[] args)
        {
            var task1 = new TaskFactory().StartNew(() =>
            {
                Intermediary();
            }, TaskCreationOptions.LongRunning);
            XPublisherSocket();
        }

        private static void PublisherSocket()
        {
            Random rand = new Random(50);
            using var pubSocket = new PublisherSocket();
            Console.WriteLine("Publisher socket binding...");
            pubSocket.Options.SendHighWatermark = 1000;
            pubSocket.Bind("tcp://*:12345");
            for (var i = 0; i < 100; i++)
            {
                var randomizedTopic = rand.NextDouble();
                if (randomizedTopic > 0.5)
                {
                    var msg = "TopicA msg-" + i;
                    Console.WriteLine("Sending message : {0}", msg);
                    pubSocket.SendMoreFrame("TopicA").SendFrame(msg);
                }
                else
                {
                    var msg = "TopicB msg-" + i;
                    Console.WriteLine("Sending message : {0}", msg);
                    pubSocket.SendMoreFrame("TopicB").SendFrame(msg);
                }
                Thread.Sleep(500);
            }
        }

        private static void XPublisherSocket()
        {
            using var pubSocket = new PublisherSocket(">tcp://127.0.0.1:5678");
            Console.WriteLine("Publisher socket connecting...");
            pubSocket.Options.SendHighWatermark = 1000;
            var rand = new Random(50);

            while (true)
            {
                var randomizedTopic = rand.NextDouble();
                if (randomizedTopic > 0.5)
                {
                    var msg = randomizedTopic.ToString();
                    Console.WriteLine("Sending message : {0}", msg);
                    pubSocket.SendMoreFrame($"{TopicEvnet.YcYxSetChangeEvent}/1").SendFrame(msg);
                }
                else
                {
                    var msg = "TopicB msg-" + randomizedTopic;
                    Console.WriteLine("Sending message : {0}", msg);
                    pubSocket.SendMoreFrame("TopicB").SendFrame(msg);
                }
                Thread.Sleep(500);
            }
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

    public enum TopicEvnet
    {
        /// <summary>
        /// 
        /// </summary>
        Define = 0,
        /// <summary>
        /// 设备添加
        /// </summary>
        EquipAddEvent = 1,
        /// <summary>
        /// 设备属性变化
        /// </summary>
        EquipChangeEvent = 2,
        /// <summary>
        /// 设备删除
        /// </summary>
        EquipDeleteEvent = 3,
        /// <summary>
        /// 遥测、遥信、设置添加
        /// </summary>
        YcYxSetAddEvent = 4,
        /// <summary>
        /// 遥测、遥信、设置属性变化
        /// </summary>
        YcYxSetChangeEvent = 5,
        /// <summary>
        /// 遥测、遥信、设置删除
        /// </summary>
        YcYxSetDeleteEvent = 6,
        /// <summary>
        /// 下发控制
        /// </summary>
        SendControl = 7,
        /// <summary>
        /// 实时快照
        /// </summary>
        RealTimeSnapshot = 8,
        /// <summary>
        /// 下发语音
        /// </summary>
        SendVoice = 9,
    }
}
