using UnityEngine;

public class Test : MonoBehaviour
{
    async void Start()
    {
        await ResourceManager.Instance.Init();
        UIManager.Instance.Init();
        UIManager.Instance.ShowUI(CommonEnum.EUI.UIAlarm, new UIAlarmArg { alarmText = "Test" });
    }
}
