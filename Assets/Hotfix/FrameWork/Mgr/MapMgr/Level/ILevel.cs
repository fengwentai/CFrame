

using System;

namespace CHotfix
{
    /// <summary>
    /// chapter--level--round 
    /// </summary>
    public interface ILevel : ILogic
    {
        SLevelData LevelData { set; get; }
        LevelConfig LevelConfig { set; get; }
        LevelJsonConfig LevelJsonConfig{ set; get; }
        IChapter CurChapter{ set; get; }
        bool IsLast();
    }
}


