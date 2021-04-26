using NetMQ;
using NetMQ.Sockets;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using NetMQ.Monitoring;

namespace netmqsample.client
{
    class Program
    {
        static string address = "tcp://127.0.0.1:5555";
        static string publishSocketAddress = "tcp://127.0.0.1:5588";

        static PushSocket push;
        static byte[] fileBytes = null;
        static string fileName = @$"E:\文件\MobaXterm_Portable_v11.1.zip";
        static NetMQQueue<byte[]> queue = new NetMQQueue<byte[]>();

        static void Main(string[] args)
        {
            Console.WriteLine("推送程序已启动!");

            //fileBytes = ReadFile(fileName);
            //var task = new TaskFactory().StartNew(async () =>
            //{
            //    await CreatePushSocket();
            //}, TaskCreationOptions.LongRunning);

            var task2= new TaskFactory().StartNew(async () =>
            {
                CreateSubSocket();
            }, TaskCreationOptions.LongRunning);

            //var task1 = new TaskFactory().StartNew(async () =>
            //{
            //    while (true)
            //    {
            //        if (isConnect)
            //        {
            //            var md5Bytes = Encoding.UTF8.GetBytes(MD5(fileBytes));
            //            var timeBytes = Encoding.UTF8.GetBytes(System.DateTime.Now.ToString("yyyyMMddHHmmssfff"));
            //            var resultBytes = new byte[fileBytes.Length + md5Bytes.Length + timeBytes.Length];
            //            md5Bytes.CopyTo(resultBytes, 0);
            //            timeBytes.CopyTo(resultBytes, md5Bytes.Length);
            //            fileBytes.CopyTo(resultBytes, md5Bytes.Length + timeBytes.Length);
            //            queue.Enqueue(resultBytes);
            //            await Task.Delay(100);
            //            //Console.Out.WriteLine(@$"上传文件{fileName},{System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff")}");
            //        }

            //    }
            //}, TaskCreationOptions.LongRunning);


            while (Console.ReadKey().Key != ConsoleKey.Escape)
            {

            }
        }





        //using (var poller = new NetMQPoller())
        //{
        //    var pull = new PullSocket();
        //    pull.ReceiveReady += Pull_ReceiveReady; 
        //    pull.Bind(address);
        //    poller.Add(pull);
        //    poller.RunAsync();  
        //    //while (true)
        //    //{
        //    //    byte[] fileBytes = sink.ReceiveFrameBytes();
        //    //    byte[] md5Byte = sink.ReceiveFrameBytes();
        //    //    string md5 = Encoding.UTF8.GetString(md5Byte);
        //    //    string fileName = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Temp", md5, ".zip");
        //    //    if (!System.IO.File.Exists(fileName))
        //    //        WriteFile(fileName, fileBytes);

        //    //    if (!string.Equals(md5, MD5(fileBytes)))
        //    //        Console.Out.WriteLine("上传文件不合法");

        //    //    Console.Out.WriteLine(@$"接收文件{fileName}，{System.DateTime.Now.ToString()}");

        //    //}
        //}

        static bool isConnect = false;


        private static async Task CreatePushSocket()
        {
            var poller = new NetMQPoller();
            push = new PushSocket();
            push.BindRandomPort("tcp://127.0.0.1");
            NetMQMonitor monitor = new NetMQMonitor(push, "inproc://req.inproc", SocketEvents.All);
            monitor.Connected += Monitor_Connected;
            monitor.EventReceived += Monitor_EventReceived;
            //monitor.AttachToPoller(poller); 
            queue.ReceiveReady += Queue_ReceiveReady; ;
            push.Connect(address);
            poller.Add(push);
            poller.Add(queue);
            poller.RunAsync();
            await monitor.StartAsync(); 
        }

        private static void CreateSubSocket()
        {
            int equipNo = 1;
            var subSocket = new SubscriberSocket();
            subSocket.Connect(publishSocketAddress);
            //subSocket.Subscribe("ganweisoftapi/Debug/EquipAddEvent");
            //subSocket.Subscribe($"ganweisoftapi/Debug/EquipChangeEvent/{equipNo}");
            //subSocket.Subscribe($"ganweisoftapi/Debug/EquipDeleteEvent/{equipNo}");
            //subSocket.Subscribe($"ganweisoftapi/Debug/YcAddEvent/{equipNo}");
            //subSocket.Subscribe($"ganweisoftapi/Debug/YcChangeEvent/{equipNo}");
            //subSocket.Subscribe($"ganweisoftapi/Debug/YcDeleteEvent/{equipNo}");
            //subSocket.Subscribe($"ganweisoftapi/Debug/YxAddEvent/{equipNo}");
            //subSocket.Subscribe($"ganweisoftapi/Debug/YxChangeEvent/{equipNo}");
            //subSocket.Subscribe($"ganweisoftapi/Debug/YxDeleteEvent/{equipNo}");
            //subSocket.Subscribe($"ganweisoftapi/Debug/SetAddEvent/{equipNo}");
            //subSocket.Subscribe($"ganweisoftapi/Debug/SetChangeEvent/{equipNo}");
            //subSocket.Subscribe($"ganweisoftapi/Debug/SetDeleteEvent/{equipNo}");
            //subSocket.Subscribe($"ganweisoftapi/Debug/SendControl/{equipNo}");
            //subSocket.Subscribe($"ganweisoftapi/Debug/SendVoice/{equipNo}");
            subSocket.Subscribe($"ganweisoftapi/Debug/AddRealTimeSnapshot/11151");

            //subSocket.SubscribeToAnyTopic();
            int i = 1;
            while (true)
            {
                //if (i == 10)
                //    break;
                string messageTopicReceived = subSocket.ReceiveFrameString();
                string messageReceived = subSocket.ReceiveFrameString();
                Console.WriteLine(messageReceived);
                i++;
            }
            subSocket.Close();
        }

        private static void Monitor_EventReceived(object sender, NetMQMonitorEventArgs e)
        {
            //if (!isConnect)
            //    isConnect = e.SocketEvent == SocketEvents.Connected || e.SocketEvent == SocketEvents.Accepted;
        }

        private static void Monitor_Connected(object sender, NetMQMonitorSocketEventArgs e)
        {
            if (!isConnect)
                isConnect = string.Equals(e.Address, address);
        }

        private static void Queue_ReceiveReady(object sender, NetMQQueueEventArgs<byte[]> e)
        {
            if (e.Queue.TryDequeue(out byte[] result, TimeSpan.FromSeconds(1.0)))
            {
                push.SendFrame(result);
            }
        }

        static byte[] ReadFile(string filePath)
        {
            using var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);

            byte[] fileBytes = new byte[fileStream.Length];

            fileStream.Read(fileBytes);

            return fileBytes;
        }

        static void WriteFile(string filePath, byte[] fileBytes)
        {
            using var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            fileStream.Write(fileBytes, 0, fileBytes.Length);
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
