﻿using UnityEngine;

[System.Serializable]
public enum EnumEventType
{
    None,
    Event_Change_Language,
    Event_TrackEditor_ModelInput,//修改索引
    #region 游戏逻辑
    Event_Load_TrackData,  //加载完成Track数据 
    Event_Load_IdleData,//加载Idle数据
    Event_Load_ProcessChange,//数据加载进度改变
    Event_Load_PlayerData,//玩家数据  
    Event_Load_Complete,//加载完所有数据
    Event_Game_Began,//游戏开始
    Event_Idle_TruckBack,//卡车回到出货点
    Event_Idle_TruckLoad,//卡车回到出货点装货
    Event_Idle_StaffTruckLoad,//快递中心快递员给卡车装货
    Event_Idle_TruckMove,//卡车回到出货点装货完成,开始移动
    Event_Idle_RemoveSiteTruck,//驿站卡车在驿站卸完货之后从停车位中移除
    Event_Idle_LoadItem,//卡车装货
    Event_City_ChangeVolume, //站点容量升级（关闭UI发消息）
    Event_City_ChangeCycle, //站点送货周期升级（关闭UI发消息）
    Event_City_ChangeStoreVolume,//站点仓库容量升级
    Event_City_ChangeStoreRest,//站点货物剩余量变化
    Event_City_UnLoadStoreItem,//卸载快递中心货架上货物
    Event_City_ChangeCityStaffCount,//快递中心员工数变化
    Event_City_UnlockShelf,//解锁货架
    Event_Site_UnLock, //解锁驿站 (UI界面解锁发消息)
    Event_Site_BaseGrade,//驿站基础升级
    Event_Site_TimeGrade,//驿站快递员配送时间升级
    Event_Site_VolumeGrade,//驿站容量升级
    Event_Site_StaffCount,//驿站员工数量升级
    Event_Site_ChangeRest,//驿站货物堆积数量变化  参数 int siteId(驿站id)
    Event_Site_CanUnlock,//是否可以解锁驿站 参数 bool (是否可以解锁)
    Event_Truck_ChangeMaxCount,//当前城市卡车最大数量变化(无参数)
    Event_Truck_ChangeVolumeLv,//当前城市卡车装货量等级变化(无参数)
    //Event_Truck_ChangeCount,//某类(或多类)卡车数量变化(bool isChange 是否发生数量变化)
    Event_Task_ProcessChange,//任务进程变化 参数 int taskType(任务类型) 一般在升级或建造后调用
    Event_Task_MainTaskComplete,//主线任务完成事件
    Event_Task_ShowMainTaskCompleteTip,//主线任务完成tip
    Event_Camera_Arrive,//相机到达指定位置

    Event_CityTruck_Arrive,//送到快递中心的卡车到达
    Event_CityTruck_UnLoad,//送到快递中心卡车卸货
    Event_CityTruck_SetTotalVolume,//设置快递中心卡车容量
    Event_Feiji_StartMove,//飞机开始移动
    Event_Feiji_Move,//飞机移动
    Event_Feiji_MoveComplete,// 飞机单个行程完成
    Event_Feiji_ConfirmDrop,//空投界面确认投放
    Event_BigCloud_OnClick,//大的云层点击
    #endregion

    Event_Idle_MoneyChange,//玩家钞票改变
    Event_Idle_MoneyReduce,//玩家钞票减少
    Event_Idle_TotalIncomeChange,//玩家总收益改变
    Event_Idle_ExpChange,//玩家经验改变
    Event_Idle_UpdateStarExp,//更新玩家经验
    Event_Idle_UpdateStarCount,//更新玩家星级数
    Event_Idle_DiamondChange,//玩家钻石变化

    #region 新手引导相关
    Event_Guide_StartGuide,//开始引导
    Event_Guide_StartFirstStep,//开始第一步引导
    Event_Guide_StartGuideStep,//引导步骤开始
    Event_Guide_JudgeStepComplete,//判断步骤是否完成
    Event_Guide_GuideComplete,//引导已完成
    Event_Guide_StepComplete,//步骤已完成
    Event_Guide_StartListenGuide,//开始监听引导
    Event_Guide_TargetArrive,//引导目标到达指定地点

