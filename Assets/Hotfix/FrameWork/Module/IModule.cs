
/// <summary>
/// 所有管理器接口的基类
/// </summary>
public interface IModule
{
    /// <summary>
    /// 生命周期:初始化
    /// </summary>
    void Init();
    /// <summary>
    /// 生命周期:释放
    /// </summary>
    void Release();

    /// <summary>
    /// 生命周期 Update
    /// </summary>
    void Update();

    void OnApplicationFocus(bool focus);
}
