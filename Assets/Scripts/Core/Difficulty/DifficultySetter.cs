using UnityEngine;
using Zenject;

public class DifficultySetter : MonoBehaviour
{
    private Difficulty _difficulty;

    [SerializeField] private Ball _ball;
    [SerializeField] private Racket _racket;

    [Inject]
    private void Constructor(DifficultyEnum difficultyEnum)
    {
        var difficultyFactory = new DifficultyFactory();
        _difficulty = difficultyFactory.GetDifficulty(difficultyEnum);
    }

    private void Start()
    {
        _ball.SetSpeed(_difficulty.Speed);
        _racket.SetLength(_difficulty.LengthRacket);
    }
}