/// <summary>
/// 管理器接口模板
/// </summary>

using System;
using System.Collections.Generic;

namespace CModel
{
    public interface IHotfixMgr : IModule
    {
        void LoadDll();
        List<Type> GetHotfixTypes();
        void RunDll();
    }

}

