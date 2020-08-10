using System;
using System.IO;
using CModel;
using UnityEditor;
using UnityEngine;

namespace ETEditor
{
    [InitializeOnLoad]
    public class Startup
    {
        private const string ScriptAssembliesDir = "Library/ScriptAssemblies";
       // private const string CodeDir = "Assets/Bundles/Code/";
       private const string CodeDir = "Assets/Resources/";
        private const string HotfixDll = "Unity.Hotfix.dll";
        private const string HotfixPdb = "Unity.Hotfix.pdb";

        static Startup()
        {
            if (!File.Exists(CodeDir))
            {
                Directory.CreateDirectory(CodeDir);
            }

            var dllSource = FilesUtil.SafeReadAllBytes(Path.Combine(ScriptAssembliesDir, HotfixDll));
            var dllEncryp = dllSource;
            FilesUtil.SafeWriteAllBytes(Path.Combine(CodeDir, "Hotfix.dll.bytes"), dllEncryp);

            var pdbSource = FilesUtil.SafeReadAllBytes(Path.Combine(ScriptAssembliesDir, HotfixPdb));
            var pdbEncryp = pdbSource;
            FilesUtil.SafeWriteAllBytes(Path.Combine(CodeDir, "Hotfix.pdb.bytes"), pdbEncryp);

            Debug.Log($"复制Hotfix.dll, Hotfix.pdb到{CodeDir}完成");
            AssetDatabase.Refresh ();
        }
    }
}