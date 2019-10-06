using System;

[Serializable]
public class LevelsData
{
    public LevelData[] levels;

    [Serializable]
    public class LevelData
    {
        public int number;
        public int[] path;
    }
}