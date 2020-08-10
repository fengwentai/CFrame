/// <summary>
/// 关卡管理器
/// </summary>

using System.Collections.Generic;
using CModel;
using UnityEngine;

namespace CHotfix
{
    public class MapMgr : ModuleBase, IMapMgr
    {
        private HGamePub mGamePub;
        private IConfigMgr mConfigMgr;
        private bool mIsPassAll = false;

        private Dictionary<IChapter, List<ILevel>> mChapterLevels = new Dictionary<IChapter, List<ILevel>>();
        private ILevel mCurLevel = null;
        private int mMaxLevelId = 0;

        public override void Init()
        {
            mGamePub = HGamePub.GetInstance();
            mConfigMgr = mGamePub.GetModule<IConfigMgr>();
            //给mChapterLevels 赋值
        }

        public override void Release()
        {
            mChapterLevels.Clear();
        }


        public void OpenLevel(int levelId)
        {
            mCurLevel = GetLevel(levelId);
            CheckMaxLevel();
        }

        
        //set属性 内部自己维护
        private void CheckMaxLevel()
        {
            mMaxLevelId = 1;
        }


        public override void Update()
        {
            Debug.Log("000 Update Test");
        }

        public IChapter GetChapter(int chapterId)
        {
            return null;
        }

        public ILevel GetLevel(int levelId)
        {
            foreach (var item in mChapterLevels)
            {
                foreach (var level in item.Value)
                {
                    if (levelId == level.ConfigId)
                    {
                        return level;
                    }
                }
            }
            Debug.LogError("找不到该levelid的配置");
            return null;
        }

        public void EnterNextLevel()
        {
            int nextLevelId = mCurLevel.ConfigId + 1;
            var level = GetLevel(nextLevelId);
            if (level != null)
            {
                mCurLevel = level;
            }
        }


        public int GetChapterIdByLevelId(int levelId)
        {
            LevelConfig config = mConfigMgr.GetConfig<LevelConfig>(levelId);
            if (config != null)
            {
                return config.ChapterId;
            }

            Debug.LogError("找不到该levelid的配置");
            return -1;
        }

        public void RefreshLevel(SLevelData data)
        {
            //利用现成的函数 
            ILevel level = GetLevel(data.id);
            if (level != null)
            {
                level.LevelData = data;
            }
        }

        //Get函数里 最好不写逻辑
        public ILevel GetCurLevel()
        {
            return mCurLevel;
        }

        //维护一个字段  
        public int GetMaxLevelId()
        {
            return mMaxLevelId;
        }


        public bool IsPassAll()
        {
            return mIsPassAll;
        }

        public void SetPassAll(bool isPassAll)
        {
            mIsPassAll = isPassAll;
        }

        public void OpenChapter(int chapterId)
        {
        }
    }
}