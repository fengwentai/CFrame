/// <summary>
/// 配置管理器
/// </summary>


namespace CHotfix
{
    public class ConfigMgr : ModuleBase, IConfigMgr
    {
        public T GetConfig<T>(int configId) where T : IConfig
        {
            throw new System.NotImplementedException();
        }
    }

}

