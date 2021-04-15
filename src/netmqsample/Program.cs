using NetMQ;
using NetMQ.Monitoring;
using NetMQ.Sockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace netmqsample
{
    class Program
    {
        static string address = "tcp://localhost:5555";
        static string publishSocketAddress = "tcp://localhost:5588";

        static PullSocket pull = new PullSocket();

        static PublisherSocket publisherSocket = new PublisherSocket();
        static void Main(string[] args)
        {
            Console.WriteLine("接收程序已启动!");

            var task1 = new TaskFactory().StartNew(() =>
            {
                CreatePullSocket();
            }, TaskCreationOptions.LongRunning);

            var task2 = new TaskFactory().StartNew(() =>
            {
                CreatePublishSocket();
            }, TaskCreationOptions.LongRunning);
            while (Console.ReadKey().Key != ConsoleKey.Escape)
            {

            }
        }
        private static void CreatePullSocket()
        {
            try
            {
                var poller = new NetMQPoller();
                NetMQMonitor monitor = new NetMQMonitor(pull, "inproc://req.inproc", SocketEvents.All);
                monitor.Accepted += Monitor_Accepted;
                monitor.EventReceived += Monitor_EventReceived;
                pull.ReceiveReady += Pull_ReceiveReady1;
                pull.Bind(address);
                //monitor.AttachToPoller(poller);
                poller.Add(pull);
                poller.RunAsync();
                monitor.StartAsync();
            }
            catch (Exception ex)
            {

            }
        }

        private static void CreatePublishSocket()
        {
            try
            {
                //var poller = new NetMQPoller();
                //NetMQMonitor monitor = new NetMQMonitor(publisherSocket, "inproc://req.inproc", SocketEvents.All);
                //monitor.Accepted += Monitor_Accepted;
                //monitor.EventReceived += Monitor_EventReceived;
                //publisherSocket.ReceiveReady += Pull_ReceiveReady1;
                publisherSocket.Bind(publishSocketAddress);
                //monitor.AttachToPoller(poller);
                //poller.Add(pull);
                //poller.RunAsync();
                //monitor.StartAsync();
            }
            catch (Exception ex)
            {

            }
        }

        private static void Monitor_EventReceived(object sender, NetMQMonitorEventArgs e)
        {
            Console.WriteLine(e);
            //throw new NotImplementedException();
        }

        private static void Monitor_Accepted(object sender, NetMQMonitorSocketEventArgs e)
        {
            Console.WriteLine(e.Socket.RemoteEndPoint);
            string addr = @$"tcp://{e.Socket.RemoteEndPoint.ToString()}";  
        }

        private static void Pull_ReceiveReady1(object sender, NetMQSocketEventArgs e)
        {
            var fileByte = e.Socket.ReceiveFrameBytes();
            var md5Str = Encoding.UTF8.GetString(fileByte.Take(128).ToArray());
            var time = Encoding.UTF8.GetString(fileByte.Skip(md5Str.Length).Take(17).ToArray());
            DateTime sendTime = DateTime.ParseExact(time, "yyyyMMddHHmmssfff", null);

            int takeSize = md5Str.Length + time.Length;
            var bodyBytes = fileByte.Skip(takeSize).TakeLast(fileByte.Length - takeSize).ToArray();

            DateTime reciveDateTime = System.DateTime.Now;

            string md5 = MD5(bodyBytes);

            if (!string.Equals(md5Str, md5))
            {
                Console.Out.WriteLine($"上传文件不合法， {System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff")}");
            }
            else
                Console.Out.WriteLine($"接收文件成功，文件大小为{bodyBytes.Length}， {reciveDateTime.ToString("yyyy-MM-dd HH:mm:ss fff")},发送时间为{sendTime.ToString("yyyy-MM-dd HH:mm:ss fff")},耗时：{(reciveDateTime - sendTime).TotalMilliseconds}");
            string addr = @$"{e.Socket.Options.LastEndpoint}";

            publisherSocket.SendMoreFrame(addr).SendFrame("test");

        }
        static string MD5(byte[] bytes)
        {
            using (var hmac = new HMACSHA512(bytes))
            {
                var byteNew = hmac.ComputeHash(bytes);

                StringBuilder sb = new StringBuilder();

                foreach (byte b in byteNew)
                {
                    // 将字节转换成16进制表示的字符串，
                    sb.Append(b.ToString("x2"));
                }
                // 返回加密的字符串
                return sb.ToString();
            }
        }
    }
}
