/// <summary>
/// 管理器接口模板
/// </summary>

namespace CHotfix
{
    public interface IMapMgr : IModule
    {
        void OpenLevel(int levelId);
        void OpenChapter(int chapterId);
        IChapter GetChapter(int chapterId);
        ILevel GetLevel(int levelId);
        void EnterNextLevel();
        int GetChapterIdByLevelId(int levelId);
        void RefreshLevel(SLevelData data);
        ILevel GetCurLevel();
        int GetMaxLevelId();
        bool IsPassAll();
        void SetPassAll(bool isPassAll);
    }

}

