using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using Zenject;

public class SceneChanger
{
    private  ZenjectSceneLoader _zenjectLoaderScene;
    private  ScoreHandler _scoreHandler;

    [Inject]
    private void Constructor(ZenjectSceneLoader zenjectSceneLoader, ScoreHandler scoreHandler)
    {
        _scoreHandler = scoreHandler;
        _zenjectLoaderScene = zenjectSceneLoader;
    }

    public void LoadMenu()
    {
        LoadScene(0);
    }

    public void LoadGame()
    {
        LoadScene(1);
    }

    public void ReloadWithProgress()
    {
        TimeState.Resume();

        _zenjectLoaderScene.LoadScene(
            1,
            LoadSceneMode.Single,
            container =>
            {
                container.BindInstance(_scoreHandler.Score).WhenInjectedInto<Installer>();
            }
        );
    }

    private void LoadScene(int sceneIndex)
    {
        TimeState.Resume();
        SceneManager.LoadScene(sceneIndex);
    }
}