using System;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public event Action Died;
    
    public void DestroyThis()
    {
        Died?.Invoke();
        Destroy(gameObject);
    }
}