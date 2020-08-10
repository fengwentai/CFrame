using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using ILRuntime.Runtime.Enviorment;
using ILRuntime.Runtime.Generated;
using ILRuntime.Runtime.Intepreter;
using UnityEngine;

namespace CModel
{
    public static class ILHelper
    {
        public static void InitILRuntime(ILRuntime.Runtime.Enviorment.AppDomain appdomain)
        {
            // 注册重定向函数

            appdomain.DelegateManager.RegisterMethodDelegate<List<object>>();
            appdomain.DelegateManager.RegisterMethodDelegate<byte[], int, int>();
            appdomain.DelegateManager.RegisterMethodDelegate<ILTypeInstance>();
            appdomain.DelegateManager.RegisterMethodDelegate<int>();
            appdomain.DelegateManager.RegisterMethodDelegate<int, string>();
            appdomain.DelegateManager.RegisterMethodDelegate<bool>();
            appdomain.DelegateManager.RegisterMethodDelegate<float>();
            appdomain.DelegateManager.RegisterMethodDelegate<string>();
            appdomain.DelegateManager.RegisterMethodDelegate<string, float>();
            appdomain.DelegateManager.RegisterMethodDelegate<string, double>();
            appdomain.DelegateManager.RegisterMethodDelegate<string, string>();
            appdomain.DelegateManager.RegisterMethodDelegate<string, string, float>();
            appdomain.DelegateManager.RegisterMethodDelegate<WWW>();
            appdomain.DelegateManager.RegisterMethodDelegate<GameObject>();
            appdomain.DelegateManager.RegisterMethodDelegate<GameObject, int>();
            appdomain.DelegateManager.RegisterMethodDelegate<object>();
            appdomain.DelegateManager.RegisterMethodDelegate<int, bool, GameObject>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.String, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.String, System.String, System.Int32>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.Color>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.Color>();
            appdomain.DelegateManager
                .RegisterFunctionDelegate<System.Collections.Generic.KeyValuePair<System.String, System.Int32>,
                    System.Boolean>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Int32, UnityEngine.Sprite>();
            //TSTableView
            appdomain.DelegateManager.RegisterMethodDelegate<System.Int32, System.Boolean>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.Transform>();
            appdomain.DelegateManager.RegisterMethodDelegate<GameObject, GameObject, int, int>();
            appdomain.DelegateManager.RegisterFunctionDelegate<bool>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Func<bool>>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ILTypeInstance, bool>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ILTypeInstance, ILTypeInstance, int>();
            appdomain.DelegateManager.RegisterMethodDelegate<int, ILTypeInstance>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Object, System.EventArgs>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.Texture2D>();
            appdomain.DelegateManager
                .RegisterMethodDelegate<ILRuntime.Runtime.Intepreter.ILTypeInstance, System.Int32, System.Boolean>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Int32, System.Single>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.String, System.Int32>();
#if Facebook
            appdomain.DelegateManager.RegisterMethodDelegate<Facebook.Unity.ILoginResult>();
            appdomain.DelegateManager.RegisterMethodDelegate<Facebook.Unity.IGraphResult>();
#endif
            appdomain.DelegateManager.RegisterFunctionDelegate<string, AndroidJavaObject>();
            appdomain.DelegateManager.RegisterFunctionDelegate<string, AndroidJavaObject, string>();
            appdomain.DelegateManager.RegisterFunctionDelegate<string, AndroidJavaObject, string, string>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Single>();

            appdomain.DelegateManager
                .RegisterMethodDelegate<ILRuntime.Runtime.Intepreter.ILTypeInstance, System.Int32>();

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.Events.UnityAction<System.String>>((act) =>
            {
                return new UnityEngine.Events.UnityAction<System.String>((arg0) =>
                {
                    ((Action<System.String>) act)(arg0);
                });
            });


            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<System.String>>((act) =>
            {
                return new System.Comparison<System.String>((x, y) =>
                {
                    return ((Func<System.String, System.String, System.Int32>) act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Threading.ThreadStart>((act) =>
            {
                return new System.Threading.ThreadStart(() => { ((Action) act)(); });
            });

           
            //UnityAction
            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.Events.UnityAction>((act) =>
            {
                return new UnityEngine.Events.UnityAction(() => { ((Action) act)(); });
            });

            


            //TSTableview
            appdomain.DelegateManager
                .RegisterDelegateConvertor<UnityEngine.Events.UnityAction<System.Int32, System.Boolean>>((act) =>
                {
                    return new UnityEngine.Events.UnityAction<System.Int32, System.Boolean>((arg0, arg1) =>
                    {
                        ((Action<System.Int32, System.Boolean>) act)(arg0, arg1);
                    });
                });
            appdomain.DelegateManager
                .RegisterDelegateConvertor<UnityEngine.Events.UnityAction<System.Int32, System.Single>>((act) =>
                {
                    return new UnityEngine.Events.UnityAction<System.Int32, System.Single>((arg0, arg1) =>
                    {
                        ((Action<System.Int32, System.Single>) act)(arg0, arg1);
                    });
                });

           


            //Predicate<ILTypeInstance>
            appdomain.DelegateManager.RegisterDelegateConvertor<Predicate<ILTypeInstance>>((act) =>
            {
                return new Predicate<ILRuntime.Runtime.Intepreter.ILTypeInstance>((obj) =>
                {
                    return ((Func<ILTypeInstance, bool>) act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<Predicate<System.String>>((act) =>
            {
                return new Predicate<System.String>((obj) => { return ((Func<System.String, bool>) act)(obj); });
            });


            //Sort函数
            appdomain.DelegateManager
                .RegisterDelegateConvertor<Comparison<ILRuntime.Runtime.Intepreter.ILTypeInstance>>((act) =>
                {
                    return new Comparison<ILRuntime.Runtime.Intepreter.ILTypeInstance>((x, y) =>
                    {
                        return ((Func<ILTypeInstance, ILTypeInstance, int>) act)(x, y);
                    });
                });


#if Facebook
            //Facebook
            appdomain.DelegateManager.RegisterDelegateConvertor<Facebook.Unity.InitDelegate>((act) =>
            {
                return new Facebook.Unity.InitDelegate(() =>
                {
                    ((Action)act)();
                });
            });
            // //Facebook
            appdomain.DelegateManager.RegisterDelegateConvertor<Facebook.Unity.HideUnityDelegate>((act) =>
            {
                return new Facebook.Unity.HideUnityDelegate((isUnityShown) =>
                {
                    ((Action<bool>)act)(isUnityShown);
                });
            });

            
            appdomain.DelegateManager.RegisterDelegateConvertor<Facebook.Unity.FacebookDelegate<Facebook.Unity.IGraphResult>>((act) =>
            {
                return new Facebook.Unity.FacebookDelegate<Facebook.Unity.IGraphResult>((result) =>
                {
                    ((Action<Facebook.Unity.IGraphResult>)act)(result);
                });
            });
            
            appdomain.DelegateManager.RegisterDelegateConvertor<Facebook.Unity.FacebookDelegate<Facebook.Unity.ILoginResult>>((act) =>
            {
                return new Facebook.Unity.FacebookDelegate<Facebook.Unity.ILoginResult>((result) =>
                {
                    ((Action<Facebook.Unity.ILoginResult>)act)(result);
                });
            });

#endif
            CLRBindings.Initialize(appdomain);

            // 注册适配器
            Assembly assembly = typeof(GamePub).Assembly;
            foreach (Type type in assembly.GetTypes())
            {
                object[] attrs = type.GetCustomAttributes(typeof(ILAdapterAttribute), false);
                if (attrs.Length == 0)
                {
                    continue;
                }

                object obj = Activator.CreateInstance(type);
                CrossBindingAdaptor adaptor = obj as CrossBindingAdaptor;
                if (adaptor == null)
                {
                    continue;
                }

                appdomain.RegisterCrossBindingAdaptor(adaptor);
            }

            LitJson.JsonMapper.RegisterILRuntimeCLRRedirection(appdomain);
        }
    }
}