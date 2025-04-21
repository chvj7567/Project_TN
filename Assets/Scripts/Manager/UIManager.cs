using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager : SingletoneMonoBehaviour<UIManager>
{
    private const string MyCanvasName = "UICanvas";
    private bool _initialize = false;
    private Transform _rootTransform;
    private ReactiveDictionary<CommonEnum.EUI, UIBase> _dicCurrentUI = new ReactiveDictionary<CommonEnum.EUI, UIBase>();
    private ReactiveCollection<CommonEnum.EUI> _liWaitCloseUI = new ReactiveCollection<CommonEnum.EUI>();
    private Dictionary<CommonEnum.EUI, UIBase> _dicCashingUI = new Dictionary<CommonEnum.EUI, UIBase>();

    public bool CheckUI => _dicCurrentUI.Count > 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_dicCurrentUI.Count > 0)
                CloseUI(_dicCurrentUI.Last().Value);
        }
    }

    public void Init()
    {
        if (_initialize)
            return;

        _initialize = true;

        if (_rootTransform == null)
        {
            var uiCanvas = GameObject.FindGameObjectWithTag(MyCanvasName);
            if (uiCanvas == null)
            {
                Debug.LogError("UICanvas�� �������ּ���. (Tag : UICanvas)");
                return;
            }

            _rootTransform = uiCanvas.transform;
            DontDestroyOnLoad(_rootTransform);
        }

        _dicCurrentUI.OnAdd += addUI =>
        {
            var curUI = _liWaitCloseUI.Find(_ => _ == addUI.Value.UIType);
            if (curUI == CommonEnum.EUI.None)
                return;

            //# ���� UI ��⿭�� �߰��Ǿ����� �ݱ� UI ��Ͽ� ������ �ݱ�
            addUI.Value.gameObject.SetActive(false);

            //# �ݾ����� ����
            _dicCurrentUI.Remove(addUI.Value.UIType);
            _liWaitCloseUI.Remove(addUI.Value.UIType);
        };

        _liWaitCloseUI.OnAdd += addUI =>
        {
            //# �ݱ� UI ��⿭�� �߰��Ǿ����� ���� UI ��Ͽ� ������ �ݱ�
            var curUI = _dicCurrentUI.Find(_ => _.Key == addUI);
            if (curUI.Value == null)
                return;

            curUI.Value.gameObject.SetActive(false);

            //# �ݾ����� ����
            _liWaitCloseUI.Remove(addUI);
            _dicCurrentUI.Remove(addUI);
        };
    }

    public void ShowUI(CommonEnum.EUI uiType, UIArg arg = null, Action<UIBase> callback = null)
    {
        if (arg == null)
            arg = new UIArg();

        //# �ش� UI�� �� ���̶� ���� ���� �ִٸ� ĳ���ϰ� �ִ� UI ����
        if (_dicCashingUI.TryGetValue(uiType, out var uiBase))
        {
            uiBase.Init(uiType);
            uiBase.InitUI(arg);
            uiBase.gameObject.SetActive(true);

            uiBase.transform.SetAsLastSibling();

            _dicCurrentUI.Add(uiType, uiBase);

            callback?.Invoke(uiBase);
        }
        else
        {
            ResourceManager.Instance.LoadUI(uiType, (ui) =>
            {
                ui.transform.SetParent(_rootTransform);
                var rectTransform = ui.GetComponent<RectTransform>();
                //# Stretch ����
                rectTransform.anchorMin = new Vector2(0, 0);
                rectTransform.anchorMax = new Vector2(1, 1);

                //# Offset ���� 0���� ����
                rectTransform.offsetMin = Vector2.zero;
                rectTransform.offsetMax = Vector2.zero;

                //# ��ġ �� �� ������ ����
                rectTransform.anchoredPosition3D = Vector3.zero;
                rectTransform.localScale = Vector3.one;

                UIBase uiBase = ui.GetComponent<UIBase>();
                if (uiBase == null)
                    return;

                uiBase.Init(uiType);
                uiBase.InitUI(arg);
                _dicCurrentUI.Add(uiType, uiBase);
                _dicCashingUI.Add(uiType, uiBase);

                callback?.Invoke(uiBase);
            });
        }
    }

    public void CloseUI(UIBase uiBase, bool reuse = false)
    {
        if (uiBase == null)
            return;

        if (reuse == false)
        {
            RemoveCashingUI(uiBase.UIType);
        }

        _liWaitCloseUI.Add(uiBase.UIType);
    }

    public void CloseUI(CommonEnum.EUI uiType, bool reuse = false)
    {
        if (reuse == false)
        {
            RemoveCashingUI(uiType);
        }

        _liWaitCloseUI.Add(uiType);
    }

    private void RemoveCashingUI(CommonEnum.EUI uiType)
    {
        if (_dicCashingUI.TryGetValue(uiType, out var uiBase))
        {
            _dicCashingUI.Remove(uiBase.UIType);
            Destroy(uiBase.gameObject);
        }
    }
}
