using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    async void Start()
    {
        await CHResourceManager.Instance.Init();
        await CHJsonManager.Instance.Init();
        CHUIManager.Instance.Init();
        CHSceneManager.Instance.Init();

        CHSceneManager.Instance.ChangeScene(CommonEnum.EScene.TestScene);
    }
}
