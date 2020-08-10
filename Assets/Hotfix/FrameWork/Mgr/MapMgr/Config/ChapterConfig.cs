namespace CHotfix
{
    public class ChapterConfig : IConfig
    {
        public int IsLast = 0;
        public int id = 0;
    }

    public class LevelConfig : IConfig
    {
        public int id = 0;
        public int special = 1;
        public int IsLast = 0;
        public int ChapterId = 0;
    }

    public class SLevelData
    {
        public int id;
    }

    public class SChapterData
    {
        
    }

    public class LevelJsonConfig: IConfig
    {
        
    }

    public interface IConfig
    {
    }



}

