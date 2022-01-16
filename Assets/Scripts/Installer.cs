using UnityEngine;
using Zenject;

public class Installer : MonoInstaller
{
    [InjectOptional] private int _score;
    [InjectOptional] private DifficultyEnum _difficulty = DifficultyEnum.Easy;

    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<DesktopInput>().AsSingle();
        Container.BindInstance(new ScoreHandler(_score)).AsSingle();
        Container.Bind<SceneChanger>().AsSingle();
        Debug.Log(_difficulty);
    }
}