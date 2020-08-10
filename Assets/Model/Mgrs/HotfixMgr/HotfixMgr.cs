/// <summary>
/// 热更管理器
/// </summary>


using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace CModel
{
    public class HotfixMgr : ModuleBase, IHotfixMgr
    {
        private const string dllPath = "Hotfix.dll";
        private const string pdbPath = "Hotfix.pdb";
        
#if  ILRuntime
		private ILRuntime.Runtime.Enviorment.AppDomain appDomain;
		private MemoryStream dllStream;
		private MemoryStream pdbStream;
#else
        private Assembly assembly;
#endif
        
        private IStaticMethod start;
        private List<Type> hotfixTypes;
        
        public List<Type> GetHotfixTypes()
        {
            return this.hotfixTypes;
        }

        public void RunDll()
        {
#if ILRuntime
            ILHelper.InitILRuntime(this.appDomain);
#endif
            this.start.Run();
        }

        public void LoadDll()
        {
            byte[] dllBytes = null;
            byte[] pdbBytes = null;
            var dllText = Resources.Load<TextAsset>(dllPath);
            if (dllText != null)
            {
                dllBytes = dllText.bytes;
            }

            var pdbText = Resources.Load<TextAsset>(pdbPath);
            if (pdbText != null)
            {
                pdbBytes = pdbText.bytes;
            }

            InitDllData(dllBytes,pdbBytes);
        }

        private void InitDllData(byte[] assBytes, byte[] pdbBytes)
        {
#if  ILRuntime
            Debug.Log($"当前使用的是ILRuntime模式");
            this.appDomain = new ILRuntime.Runtime.Enviorment.AppDomain();

            this.dllStream = new MemoryStream(assBytes);
            this.pdbStream = new MemoryStream(pdbBytes);
            this.appDomain.LoadAssembly(this.dllStream, this.pdbStream, new Mono.Cecil.Pdb.PdbReaderProvider());

            this.start = new ILStaticMethod(this.appDomain, "CHotfix.HGamePub", "Start", 0);

            this.hotfixTypes = this.appDomain.LoadedTypes.Values.Select(x => x.ReflectionType).ToList();
#else
            Debug.Log($"当前使用的是Mono模式");

            this.assembly = Assembly.Load(assBytes, pdbBytes);

            Type hotfixInit = this.assembly.GetType("CHotfix.HGamePub");
            this.start = new MonoStaticMethod(hotfixInit, "Start");
			
            this.hotfixTypes = this.assembly.GetTypes().ToList();
#endif
        }

    }
}