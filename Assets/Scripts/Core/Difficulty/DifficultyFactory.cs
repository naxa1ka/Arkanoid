using System;

public class DifficultyFactory
{
    public Difficulty GetDifficulty(DifficultyEnum difficultyEnum)
    {
        switch (difficultyEnum)
        {
            case DifficultyEnum.Easy:
                return new Difficulty(500, 10);
            case DifficultyEnum.Normal:
                return new Difficulty(500, 10);
            case DifficultyEnum.Hard:
                return new Difficulty(500, 10);
            default:
                throw new ArgumentOutOfRangeException(nameof(difficultyEnum), difficultyEnum, null);
        }
    }
}