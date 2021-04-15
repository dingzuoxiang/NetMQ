using System;
using System.Collections.Generic;
using System.Text;

namespace NetMQ.Subscriber.Enum
{
    public enum TopicType
    {
        EquipAddEvent,
        EquipChangeEvent,
        EquipDeleteEvent,
        EquipAlarmEvent,
        YcAddEvent,
        YcChangeEvent,
        YcDeleteEvent,
        YxAddEvent,
        YxChangeEvent,
        YxDeleteEvent,
        SetAddEvent,
        SetChangeEvent,
        SetDeleteEvent,
        SendControl,
        SendVoice,
        AddRealTimeSnapshot,
        DeleteRealTimeSnapshot,
    }
}
