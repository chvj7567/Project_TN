using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using UnityEngine;

[Serializable]
public class StringData
{
    public int stringID;
    public string korean;
    public string english;
}

public partial class JsonManager : SingletoneStatic<JsonManager>
{
    [Serializable]
    private class JsonData
    {
        public StringData[] arrStringData;
    }

    private int _loadCompleteFileCount = 0;
    private int _loadingFileCount = 0;
    private List<Action<TextAsset>> _liJsonData = new List<Action<TextAsset>>();

    private List<StringData> _liStringData = new List<StringData>();

    public async Task Init()
    {
        await LoadJsonData();
    }

    public void Clear()
    {
        _liJsonData.Clear();
        _liStringData.Clear();
    }

    private async Task LoadJsonData()
    {
        Debug.Log("LoadJsonData");
        _loadCompleteFileCount = 0;
        _liJsonData.Clear();

        await LoadStringData();

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

    private async Task<TextAsset> LoadStringData()
    {
        TaskCompletionSource<TextAsset> taskCompletionSource = new TaskCompletionSource<TextAsset>();

        Action<TextAsset> callback;
        _liStringData.Clear();

        ResourceManager.Instance.LoadJson(CommonEnum.EJson.String, callback = (TextAsset textAsset) =>
        {
            var jsonData = JsonUtility.FromJson<JsonData>(textAsset.text);
            foreach (var data in jsonData.arrStringData)
            {
                _liStringData.Add(data);
            }

            taskCompletionSource.SetResult(textAsset);
            ++_loadCompleteFileCount;
        });

        return await taskCompletionSource.Task;
    }
}

public partial class JsonManager
{
    public string GetStringData(int stringID, SystemLanguage languageType = SystemLanguage.English)
    {
        var findData = _liStringData.Find(_ => _.stringID == stringID);
        if (findData == null)
            return string.Empty;

        if (languageType == SystemLanguage.Korean)
        {
            return findData.korean;
        }
        else
        {
            return findData.english;
        }
    }
}