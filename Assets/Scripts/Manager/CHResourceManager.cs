using Mono.Cecil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;
using UnityEngine.U2D;

public class CHResourceManager : SingletoneStatic<CHResourceManager>
{
    private bool _initialize = false;
    private List<AsyncOperationHandle> _liResouceHandle = new List<AsyncOperationHandle>();
    private Dictionary<string, IResourceLocation> _dicAssetInfo = new Dictionary<string, IResourceLocation>();

    public async Task<bool> Init()
    {
        if (_initialize)
            return false;

        _initialize = true;

        TaskCompletionSource<bool> initComplete = new TaskCompletionSource<bool>();

        Addressables.InitializeAsync().Completed += (handle) =>
        {
            if (handle.Status != AsyncOperationStatus.Succeeded)
            {
                initComplete.TrySetResult(false);
            }
            else
            {
                initComplete.TrySetResult(true);
            }

            Addressables.Release(handle);
        };

        await initComplete.Task;

        return await SaveLocationInfo();
    }

    public void Clear()
    {
        _initialize = false;

        foreach (var handle in _liResouceHandle)
        {
            Addressables.Release(handle);
        }
    }

    async Task<bool> SaveLocationInfo()
    {
        foreach (CommonEnum.EAddressableKey resource in Enum.GetValues(typeof(CommonEnum.EAddressableKey)))
        {
            TaskCompletionSource<bool> saveComplete = new TaskCompletionSource<bool>();

            Addressables.LoadResourceLocationsAsync($"{resource}").Completed += (handle) =>
            {
                if (handle.Status != AsyncOperationStatus.Succeeded)
                {
                    saveComplete.TrySetResult(false);
                }
                else
                {
                    foreach (var pathInfo in handle.Result)
                    {
                        Debug.Log(pathInfo);

                        string key = pathInfo.ToString().Split('/').Last().Split('.').First();
                        if (_dicAssetInfo.ContainsKey(key) == false)
                        {
                            _dicAssetInfo.Add(key, pathInfo);
                        }
                    }

                    saveComplete.TrySetResult(true);
                }

                Addressables.Release(handle);
            };

            await saveComplete.Task;
        }

        return true;
    }

    public void LoadScene(CommonEnum.EScene sceneType, LoadSceneMode sceneMode, Action<Scene> callback = null)
    {
        if (_dicAssetInfo.TryGetValue(sceneType.ToString(), out var pathInfo) == false)
            return;
        AsyncOperationHandle<SceneInstance> handle = Addressables.LoadSceneAsync(pathInfo, sceneMode);
        _liResouceHandle.Add(handle);

        handle.Completed += handle =>
        {
            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                callback?.Invoke(handle.Result.Scene);
            }
            else
            {
                Addressables.UnloadSceneAsync(handle);
            }
        };
    }

    void LoadAsset<T>(string assetName, Action<T> callback = null) where T : UnityEngine.Object
    {
        if (_dicAssetInfo.TryGetValue(assetName, out var pathInfo) == false)
            return;
        AsyncOperationHandle<T> handle = Addressables.LoadAssetAsync<T>(pathInfo);
        _liResouceHandle.Add(handle);

        handle.Completed += (handle) =>
        {
            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                callback?.Invoke(handle.Result);
            }
            else
            {
                Addressables.Release(handle);
            }
        };
    }

    public void LoadGameObject(string assetName, Action<GameObject> callback = null)
    {
        LoadAsset<GameObject>(assetName, (resource) =>
        {
            if (resource == null)
                return;

            callback?.Invoke(GameObject.Instantiate(resource));
        });
    }

    public void LoadUI(CommonEnum.EUI resourceType, Action<GameObject> callback = null)
    {
        LoadGameObject(resourceType.ToString(), callback);
    }

    public void LoadAudio(CommonEnum.EAudio resourceType, Action<AudioClip> callback = null)
    {
        LoadAsset<AudioClip>(resourceType.ToString(), (resource) =>
        {
            if (resource == null)
                return;

            callback?.Invoke(resource);
        });
    }

    public void LoadJson(CommonEnum.EJson resourceType, Action<TextAsset> callback = null)
    {
        LoadAsset<TextAsset>(resourceType.ToString(), (resource) =>
        {
            if (resource == null)
                return;

            callback?.Invoke(resource);
        });
    }

    public void LoadFont(CommonEnum.EFont resourceType, Action<TMP_FontAsset> callback = null)
    {
        LoadAsset<TMP_FontAsset>(resourceType.ToString(), (resource) =>
        {
            if (resource == null)
                return;

            callback?.Invoke(resource);
        });
    }

    public void LoadFontMatrial(CommonEnum.EFont resourceType, Action<Material> callback = null)
    {
        LoadAsset<Material>(resourceType.ToString() + "Material", (resource) =>
        {
            if (resource == null)
                return;

            callback?.Invoke(resource);
        });
    }

    public void LoadAtlas(CommonEnum.EAtlas fontType, Action<SpriteAtlas> callback = null)
    {
        LoadAsset<SpriteAtlas>(fontType.ToString(), (resource) =>
        {
            if (resource == null)
                return;

            callback?.Invoke(resource);
        });
    }
}
