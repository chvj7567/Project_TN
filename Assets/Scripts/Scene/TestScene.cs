using UnityEngine;

public class TestScene : MonoBehaviour
{
    void Start()
    {
        CHUIManager.Instance.ShowUI(CommonEnum.EUI.UIAlarm, new UIAlarmArg
        {
            alarmText = $"{CHJsonManager.Instance.GetTitleStringInfo(1)}\n{CHJsonManager.Instance.GetDescriptionStringInfo(1)}" 
        });
    }
}
