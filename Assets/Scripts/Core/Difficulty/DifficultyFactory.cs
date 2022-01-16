using System;

public class DifficultyFactory
{
    public Difficulty GetDifficulty(DifficultyEnum difficultyEnum)
    {
        switch (difficultyEnum)
        {
            case DifficultyEnum.Easy:
                return new Difficulty(10, 4);
            case DifficultyEnum.Normal:
                return new Difficulty(15, 3);
            case DifficultyEnum.Hard:
                return new Difficulty(17, 2);
            default:
                throw new ArgumentOutOfRangeException(nameof(difficultyEnum), difficultyEnum, null);
        }
    }
}