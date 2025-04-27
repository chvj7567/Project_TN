using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using UnityEngine;
using static CommonEnum;

[Serializable]
public class Table_StringInfo
{
    //# Key
    public SystemLanguage languageType;
    public int stringID;

    public string title;
    public string description;
}

[Serializable]
public class Table_Item_BaseInfo
{
    //# Key
    public int itemID;

    public int stringID;
    public int abilityType;
    public string iconImage;
}

[Serializable]
public class Table_Item_AbilityInfo
{
    //# Key
    public EItemAbililty abilityType;

    public float value;
}

[Serializable]
public class Table_ContantValueInfo
{
    //# Key
    public EConstantValue constantType;

    public float value;
}

[Serializable]
public class Table_Mission_BaseInfo
{
    //# Key
    public int missionID;

    public EMissionType missionType;
    public float value;
}

public partial class CHJsonManager : SingletoneStatic<CHJsonManager>
{
    [Serializable]
    private class JsonInfo
    {
        public Table_StringInfo[] arrStringInfo;
    }

    private bool _initialize = false;
    private int _loadCompleteFileCount = 0;
    private int _loadingFileCount = 0;
    private List<Action<TextAsset>> _liJsonInfo = new List<Action<TextAsset>>();
    private List<Table_StringInfo> _liStringInfo = new List<Table_StringInfo>();

    public async Task Init()
    {
        if (_initialize)
            return;

        _initialize = true;

        await LoadJsonInfo();
    }

    public void Clear()
    {
        _initialize = false;

        _liJsonInfo.Clear();
        _liStringInfo.Clear();
    }

    private async Task LoadJsonInfo()
    {
        Debug.Log("Load Json Info");
        _loadCompleteFileCount = 0;
        _liJsonInfo.Clear();

        await LoadStringInfo();

        _loadingFileCount = _loadCompleteFileCount;
    }

    public float GetJsonLoadingPercent()
    {
        if (_loadingFileCount == 0 || _loadCompleteFileCount == 0)
        {
            return -1;
        }

        return ((float)_loadCompleteFileCount) / _loadingFileCount * 100f;
    }

    private async Task<TextAsset> LoadStringInfo()
    {
        TaskCompletionSource<TextAsset> taskCompletionSource = new TaskCompletionSource<TextAsset>();

        Action<TextAsset> callback;
        _liStringInfo.Clear();

        CHResourceManager.Instance.LoadJson(EJson.String, callback = (TextAsset textAsset) =>
        {
            JsonInfo jsonInfo = JsonUtility.FromJson<JsonInfo>(textAsset.text);
            foreach (var info in jsonInfo.arrStringInfo)
            {
                _liStringInfo.Add(info);
            }

            taskCompletionSource.SetResult(textAsset);
            ++_loadCompleteFileCount;
        });

        return await taskCompletionSource.Task;
    }
}

public partial class CHJsonManager
{
    public string GetTitleStringInfo(int stringID, SystemLanguage languageType = SystemLanguage.English)
    {
        var findInfo = _liStringInfo.Find(_ => _.languageType == languageType && _.stringID == stringID);
        if (findInfo == null)
            return string.Empty;

        return findInfo.title;
    }

    public string GetDescriptionStringInfo(int stringID, SystemLanguage languageType = SystemLanguage.English)
    {
        var findInfo = _liStringInfo.Find(_ => _.languageType == languageType && _.stringID == stringID);
        if (findInfo == null)
            return string.Empty;

        return findInfo.description;
    }
}