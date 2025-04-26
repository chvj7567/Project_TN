using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CHSceneManager : SingletoneStatic<CHSceneManager>
{
    private bool _initialize = false;
    private Queue<CommonEnum.EScene> _qPostScene = new Queue<CommonEnum.EScene>();
    private Queue<CommonEnum.EScene> _qAddedScene = new Queue<CommonEnum.EScene>();

    public CommonEnum.EScene CurrentScene { get; private set; }

    public void Init()
    {
        if (_initialize)
            return;

        _initialize = true;

        CurrentScene = CommonEnum.EScene.StartScene;
    }

    public void Clear()
    {
        _initialize = false;

        _qPostScene.Clear();
        _qAddedScene.Clear();
    }

    public void ChangeScene(CommonEnum.EScene sceneType)
    {
        //# 이전 씬 타입 저장
        _qPostScene.Enqueue(CurrentScene);
        CurrentScene = sceneType;
        CHResourceManager.Instance.LoadScene(sceneType, LoadSceneMode.Single);
    }

    public void AddedScene(CommonEnum.EScene sceneType)
    {
        //# 추가된 씬 타입 저장
        _qAddedScene.Enqueue(sceneType);

        CHResourceManager.Instance.LoadScene(sceneType, LoadSceneMode.Additive);
    }
}