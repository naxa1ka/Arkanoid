using System;
using UnityEngine;

[RequireComponent(typeof(BallMovement))]
[RequireComponent(typeof(BallAudio))]
public class Ball : MonoBehaviour
{
    private BallMovement _ballMovement;
    private GameObject _fakeParent;
    
    public event Action<Collision> Hitted;
    public event Action Died;

    public void ResetState(Vector3 position, Transform parent)
    {
        TryInitFakeParent(parent);

        transform.parent = _fakeParent.transform;
        transform.position = position;

        _ballMovement.ResetSpeed();
    }

    public void RunBall()
    {
        transform.parent = null;
        _ballMovement.RunBall();
    }

    private void Awake()
    {
        _ballMovement = GetComponent<BallMovement>();
    }

    private void TryInitFakeParent(Transform parent)
    {
        //to avoid resizing
        if (_fakeParent != null) return;

        _fakeParent = new GameObject();
        _fakeParent.transform.parent = parent;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out DieZone dieZone))
        {
            Died?.Invoke();
        }

        if (collision.gameObject.TryGetComponent(out Platform platform))
        {
            platform.DestroyThis();
        }
        
        Hitted?.Invoke(collision);
    }

    public void SetSpeed(int difficultySpeed)
    {
        _ballMovement.SetSpeed(difficultySpeed);
    }
}