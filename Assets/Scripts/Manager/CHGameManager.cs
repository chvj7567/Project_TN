using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class CHGameManager : SingletoneMonoBehaviour<CHGameManager>
{
    public MainUser MainUser { get; private set; }
    public OtherUser OtherUser { get; private set; }

    private void Start()
    {
        InitManager();
    }

    public async void InitManager()
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

    public void SetMainUser(long accountID, string nickname)
    {
        MainUser = new MainUser();
        MainUser.Init(accountID, nickname);
    }

    public void SetOtherUser(long accountID, string nickname)
    {
        OtherUser = new OtherUser();
        OtherUser.Init(accountID, nickname);
    }
}
