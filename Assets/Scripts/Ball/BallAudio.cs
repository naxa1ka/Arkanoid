using UnityEngine;

public class BallAudio : MonoBehaviour
{
    [SerializeField] private Ball _ball;

    private void OnEnable()
    {
        _ball.Hitted += OnHitted;
    }

    private void OnHitted(Collision collision)
    {
        var go = collision.gameObject;

        if (go.TryGetComponent(out Platform platform))
        {
            PlayHitPlatform();
        }
        else if (go.TryGetComponent(out Racket racket))
        {
            PlayHitRacket();
        }
    }

    private void PlayHitRacket()
    {
    }

    private void PlayHitPlatform()
    {
    }

    private void OnDisable()
    {
        _ball.Hitted -= OnHitted;
    }
}