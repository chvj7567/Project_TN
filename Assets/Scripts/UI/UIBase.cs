using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

public class UIArg { }

public abstract class UIBase : MonoBehaviour, IDisposable
{
    [SerializeField] private Button _backgroundButton;
    [SerializeField] private Button _backButton;

    protected UnityAction onCloseBackgroundButton;
    protected UnityAction onCloseBackButton;

    public CommonEnum.EUI UIType { get; private set; }

    public void Init(CommonEnum.EUI uiType)
    {
        UIType = uiType;

        onCloseBackgroundButton = () => Close();
        onCloseBackButton = () => Close();

        if (_backgroundButton)
            _backgroundButton.onClick.AddListener(onCloseBackgroundButton);

        if (_backButton)
            _backButton.onClick.AddListener(onCloseBackButton);
    }

    public abstract void InitUI(UIArg arg);

    public virtual void Close(bool reuse = true)
    {
        Dispose();
        CHUIManager.Instance.CloseUI(this, reuse);
    }

    public void Dispose()
    {
        Dispose(true);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            if (_backgroundButton)
                _backgroundButton.onClick.RemoveListener(onCloseBackgroundButton);

            if (_backButton)
                _backButton.onClick.RemoveListener(onCloseBackButton);
        }
    }
}
