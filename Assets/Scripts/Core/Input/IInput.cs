
    using System;

    public interface IInput
    {
        public event Action StartButtonClicked;
        public float HorizontalMovement { get; }
    }
