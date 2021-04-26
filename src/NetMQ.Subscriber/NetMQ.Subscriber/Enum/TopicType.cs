using System.ComponentModel;

namespace NetMQ.Subscriber.Enum
{
    public enum TopicType
    {
        [Description("{0}")]
        /// <summary>
        /// 设备添加事件
        /// </summary>
        EquipAddEvent = 1,
        [Description("{0}")]
        /// <summary>
        /// 设备属性变化事件
        /// </summary>
        EquipChangeEvent = 2,
        [Description("{0}")]
        /// <summary>
        /// 设备删除事件
        /// </summary>
        EquipDeleteEvent = 3,
        [Description("{0}")]
        /// <summary>
        /// 设备状态事件
        /// </summary>
        EquipStateEvent = 4,
        [Description("{0}/{1}")]
        /// <summary>
        /// 遥测添加事件
        /// </summary>
        YcAddEvent = 5,
        [Description("{0}/{1}")]
        /// <summary>
        /// 遥测属性变化事件
        /// </summary>
        YcChangeEvent = 6,
        [Description("{0}/{1}")]
        /// <summary>
        /// 遥测删除事件
        /// </summary>
        YcDeleteEvent = 7,
        [Description("{0}/{1}")]
        /// <summary>
        /// 遥信添加事件
        /// </summary>
        YxAddEvent = 8,
        [Description("{0}/{1}")]
        /// <summary>
        /// 遥信属性变化事件
        /// </summary>
        YxChangeEvent = 9,
        [Description("{0}/{1}")]
        /// <summary>
        /// 遥信删除事件
        /// </summary>
        YxDeleteEvent = 10,
        [Description("{0}/{1}")]
        /// <summary>
        /// 设置添加事件
        /// </summary>
        SetAddEvent = 11,
        [Description("{0}/{1}")]
        /// <summary>
        /// 设置属性变化事件
        /// </summary>
        SetChangeEvent = 12,
        [Description("{0}/{1}")]
        /// <summary>
        /// 设置删除事件
        /// </summary>
        SetDeleteEvent = 13,
        [Description("{0}/{1}")]
        /// <summary>
        /// 下发控制
        /// </summary>
        SendControl = 14,
        [Description("{0}")]
        /// <summary>
        /// 下发语音
        /// </summary>
        SendVoice = 15,
        [Description("{0}")]
        /// <summary>
        /// 添加实时快照
        /// </summary>
        AddRealTimeSnapshot = 16,
        [Description("{0}")]
        /// <summary>
        /// 删除实时快照
        /// </summary>
        DeleteRealTimeSnapshot = 17,
        /// <summary>
        /// 打开屏幕
        /// </summary>
        OpenPage4InterScreen = 18,
        /// <summary>
        /// 开启/关闭窗口
        /// </summary>
        ShowOrClosePage = 19,
        /// <summary>
        /// 回调客户端
        /// </summary>
        CallBackToClient = 20,
        /// <summary>
        /// 回调客户端
        /// </summary>
        [Description("{0}/{1}")]
        KickClient = 21,
        /// <summary>
        /// 回调客户端
        /// </summary>
        ShowMsg = 22,
        /// <summary>
        /// 回调客户端
        /// </summary>
        NotifyOffLine = 23,
        /// <summary>
        /// 角色修改，用户下线
        /// </summary>
        NotifyRoleOffLine = 24,
        /// <summary>
        /// 锁定
        /// </summary>
        ShowLockSetParmMsg = 25,
        /// <summary>
        /// 打开页面
        /// </summary>
        VOpenPage = 26,
        /// <summary>
        /// 显示提示信息
        /// </summary>
        ShowInfo = 27,
    }
}
