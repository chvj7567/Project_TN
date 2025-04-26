using UnityEngine;
using TMPro;
using System.Text;

[RequireComponent(typeof(TMP_Text))]
public class TextEx : MonoBehaviour
{
    [SerializeField] private int _stringID = -1;

    private TMP_Text _text;
    private object[] _arrArg;
    private bool _initialize;

    private void Init()
    {
        if (_initialize)
            return;

        _initialize = true;

        _text = GetComponent<TMP_Text>();

        if (_stringID != -1)
        {
            //_text.text = JsonManager.Instance.GetStringData(_stringID);
            //_text.font = GameManagement.Instance.FontAsset;
            //_text.material = GameManagement.Instance.FontMatarial;
        }
    }

    public void SetText(params object[] arrArg)
    {
        Init();

        _arrArg = arrArg;

        if (_stringID == -1)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var arg in arrArg)
            {
                sb.Append(arg.ToString());
            }

            _text.text = sb.ToString();
        }
        else
        {
            //_text.text = string.Format(JsonManager.Instance.GetStringData(_stringID), arrArg);
        }
    }

    public void SetColor(Color color)
    {
        Init();

        _text.color = color;
    }

    public void SetStringID(int stringID)
    {
        Init();

        this._arrArg = null;
        this._stringID = stringID;
        //_text.text = JsonManager.Instance.GetStringData(_stringID);
    }

    public void SetPlusString(string plusString)
    {
        Init();

        if (string.IsNullOrEmpty(plusString) == false)
        {
            _text.text = _text.text + " + " + plusString;
        }
    }

    public string GetString()
    {
        Init();

        return _text.text;
    }
}
