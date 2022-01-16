using UnityEngine;

public class Reviver : MonoBehaviour
{
    [SerializeField] private Racket _racket;
    [SerializeField] private Player _player;

    public void Revive()
    {
        _racket.Revive();
        _player.Revive();
    }
}