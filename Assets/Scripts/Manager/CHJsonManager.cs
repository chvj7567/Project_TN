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
        public Table_Item_BaseInfo[] arrItemBaseInfo;
        public Table_Item_AbilityInfo[] arrItemAbilityInfo;
        public Table_ContantValueInfo[] arrConstantValueInfo;
        public Table_Mission_BaseInfo[] arrMissionBaseInfo;
    }

    private bool _initialize = false;
    private int _loadCompleteFileCount = 0;
    private int _loadingFileCount = 0;
    private List<Action<TextAsset>> _liJsonInfo = new List<Action<TextAsset>>();

    private Dictionary<(SystemLanguage, int), Table_StringInfo> _dicStringInfo = new Dictionary<(SystemLanguage, int), Table_StringInfo>();
    private Dictionary<int, Table_Item_BaseInfo> _dicItemBaseInfo = new Dictionary<int, Table_Item_BaseInfo>();
    private Dictionary<EItemAbililty, Table_Item_AbilityInfo> _dicItemAbilityInfo = new Dictionary<EItemAbililty, Table_Item_AbilityInfo>();
    private Dictionary<EConstantValue, Table_ContantValueInfo> _dicConstantValueInfo = new Dictionary<EConstantValue, Table_ContantValueInfo>();
    private Dictionary<int, Table_Mission_BaseInfo> _dicMissionBaseInfo = new Dictionary<int, Table_Mission_BaseInfo>();

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
        _dicStringInfo.Clear();
    }

    private async Task LoadJsonInfo()
    {
        Debug.Log("Start Load Json Info");

        _loadCompleteFileCount = 0;
        _liJsonInfo.Clear();

        await LoadStringInfo();
        await LoadItemBaseInfo();
        await LoadItemAbilityInfo();
        await LoadConstantValueInfo();
        await LoadMissionBaseInfo();

        _loadingFileCount = _loadCompleteFileCount;

        Debug.Log("End Load Json Info");
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
        _dicStringInfo.Clear();

        CHResourceManager.Instance.LoadJson(EJson.String, callback = (TextAsset textAsset) =>
        {
            JsonInfo jsonInfo = JsonUtility.FromJson<JsonInfo>(textAsset.text);
            foreach (var info in jsonInfo.arrStringInfo)
            {
                _dicStringInfo.Add((info.languageType, info.stringID), info);
            }

            taskCompletionSource.SetResult(textAsset);
            ++_loadCompleteFileCount;
        });

        Debug.Log("LoadStringInfo");

        return await taskCompletionSource.Task;
    }

    private async Task<TextAsset> LoadItemBaseInfo()
    {
        TaskCompletionSource<TextAsset> taskCompletionSource = new TaskCompletionSource<TextAsset>();

        Action<TextAsset> callback;
        _dicItemBaseInfo.Clear();

        CHResourceManager.Instance.LoadJson(EJson.ItemBase, callback = (TextAsset textAsset) =>
        {
            JsonInfo jsonInfo = JsonUtility.FromJson<JsonInfo>(textAsset.text);
            foreach (var info in jsonInfo.arrItemBaseInfo)
            {
                _dicItemBaseInfo.Add(info.itemID, info);
            }

            taskCompletionSource.SetResult(textAsset);
            ++_loadCompleteFileCount;
        });

        Debug.Log("LoadItemBaseInfo");

        return await taskCompletionSource.Task;
    }

    private async Task<TextAsset> LoadItemAbilityInfo()
    {
        TaskCompletionSource<TextAsset> taskCompletionSource = new TaskCompletionSource<TextAsset>();

        Action<TextAsset> callback;
        _dicItemAbilityInfo.Clear();

        CHResourceManager.Instance.LoadJson(EJson.ItemAbility, callback = (TextAsset textAsset) =>
        {
            JsonInfo jsonInfo = JsonUtility.FromJson<JsonInfo>(textAsset.text);
            foreach (var info in jsonInfo.arrItemAbilityInfo)
            {
                _dicItemAbilityInfo.Add(info.abilityType, info);
            }

            taskCompletionSource.SetResult(textAsset);
            ++_loadCompleteFileCount;
        });

        Debug.Log("LoadItemAbilityInfo");

        return await taskCompletionSource.Task;
    }

    private async Task<TextAsset> LoadConstantValueInfo()
    {
        TaskCompletionSource<TextAsset> taskCompletionSource = new TaskCompletionSource<TextAsset>();

        Action<TextAsset> callback;
        _dicConstantValueInfo.Clear();

        CHResourceManager.Instance.LoadJson(EJson.ConstantValue, callback = (TextAsset textAsset) =>
        {
            JsonInfo jsonInfo = JsonUtility.FromJson<JsonInfo>(textAsset.text);
            foreach (var info in jsonInfo.arrConstantValueInfo)
            {
                _dicConstantValueInfo.Add(info.constantType, info);
            }

            taskCompletionSource.SetResult(textAsset);
            ++_loadCompleteFileCount;
        });

        Debug.Log("LoadConstantValueInfo");

        return await taskCompletionSource.Task;
    }

    private async Task<TextAsset> LoadMissionBaseInfo()
    {
        TaskCompletionSource<TextAsset> taskCompletionSource = new TaskCompletionSource<TextAsset>();

        Action<TextAsset> callback;
        _dicMissionBaseInfo.Clear();

        CHResourceManager.Instance.LoadJson(EJson.MissionBase, callback = (TextAsset textAsset) =>
        {
            JsonInfo jsonInfo = JsonUtility.FromJson<JsonInfo>(textAsset.text);
            foreach (var info in jsonInfo.arrMissionBaseInfo)
            {
                _dicMissionBaseInfo.Add(info.missionID, info);
            }

            taskCompletionSource.SetResult(textAsset);
            ++_loadCompleteFileCount;
        });

        Debug.Log("LoadMissionBaseInfo");

        return await taskCompletionSource.Task;
    }
}

public partial class CHJsonManager
{
    public string GetTitleStringInfo(SystemLanguage languageType, int stringID)
    {
        if (_dicStringInfo.TryGetValue((languageType, stringID), out Table_StringInfo info) == false)
            return string.Empty;

        return info.title;
    }

    public string GetDescriptionStringInfo(SystemLanguage languageType, int stringID)
    {
        if (_dicStringInfo.TryGetValue((languageType, stringID), out Table_StringInfo info) == false)
            return string.Empty;

        return info.description;
    }
}