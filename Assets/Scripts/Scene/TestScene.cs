using UnityEngine;

public class TestScene : MonoBehaviour
{
    void Start()
    {
        CHUIManager.Instance.ShowUI(CommonEnum.EUI.UIAlarm, new UIAlarmArg
        {
            alarmText = $"{CHJsonManager.Instance.GetTitleStringInfo(SystemLanguage.English, 1)}\n{CHJsonManager.Instance.GetDescriptionStringInfo(SystemLanguage.English, 1)}" 
        });
    }
}
