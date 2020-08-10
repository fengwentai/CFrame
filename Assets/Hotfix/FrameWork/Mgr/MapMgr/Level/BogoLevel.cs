

using CModel;

namespace CHotfix
{
    public class BogoLevel: ILevel
    {
        public bool IsLocked { get; set; }
        public int ConfigId { get; }

        public SLevelData LevelData { get; set; }
        public LevelConfig LevelConfig { get; set; }
        public LevelJsonConfig LevelJsonConfig { get; set; }
        public IChapter CurChapter { get; set; }
        
        private HGamePub mGamePub;
        private IConfigMgr mConfigMgr;
        private IMapMgr mMapMgr;


        public BogoLevel(LevelConfig config, SLevelData data)
        {
          //  mGamePub = GamePub.GetHInstance();
            mConfigMgr = mGamePub.GetModule<IConfigMgr>();
            mMapMgr =  mGamePub.GetModule<IMapMgr>();
            LevelConfig = config;
            ConfigId = (int) LevelConfig.id;
            LevelData = data;
            //有动态数据 表示锁着的
            IsLocked = this.LevelData == null;
            LevelJsonConfig = mConfigMgr.GetConfig<LevelJsonConfig>(ConfigId);
            CurChapter = mMapMgr.GetChapter(this.LevelConfig.ChapterId);
        }

        public void Complete()
        {
            if (this.LevelConfig.special == 1)
            {
                CurChapter.Complete();
            }
            else
            {
                mMapMgr.OpenLevel(LevelConfig.id + 1);
            }

            //发送通关协议
        }

        public bool IsLast()
        {
            return this.LevelConfig.IsLast == 1;
        }

      
    }
}