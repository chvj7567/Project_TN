using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class UIAlarmArg : UIArg
{
    public string alarmText;
}

public class UIAlarm : UIBase
{
    UIAlarmArg _arg;

    [SerializeField] TextEx _alarmText;

    public override void InitUI(UIArg arg)
    {
        _arg = arg as UIAlarmArg;

        _alarmText.SetText(_arg.alarmText);
    }
}
