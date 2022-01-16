using System;
using UnityEngine;
using Zenject;

public class DesktopInput : ITickable, IInput
{
    public event Action StartButtonClicked;
    public float HorizontalMovement => Input.GetAxis("Horizontal");
    
    public void Tick()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartButtonClicked?.Invoke();
        }
    }
}