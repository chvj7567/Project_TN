using UnityEngine;

public class TestScene : BaseScene
{
    void Start()
    {
        CHUIManager.Instance.ShowUI(CommonEnum.EUI.UIAlarm, new UIAlarmArg { alarmText = CHJsonManager.Instance.GetStringData(1) });
    }
}
