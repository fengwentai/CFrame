using System;
using System.Collections.Generic;
using UnityEngine;

namespace CModel
{
    /// <summary>
    /// 管理器的管理器
    /// </summary>
    public class ModuleMgr
    {
        Dictionary<string, IModule> mModuleConfigs = new Dictionary<string, IModule>(); 
        
        public void Init()
        {
            AddController<TestMgr, ITestMgr>();
            AddController<HotfixMgr, IHotfixMgr>();
        }
        public K AddController<T, K>() where T : ModuleBase where K : IModule
        {
            var name = typeof(T).Name;
            var classType = Type.GetType("CModel."+name);
            var interfaceName = typeof(K).Name;
            Debug.LogError("name ="+name);
            var instance = (IModule) Activator.CreateInstance(classType);
            mModuleConfigs.Add(interfaceName, instance);
            return (K) instance;
        }

        public Dictionary<string, IModule> GetConfigs()
        {
            return mModuleConfigs;
        }


        public T GetController<T>() where T : IModule
        {
            string name = typeof(T).Name;
            if (mModuleConfigs.ContainsKey(name))
            {
                return (T) mModuleConfigs[name];
            }

            if (!typeof(T).IsInterface)
            {
                Debug.LogError("T 需要是接口类型：I" + name + "  当前类型是: " + name);
            }
            else
            {
                Debug.LogError("T需继承自：IBiologyController");
            }

            return default;
        }
    }
}

