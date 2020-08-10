/// <summary>
/// 管理器接口模板
/// </summary>

namespace CHotfix
{
    public interface IConfigMgr : IModule
    {
        T GetConfig<T>(int configId) where T : IConfig;
    }

}

