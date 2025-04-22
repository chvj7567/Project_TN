using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : BaseScene
{
    async void Start()
    {
        await ResourceManager.Instance.Init();
        await JsonManager.Instance.Init();
        UIManager.Instance.Init();

        ResourceManager.Instance.LoadScene(CommonEnum.EScene.TestScene);
    }
}