    //配置到引导配置中的事件
    Event_GuideConfig_ShowRewardNpcBubble,//显示招财猫的奖励气泡
    Event_GuideConfig_ShowCityGuideCollider,//显示快递中心碰撞体
    Event_GuideConfig_HideCityGuideCollider,//隐藏快递中心碰撞体
    Event_GuideConfig_StartFollowListening,//开始监听跟随目标是否到达事件
    Event_GuideConfig_EndFollowListening,//结束监听跟随目标是否到达事件
    Event_GuideConfig_HideMenuBtn,//隐藏菜单按钮(不会再显示)
    Event_GuideConfig_ShowMenuBtn,//显示菜单按钮
    Event_GuideConfig_StopInvestor,
    Event_GuideConfig_SiteOwnerEnd,//店长引导结束
    #endregion

    #region 特殊事件相关
    Event_SpecialEvent_Prepare,//刚触发特殊事件
    Event_SpecialEvent_Start,//特殊事件开始
    Event_SpecialEvent_ToEnd,//关闭界面结束特殊事件
    Event_SpecialEvent_End,//特殊事件结束无参数
    Event_SpecialEvent_Update,//特殊事件更新  参数 int restTime 剩余时间(用于通知界面显示倒计时)
    Event_SpecialEvent_ChangeItemPrice,//改变驿站货物单价 第一个参数int siteId(驿站id) 第二个参数int times(倍数)
    Event_SpecialEvent_ChangeItemCount,//改变站点获得某种货物数量 第一个参数int itemId(货物id) 第二个参数int times(倍数)
    Event_SpecialEvent_ChangeForkVolume,//改变叉车容量上限<int>(容量倍数)
    Event_SpecialEvent_ChangeCityTruckVolume,//改变大货车容量上限<int>(容量倍数)
    Event_SpecialEvent_ChangeForkSpeed,//改变叉车速度<int>(速度倍数)
    Event_SpecialEvent_ChangeSiteStaffSpeed,//改变快递中心员工移动速度<int>(移动速度倍数)
    Event_SpecialEvent_ChangeTruckSpeed,//改变配送车辆移动速度
    Event_SpecialEvent_ChangePostSiteStaffSpeed,//改变驿站员工（包括配送人员和搬运人员）移动速度<int>(移动速度倍数)
    #endregion

    #region 投资人相关
    Event_Investor_Prepare,//投资人事件准备（按钮弹出）
    Event_Investor_Restart,//重新开始投资人时间(不领取奖励)
    Event_Investor_End,//投资人事件结束(领取奖励)
    #endregion

    #region 双倍收益相关
    Event_DoubleIncome_Start,//开始双倍收益
    //Event_DoubleIncome_End,//结束双倍收益
    Event_DoubleIncome_Update,//双倍收益更新 (每秒更新）
    Event_DoubleIncome_Change,//双倍收益改变
    Event_DoubleIncome_OwnerGain,//店长领取
    #endregion

    #region 升级操作提示相关
    Event_ActionTip_Trigger,//当有操作提示按钮要出现时调用
    Event_ActionTip_End,//当操作提示结束时调用
    Event_ActionTip_TriggerTruckCount,//当需要升级货车数量时调用
    #endregion


    #region UI相关
    Event_Truck_EnableCountChange,//可用卡车数变化
    Event_IdleWindow_ShowMenuBtns,//显示主页菜单按钮(参数bool isShow)
    Event_IdleWindow_ForceHideMenuBtns,//强制关闭菜单按钮
    Event_Window_ShowPostSite,//显示驿站界面
    Event_Window_ShowSite,//显示站点界面
    Event_Window_ShowTruck,//显示卡车界面
    Event_Window_ShowBuild,//显示建造界面
    Event_Window_ShowMap,//显示地图界面
    Event_Window_ShowStatistics,//显示统计界面
    Event_Window_ShowSiteOwner,//显示店长界面
    Event_Window_ShowDiamondShop,//显示钻石商店界面
    Event_Window_CloseTask,//关闭任务界面
    Event_Window_CloseCurrentWindow,//关闭当前窗口
    Event_SiteInfo_UnLock,//UI成功解锁驿站
    Event_TaskItem_Out,//移除任务
    Event_TaskBtn_ShowNode,//任务按钮显示有任务完成标志点
    Event_TaskBtn_ShowFingerTimer,//开始显示任务按钮手指提示计时器
    Event_MapBtn_ShowNode,//显示地图按钮有可解锁城市标志点
    Event_Camera_MoveToTarget,//摄像机移动到指定位置(vector2 pos )
    Event_Camera_SimpleMoveToTarget,//摄像机移动到指定位置（不记录初始位置）
    Event_Camera_SimpleMoveArrive,
    Event_Camera_MoveBack,//摄像机回到移动前的位置
    Event_Camera_FollowOther,//相机跟随(Transform target)
    Event_Camera_FinishFollow,//相机结束跟随
    Event_MapWindow_CityBtnClick,//地图城市按钮点击事件
    Event_StatisticsWindow_GotoPostSite,//统计界面跳转到驿站界面
    #endregion

