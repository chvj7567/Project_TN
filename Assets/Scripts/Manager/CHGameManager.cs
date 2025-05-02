using System;
using System.Collections.Generic;
using UnityEngine;

public class CHGameManager : SingletoneMonoBehaviour<CHGameManager>
{
    private async void Start()
    {
        await CHResourceManager.Instance.Init();
        await CHJsonManager.Instance.Init();
        CHUIManager.Instance.Init();
        CHSceneManager.Instance.Init();

        OnQuit += () =>
        {
            CHResourceManager.Instance.Clear();
            CHJsonManager.Instance.Clear();
            CHUIManager.Instance.Clear();
            CHSceneManager.Instance.Clear();
        };
    }
}
