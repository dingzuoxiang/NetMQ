using NetMQ.Sockets;
using NetMQ.Subscriber.Enum;
using NetMQ.Subscriber.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetMQ.Subscriber
{
    class Program
    {
        static readonly string _subscriberAddress = "tcp://localhost:5588";
        private const string _topic = "ganweisoftapi/Debug";
        static SubscriberSocket subscriberSocket;
        static void Main(string[] args)
        {
            Console.WriteLine("Subscriber socket connecting...\n");
            subscriberSocket = new SubscriberSocket();
            subscriberSocket.Connect(_subscriberAddress);
            var task = new TaskFactory().StartNew(() =>
            {
                AddSubscribeAnyTopic();
                //AddSubscribe(TopicType.YcChangeEvent,11167);
                //XSubscriberSocket();
            }, TaskCreationOptions.LongRunning);
            ReceiveFrameString();
            while (Console.ReadKey().Key != ConsoleKey.Escape)
            {

            }
        }

        public static void AddSubscribeAnyTopic()
        {
            subscriberSocket.SubscribeToAnyTopic();
        }

        public static void AddSubscribe(TopicType topicType)
        {
            subscriberSocket.Subscribe($"{_topic}/{topicType}");
        }

        public static void AddSubscribe(TopicType topicType, int equipNo)
        {
            subscriberSocket.Subscribe($"{_topic}/{topicType}/{equipNo}");
        }

        private static void ReceiveFrameString()
        {
            while (true)
            {
                string messageTopicReceived = subscriberSocket.ReceiveFrameString();
                string messageReceived = subscriberSocket.ReceiveFrameString();
                Console.WriteLine($"{messageReceived}\n");
                //var messages = JsonConvert.DeserializeObject<List<MessageInfo>>(messageReceived);
                //foreach (var message in messages)
                //{
                //    DistributeMessage(message);
                //}
            }
        }

        private static void XSubscriberSocket()
        {
            using var subSocket = new SubscriberSocket();
            string loginMark = "";
            string userName = "";
            subSocket.Connect(_subscriberAddress);
            subSocket.Subscribe($"{_topic}/{TopicType.EquipAddEvent}");
            subSocket.Subscribe($"{_topic}/{TopicType.EquipChangeEvent}");
            subSocket.Subscribe($"{_topic}/{TopicType.EquipDeleteEvent}");
            subSocket.Subscribe($"{_topic}/{TopicType.YcChangeEvent}/{11151}");
            subSocket.Subscribe($"{_topic}/{TopicType.YxChangeEvent}/{11151}");
            subSocket.Subscribe($"{_topic}/{TopicType.SendControl}/{11151}");
            subSocket.Subscribe($"{_topic}/{TopicType.AddRealTimeSnapshot}");
            subSocket.Subscribe($"{_topic}/{TopicType.EquipStateEvent}");
            subSocket.Subscribe($"{_topic}/{TopicType.DeleteRealTimeSnapshot}");
            subSocket.Subscribe($"{_topic}/{TopicType.OpenPage4InterScreen}");
            subSocket.Subscribe($"{_topic}/{TopicType.ShowOrClosePage}");
            subSocket.Subscribe($"{_topic}/{TopicType.KickClient}/{loginMark}");
            subSocket.Subscribe($"{_topic}/{TopicType.ShowMsg}");
            subSocket.Subscribe($"{_topic}/{TopicType.NotifyOffLine}");
            subSocket.Subscribe($"{_topic}/{TopicType.NotifyRoleOffLine}");
            subSocket.Subscribe($"{_topic}/{TopicType.ShowLockSetParmMsg}");
            subSocket.Subscribe($"{_topic}/{TopicType.VOpenPage}/{userName}");
            subSocket.Subscribe($"{_topic}/{TopicType.ShowInfo}");
            subSocket.SubscribeToAnyTopic();
            Console.WriteLine("Subscriber socket connecting...\n");
            ReceiveFrameString();
        }

        static void DistributeMessage(MessageInfo message)
        {
            var topicType = (TopicType)System.Enum.Parse(typeof(TopicType), message.Topic.Split('/')[2]);
            StringBuilder builder = new StringBuilder();
            switch (topicType)
            {
                case TopicType.EquipAddEvent:
                    builder.Append("设备添加事件\n");
                    builder.Append($"topic：{message.Topic}\n");
                    builder.Append($"message：{message.Message}\n");
                    break;
                case TopicType.EquipChangeEvent:
                    builder.Append("设备变化事件\n");
                    builder.Append($"topic：{message.Topic}\n");
                    builder.Append($"message：{message.Message}\n");
                    break;
                case TopicType.EquipDeleteEvent:
                    builder.Append("设备删除事件\n");
                    builder.Append($"topic：{message.Topic}\n");
                    builder.Append($"message：{message.Message}\n");
                    break;
                case TopicType.YcAddEvent:
                    builder.Append("遥测添加事件\n");
                    builder.Append($"topic：{message.Topic}\n");
                    builder.Append($"message：{message.Message}\n");
                    break;
                case TopicType.YcChangeEvent:
                    builder.Append("遥测变化事件\n");
                    builder.Append($"topic：{message.Topic}\n");
                    //var data = JsonConvert.DeserializeObject<Message>(message.Message);
                    builder.Append($"message：{message.Message}\n");
                    break;
                case TopicType.YcDeleteEvent:
                    builder.Append("遥测删除事件\n");
                    builder.Append($"topic：{message.Topic}\n");
                    builder.Append($"message：{message.Message}\n");
                    break;
                case TopicType.YxAddEvent:
                    builder.Append("遥信添加事件\n");
                    builder.Append($"topic：{message.Topic}\n");
                    builder.Append($"message：{message.Message}\n");
                    break;
                case TopicType.YxChangeEvent:
                    builder.Append("遥信变化事件\n");
                    builder.Append($"topic：{message.Topic}\n");
                    builder.Append($"message：{message.Message}\n");
                    break;
                case TopicType.YxDeleteEvent:
                    builder.Append("遥信删除事件\n");
                    builder.Append($"topic：{message.Topic}\n");
                    builder.Append($"message：{message.Message}\n");
                    break;
                case TopicType.SetAddEvent:
                    builder.Append("设置添加事件\n");
                    builder.Append($"topic：{message.Topic}\n");
                    builder.Append($"message：{message.Message}\n");
                    break;
                case TopicType.SetChangeEvent:
                    builder.Append("设置变化事件\n");
                    builder.Append($"topic：{message.Topic}\n");
                    builder.Append($"message：{message.Message}\n");
                    break;
                case TopicType.SetDeleteEvent:
                    builder.Append("设置删除事件\n");
                    builder.Append($"topic：{message.Topic}\n");
                    builder.Append($"message：{message.Message}\n");
                    break;
                case TopicType.SendControl:
                    builder.Append("控制下发事件\n");
                    builder.Append($"topic：{message.Topic}\n");
                    builder.Append($"message：{message.Message}\n");
                    break;
                case TopicType.SendVoice:
                    builder.Append("语音下发事件\n");
                    builder.Append($"topic：{message.Topic}\n");
                    builder.Append($"message：{message.Message}\n");
                    break;
                case TopicType.AddRealTimeSnapshot:
                    builder.Append("添加实时快照事件\n");
                    builder.Append($"topic：{message.Topic}\n");
                    builder.Append($"message：{message.Message}\n");
                    break;
                case TopicType.DeleteRealTimeSnapshot:
                    builder.Append("删除实时快照事件\n");
                    builder.Append($"topic：{message.Topic}\n");
                    builder.Append($"message：{message.Message}\n");
                    break;
                case TopicType.EquipStateEvent:
                    builder.Append("设备状态事件\n");
                    builder.Append($"topic：{message.Topic}\n");
                    builder.Append($"message：{message.Message}\n");
                    break;
            }
            Console.WriteLine(builder);
            builder.Clear();
        }
    }
}
