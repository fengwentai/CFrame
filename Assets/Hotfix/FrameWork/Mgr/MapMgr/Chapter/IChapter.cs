


namespace CHotfix
{
    /// <summary>
    /// chapter--level--round 
    /// </summary>
    public interface IChapter: ILogic
    {
        ChapterConfig ChapterConfig { set; get; }
        SChapterData ChapterData{ set; get; }
    }
}