    #region 店长
    Event_SiteOwner_ShowFunc,//显示店长功能
    Event_Window_ShopOwnerWindow,
    Event_ShopOwnerUpgradeLevel, // 店长升级
    Event_ShopOwnerUpgradeStar, // 店长升星
    Event_SiteOwner_Appointed,//指派店长
    Event_SiteOwner_Resign,//卸任店长
    Event_UI_SiteOwner_Appoint,//指派店长-ui
    Event_UI_SiteOwner_Resign,//卸任店长-ui
    Event_UI_ShowOrHideSiteOwnerNode,//显示或隐藏店长相关节点（场景中）
    Event_SiteOwner_ChangeOwner,//存在驿站店长改变

    Event_SiteOwner_TriggerActiveSkill,//释放主动技能
    Event_SiteOwner_ActiveSkillEnd,//主动技能结束

    Event_SiteOwner_Video_ShowBar,// 店长视频显示侧边按钮

    #endregion

    #region 宝箱获取钻石系统
    /// <summary>
    /// 宝箱观看视频结束
    /// </summary>
    Event_Box_WatchVideoFinish,
    /// <summary>
    /// 宝箱有钻石可以领取
    /// </summary>
    Event_Box_AddDiamond,
    /// <summary>
    /// 商店钻石领取
    /// </summary>
    Event_Box_DiamondGain,
    #endregion


    #region 盲盒相关
    Event_BlindBox_UpdateCD,//盲盒计时中
    Event_BlindBox_End,//当一次盲盒结束后
    #endregion


    Event_UIGuide,//新手引导
    


    #region 新增事件类型

    Event_UIMainWindow_Star,//星数变化
    Event_UIMainWindow_Goods,//货物变化
    Event_UIMainWindow_TimeOut,//计时结束
    Event_UIMainWindow_Complete,//完成游戏目标
    Event_Track_AddMidTrackSite,//从中间添加站点
    Event_Track_UAVOverDeleteLine,//无人机走过待删除的路线
    Event_Track_UAVMove,//无人机移动
    Event_Track_UAVIdle,//无人机静止

    #endregion


    EventTypeEnd
}

[System.Serializable]
public class BaseEventArgs
{
    public EnumEventType eventType;
    
    public BaseEventArgs(EnumEventType type)
    {
        eventType = type;
    }
}

[System.Serializable]
public class EventArgsOne<T> : BaseEventArgs
{
    public T param1;
    
    public EventArgsOne(EnumEventType type, T p1) : base(type)
    {
        param1 = p1;
    }
}

[System.Serializable]
public class EventArgsTwo<T1, T2> : EventArgsOne<T1>
{
    public T2 param2;

    public EventArgsTwo(EnumEventType type, T1 p1, T2 p2) : base(type, p1)
    {
        param2 = p2;
    }
}

[System.Serializable]
public class EventArgsThree<T1, T2, T3> : EventArgsTwo<T1, T2>
{
    public T3 param3;

    public EventArgsThree(EnumEventType type, T1 p1, T2 p2, T3 p3) : base(type, p1, p2)
    {
        param3 = p3;
    }
}

public delegate void OnTouchEventHandle(GameObject _listener, object _args, params object[] _params);
public enum EnumTouchEventType
{
    OnClick,
    OnDoubleClick,
    OnDown,
    OnUp,
    OnEnter,
    OnExit,
    OnSelect,
    OnUpdateSelect,
    OnDeSelect,
    OnDrag,
    OnDragEnd,
    OnDrop,
    OnScroll,
    OnMove,
}
