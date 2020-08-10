using CModel;

namespace CHotfix
{
    public class BogoChapter: IChapter
    {
        public int ConfigId { get; }
      
        public ChapterConfig ChapterConfig { get; set; }
        public SChapterData ChapterData { get; set; }
        public bool IsLocked { get; set; }
        
        private HGamePub mGamePub;
        private IMapMgr mMapMgr;

        public BogoChapter(ChapterConfig config, SChapterData data)
        {

          //  mGamePub = GamePub.GetHInstance();
            mMapMgr =  mGamePub.GetModule<IMapMgr>();
            
            ChapterConfig = config;
            ConfigId = (int) config.id;
            ChapterData = data;
            IsLocked = ChapterData == null;
        }

        public void Enter()
        {
            IsLocked = false;
        }

        public void Complete()
        {
            if (IsLast())
            {
                if (!mMapMgr.IsPassAll())
                {
                    mMapMgr.SetPassAll(true);
                    //通关弹窗
                }
            }
            else
            {
               mMapMgr.OpenChapter(ChapterConfig.id+1);
            }
        }

        private bool IsLast()
        {
            return this.ChapterConfig.IsLast == 1;
        }


      

       
    }
}