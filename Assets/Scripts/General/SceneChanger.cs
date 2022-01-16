using UnityEngine.SceneManagement;
using Zenject;

public class SceneChanger
{
    private const int MenuBuildIndex = 0;
    private const int GameBuildIndex = 1;

    private readonly ZenjectSceneLoader _zenjectLoaderScene;
    private readonly ScoreHandler _scoreHandler;

    private DifficultyEnum _difficulty;

    [Inject]
    public SceneChanger(ZenjectSceneLoader zenjectSceneLoader, ScoreHandler scoreHandler)
    {
        _scoreHandler = scoreHandler;
        _zenjectLoaderScene = zenjectSceneLoader;
    }

    public void SetDifficulty(DifficultyEnum difficulty)
    {
        _difficulty = difficulty;
    }

    public void LoadMenu()
    {
        LoadScene(MenuBuildIndex);
    }

    public void LoadGame()
    {
        TimeState.Resume();

        _zenjectLoaderScene.LoadScene(
            GameBuildIndex,
            LoadSceneMode.Single,
            container =>
            {
                container.BindInstance(_difficulty).WhenInjectedInto<Installer>();
            }
        );
    }

    public void ReloadWithProgress()
    {
        TimeState.Resume();

        _zenjectLoaderScene.LoadScene(
            GameBuildIndex,
            LoadSceneMode.Single,
            container =>
            {
                container.BindInstance(_scoreHandler.Score).WhenInjectedInto<Installer>();
                container.BindInstance(_difficulty).WhenInjectedInto<Installer>();
            }
        );
    }

    private void LoadScene(int sceneIndex)
    {
        TimeState.Resume();
        SceneManager.LoadScene(sceneIndex);
    }
}