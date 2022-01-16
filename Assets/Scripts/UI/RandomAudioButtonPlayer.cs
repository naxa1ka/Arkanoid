using UnityEngine;

public class RandomAudioButtonPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _audioClip1;
    [SerializeField] private AudioSource _audioClip2;

    public void Play()
    {
        var result = Random.Range(0, 2);

        if (result == 0)
        {
            _audioClip1.Play();
        }
        else
        {
            _audioClip2.Play();
        }
    }
}