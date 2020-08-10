
namespace CHotfix
{
    /// <summary>
    /// 所有模块的基类
    /// </summary>
    public class ModuleBase
    {
        public virtual void Init()
        {
        }

        public virtual void Release()
        {
        }

        public virtual void Update()
        {
        }

        public virtual void OnApplicationFocus(bool focus)
        {
        }
    }
}
