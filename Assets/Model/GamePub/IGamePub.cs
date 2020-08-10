
//using CHotfix;

using System;

namespace CModel
{
    public interface IGamePub
    {
        T GetModule<T>() where T : IModule;
        Action HUpdate { set;}
        Action<bool> HOnApplicationFocus{ set;}
    }
}
