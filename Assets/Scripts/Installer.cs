using Zenject;

public class Installer : MonoInstaller
{
    [InjectOptional] private int _score;

    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<DesktopInput>().AsSingle();
        Container.BindInstance(new ScoreHandler(_score)).AsSingle();
        Container.Bind<SceneChanger>().AsSingle();
    }
}