using Zenject;

public class MenuInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<SceneChanger>().AsSingle();
        Container.Bind<ScoreHandler>().AsSingle();
    }
}