using System;
using UnityEngine;

namespace CModel
{
    /// <summary>
    /// 游戏入口
    /// </summary>
    public class GamePub : MonoBehaviour, IGamePub
    {
        private GameObject mGamePubGo;
        private ModuleMgr mModuleMgr = new ModuleMgr();
        private IHotfixMgr mHotfixMgr;

        //游戏总入口
        void Start()
        {
            mGamePubGo = this.gameObject;
            DontDestroyOnLoad(mGamePubGo);
            //初始化主工程所有管理器
            mModuleMgr.Init();
            mHotfixMgr =  GetModule<IHotfixMgr>();
            //加载hotfix dll
            mHotfixMgr.LoadDll();
            //运行hotfix dll
            mHotfixMgr.RunDll();
        }
        
        
        private void OnApplicationFocus(bool focus)
        {
            foreach (var module in mModuleMgr.GetConfigs())
            {
                module.Value.OnApplicationFocus(focus);
            }
            HOnApplicationFocus?.Invoke(focus);
        }

        void Update()
        {
            foreach (var module in mModuleMgr.GetConfigs())
            {
                module.Value.Update();
            }
            HUpdate?.Invoke();
        }


        private static IGamePub msIntance = null;

        /// <summary>
        /// 主工程接口
        /// </summary>
        /// <returns></returns>
        public static IGamePub GetInstance()
        {
            if (msIntance == null)
            {
                Type type = typeof(GamePub);
                GamePub gamepub = (GamePub) FindObjectOfType(type);

                if (gamepub == null)
                {
                    Debug.Assert(false);
                    return null;
                }

                msIntance = gamepub;
            }
            return msIntance;
        }
        
        public T GetModule<T>() where T : IModule
        {
            return mModuleMgr.GetController<T>();
        }

       public  Action HUpdate { set; private get; }
       public  Action<bool> HOnApplicationFocus{ set; private get; }
    }
}
