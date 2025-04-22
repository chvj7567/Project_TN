using UnityEngine;

public class TestScene : BaseScene
{
    void Start()
    {
        UIManager.Instance.ShowUI(CommonEnum.EUI.UIAlarm, new UIAlarmArg { alarmText = JsonManager.Instance.GetStringData(1) });
    }
}
