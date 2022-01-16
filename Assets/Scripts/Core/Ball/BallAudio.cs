using UnityEngine;

public class BallAudio : MonoBehaviour
{
    [SerializeField] private Ball _ball;
    [SerializeField] private AudioSource _hitPlatform;
    [SerializeField] private AudioSource _hitRacket;

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
        else if (go.TryGetComponent(out Boundary boundary))
        {
            PlayHitRacket();
        } 
    }

    private void PlayHitRacket()
    {
        _hitRacket.Play();
    }

    private void PlayHitPlatform()
    {
        _hitPlatform.Play();
    }

    private void OnDisable()
    {
        _ball.Hitted -= OnHitted;
    }
}