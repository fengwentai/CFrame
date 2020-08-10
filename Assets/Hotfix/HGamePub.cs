using CModel;

namespace CHotfix
{
    /// <summary>
    /// 热更层的入口
    /// </summary>
    public class HGamePub
    {
        private static HModuleMgr mHModuleMgr = new HModuleMgr();
        private static IGamePub mGamePub = null;

        public static void Start()
        {
            mGamePub = GamePub.GetInstance();
            mHModuleMgr.Init();
            //后续游戏启动
            Init();
        }

        /// <summary>
        /// 所有层模块初始化
        /// </summary>
        private static void Init()
        {
            foreach (var module in mHModuleMgr.GetConfigs())
            {
                module.Value.Init();
            }

            InitLifeCycleMethod();
        }

       /// <summary>
       /// 初始化周期函数 
       /// </summary>
        private static void InitLifeCycleMethod()
        {
            mGamePub.HUpdate = Update;
            mGamePub.HOnApplicationFocus = OnApplicationFocus;
        }


        private static void OnApplicationFocus(bool focus)
        {
            foreach (var module in mHModuleMgr.GetConfigs())
            {
                module.Value.OnApplicationFocus(focus);
            }
        }
        private static HGamePub msIntance = null;
        /// <summary>
        /// 热更工程模块入口
        /// </summary>
        /// <returns></returns>
        public static HGamePub GetInstance()
        {
            if (msIntance == null)
            {
                msIntance = new HGamePub();
            }
            return msIntance;
        }

        private static void Update()
        {
            foreach (var module in mHModuleMgr.GetConfigs())
            {
                module.Value.Update();
            }
        }

        public T GetModule<T>() where T : IModule
        {
            return mHModuleMgr.GetController<T>();
        }
    }
}