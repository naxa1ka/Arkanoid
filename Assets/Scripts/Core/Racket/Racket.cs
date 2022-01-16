using UnityEngine;
using Zenject;

public class Racket : MonoBehaviour
{
    [SerializeField] private Ball _ball;
    [SerializeField] private Transform _initialPosition;
    
    private IInput _input;

    public void Revive()
    {
        ResetBall();
    }
    
    [Inject]
    private void Constructor(IInput input)
    {
        _input = input;
    }
    
    private void OnEnable()
    {
        _input.StartButtonClicked += StartButtonClicked;
        _ball.Died += OnDied;
    }

    private void Start()
    {
        ResetBall();
    }

    private void OnDied()
    {
        ResetBall();
    }

    private void ResetBall()
    {
        _ball.ResetState(_initialPosition.position, transform);
        _input.StartButtonClicked += StartButtonClicked;
    }
    
    private void StartButtonClicked()
    {
        _ball.RunBall();
        _input.StartButtonClicked -= StartButtonClicked;
    }

    private void OnDisable()
    {
        _input.StartButtonClicked -= StartButtonClicked;
        _ball.Died -= OnDied;
    }

    public void SetLength(int difficultyLengthRacket)
    {
        var localScale = transform.localScale;
        localScale.y = difficultyLengthRacket;
        
        transform.localScale = localScale;
    }
}