using System;

public class ScoreHandler
{
    private int _score;

    public event Action<int> ScoreChanged;
    public int Score => _score;

    public ScoreHandler(int initScore = 0)
    {
        _score = initScore;
    }
    
    public void AddPoint()
    {
        _score++;
        ScoreChanged?.Invoke(_score);
    }
}