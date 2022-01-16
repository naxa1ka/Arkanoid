using System;
using UnityEngine;
using Zenject;

public class PlatformHandler : MonoBehaviour
{
    private Platform[] _platforms;
    private ScoreHandler _scoreHandler;

    private int _diedPlatforms;
    
    public event Action PlatformsEnded;
    
    [Inject]
    private void Constructor(ScoreHandler scoreHandler)
    {
        _scoreHandler = scoreHandler;
    }

    private void Awake()
    {
        //да FindObjectsOfType зло, но тут вполне решение
        _platforms = FindObjectsOfType<Platform>();
    }

    private void OnEnable()
    {
        foreach (var platform in _platforms)
        {
            platform.Died += Died;
        }
    }

    private void Died()
    {
        _scoreHandler.AddPoint();
        
        _diedPlatforms++;
        if (_diedPlatforms == _platforms.Length)
        {
            PlatformsEnded?.Invoke();
        }
    }

    private void OnDisable()
    {
        foreach (var platform in _platforms)
        {
            platform.Died -= Died;
        }
    }
}