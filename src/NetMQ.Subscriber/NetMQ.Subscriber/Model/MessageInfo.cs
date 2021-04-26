using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetMQ.Subscriber.Model
{
    public class MessageInfo
    {
        [JsonProperty("topic")]
        public string Topic { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
    }
    public class Message
    {
        [JsonProperty("subscribeTopic")]
        public string SubscribeTopic { get; set; }
        [JsonProperty("data")]
        public string Data { get; set; }
    }

    public class EquipEventMessage
    {
        [JsonProperty("m_iEquipNo")]
        public int EquipNo { get; set; }
        [JsonProperty("m_EquipNm")]
        public bool EquipName { get; set; }
        [JsonProperty("m_State")]
        public int State { get; set; }
        [JsonProperty("m_Bufang")]
        public string Bufang { get; set; }
        [JsonProperty("m_related_video")]
        public string RelatedVideo { get; set; }
        [JsonProperty("m_related_pic")]
        public string RelatedPic { get; set; }
        [JsonProperty("m_ZiChanID")]
        public string ZiChanID { get; set; }
        [JsonProperty("m_PlanNo")]
        public string PlanNo { get; set; }
    }

    public class YcEventMessage
    {
        [JsonProperty("m_iEquipNo")]
        public int EquipNo { get; set; }
        [JsonProperty("m_Bufang")]
        public bool Bufang { get; set; }
        [JsonProperty("m_iYCNo")]
        public int YcNo { get; set; }
        [JsonProperty("m_YCNm")]
        public string YcName { get; set; }
        [JsonProperty("m_YCValue")]
        public RealTimeValue YcValue { get; set; }
        [JsonProperty("m_Unit")]
        public string Unit { get; set; }
        [JsonProperty("m_related_video")]
        public string RelatedVideo { get; set; }
        [JsonProperty("m_related_pic")]
        public string RelatedPic { get; set; }
        [JsonProperty("m_ZiChanID")]
        public string ZiChanID { get; set; }
        [JsonProperty("m_PlanNo")]
        public string PlanNo { get; set; }
        [JsonProperty("m_IsAlarm")]
        public bool IsAlarm { get; set; }
        [JsonProperty("m_AdviceMsg")]
        public string AdviceMsg { get; set; }
        [JsonProperty("m_bHasHistoryCcurve")]
        public bool HasHistoryCcurve { get; set; }
        [JsonProperty("equipState")]
        public int EquipState { get; set; }
    }

    public class YxEventMessage
    {
        [JsonProperty("m_iEquipNo")]
        public int EquipNo { get; set; }
        [JsonProperty("m_Bufang")]
        public bool Bufang { get; set; }
        [JsonProperty("m_iYXNo")]
        public int YxNo { get; set; }
        [JsonProperty("m_YXNm")]
        public string YxName { get; set; }
        [JsonProperty("m_YXValue")]
        public RealTimeValue YxValue { get; set; }
        [JsonProperty("m_related_video")]
        public string RelatedVideo { get; set; }
        [JsonProperty("m_related_pic")]
        public string RelatedPic { get; set; }
        [JsonProperty("m_ZiChanID")]
        public string ZiChanID { get; set; }
        [JsonProperty("m_PlanNo")]
        public string PlanNo { get; set; }
        [JsonProperty("m_IsAlarm")]
        public YXAlarm IsAlarm { get; set; }
        [JsonProperty("m_AdviceMsg")]
        public string AdviceMsg { get; set; }
        [JsonProperty("m_bHasHistoryXcurve")]
        public bool HasHistoryCcurve { get; set; }
        [JsonProperty("equipState")]
        public int EquipState { get; set; }
        [JsonProperty("m_YXState")]
        public string State { get; set; }
    }

    public class RealTimeEventMessage
    {
        [JsonProperty("Related_video")]
        public string RelatedVideo { get; set; }
        [JsonProperty("ZiChanID")]
        public string ZiChanID { get; set; }
        [JsonProperty("PlanNo")]
        public string PlanNo { get; set; }
        [JsonProperty("User_confirm")]
        public string UserConfirm { get; set; }
        [JsonProperty("bConfirmed")]
        public bool IsConfirmed { get; set; }
        [JsonProperty("Time")]
        public DateTime Time { get; set; }
        [JsonProperty("Ycyxno")]
        public int YcYxNo { get; set; }
        [JsonProperty("Type")]
        public string Type { get; set; }
        [JsonProperty("Proc_advice_Msg")]
        public string ProcAdviceMsg { get; set; }
        [JsonProperty("Wavefile")]
        public string Wavefile { get; set; }
        [JsonProperty("Related_pic")]
        public string RelatedPic { get; set; }
        [JsonProperty("DT_Confirm")]
        public DateTime ConfirmTime { get; set; }
        [JsonProperty("EventMsg")]
        public string EventMsg { get; set; }
        [JsonProperty("Level")]
        public int Level { get; set; }
        [JsonProperty("Equipno")]
        public int EquipNo { get; set; }
        [JsonProperty("GUID")]
        public string Guid { get; set; }
    }

    public class SetEventMessage
    {
        [JsonProperty("bRecord")]
        public bool IsRecord { get; set; }
        [JsonProperty("bCanRepeat")]
        public bool IsCanRepeat { get; set; }
        [JsonProperty("bShowDlg")]
        public bool IsShowDlg { get; set; }
        [JsonProperty("Client_Instance_GUID")]
        public string ClientInstanceGUID { get; set; }
        public string Description { get; set; }
        public bool IsCj { get; set; }
        public bool IsWaitSetParm { get; set; }
        [JsonProperty("isQRTrigger")]
        public bool IsQRTrigger { get; set; }
        public string RequestId { get; set; }
        [JsonProperty("m_SetNo")]
        public int SetNo { get; set; }
        [JsonProperty("CJ_EqpNo")]
        public int CJEquipNo { get; set; }
        [JsonProperty("CJ_SetNo")]
        public int CJSetNo { get; set; }
        [JsonProperty("sysExecutor")]
        public string SysExecutor { get; set; }
        [JsonProperty("bOnlyDelayType")]
        public bool OnlyDelayType { get; set; }
        [JsonProperty("iDelayTime")]
        public int DelayTime { get; set; }
        public string UserIPandPort { get; set; }
        public string Value { get; set; }
        public string Type { get; set; }
        public string MinorInstruct { get; set; }
        public string MainInstruct { get; set; }
        public int StartTickCount { get; set; }
        public int WaitingTime { get; set; }
        public int EquipNo { get; set; }
        public string Executor { get; set; }
        [JsonProperty("csReserve1")]
        public string Reserve1 { get; set; }
        [JsonProperty("csReserve2")]
        public string Reserve2 { get; set; }
        [JsonProperty("csReserve3")]
        public string Reserve3 { get; set; }
        public bool? WaitSetParmIsFinish { get; set; }
        [JsonProperty("bStopSetParm")]
        public bool StopSetParm { get; set; }
    }

    public class RealTimeValue
    {
        [JsonProperty("s")]
        public string StringValue { get; set; }
        [JsonProperty("f")]
        public double? DoubleValue { get; set; }
        [JsonProperty("temp")]
        public int? Temp { get; set; }
        [JsonProperty("b")]
        public bool BoolValue { get; set; }
    }

    public class YXAlarm
    {
        [JsonProperty("temp")]
        public int Temp = 0;//-1为false，1为true
        [JsonProperty("b")]
        public bool B = true;
    }
}
