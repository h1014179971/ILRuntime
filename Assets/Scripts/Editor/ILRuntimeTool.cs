using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Diagnostics;
using System;

namespace EditorTool
{
    public class ILRuntimeTool
    {
        private const string dllName = "HotFix.dll";
        private const string pdbName = "HotFix.pdb";

        //private const string msbuildExe = "C:/Windows/Microsoft.NET/Framework/v4.0.30319/MSBuild.exe";
        private const string msbuildExe = "D:/Program Files (x86)/Microsoft Visual Studio/2019/Enterprise/MSBuild/Current/Bin/MSBuild.exe";

        [MenuItem("Tools/ILRuntime/Generate CLR Binding Code by Analysis")]
        static void GenerateCLRBindingByAnalysis()
        {
            ILRuntime.Runtime.Enviorment.AppDomain domain = new ILRuntime.Runtime.Enviorment.AppDomain();
            using (System.IO.FileStream fs = new System.IO.FileStream(Application.streamingAssetsPath+ "/"+ dllName, System.IO.FileMode.Open, System.IO.FileAccess.Read))
            {
                domain.LoadAssembly(fs);

                //Crossbind Adapter is needed to generate the correct binding code
                InitILRuntime(domain);
                ILRuntime.Runtime.CLRBinding.BindingCodeGenerator.GenerateBindingCode(domain, "Assets/ILRuntime/Generated");
            }

            AssetDatabase.Refresh();
        }
        static void InitILRuntime(ILRuntime.Runtime.Enviorment.AppDomain domain)
        {
            //这里需要注册所有热更DLL中用到的跨域继承Adapter，否则无法正确抓取引用
            domain.RegisterCrossBindingAdaptor(new MonoBehaviourAdapter());
            domain.RegisterCrossBindingAdaptor(new CoroutineAdapter());

            domain.RegisterCrossBindingAdaptor(new System.ExceptionAdapter());
            domain.RegisterCrossBindingAdaptor(new UnityEngine.ScriptableObjectAdapter());
            domain.RegisterCrossBindingAdaptor(new UnityEngine.Networking.DownloadHandlerScriptAdapter());
            domain.RegisterCrossBindingAdaptor(new System.Security.Cryptography.HashAlgorithmAdapter());
            //domain.RegisterCrossBindingAdaptor(new TestClassBaseAdapter());
            //domain.RegisterValueTypeBinder(typeof(Vector3), new Vector3Binder());
        }
        [MenuItem("Tools/ILRuntime/生成CLRBinding")]
        static void GenerateCLRBinding()
        {
            List<Type> types = new List<Type>();
            types.Add(typeof(int));
            types.Add(typeof(float));
            types.Add(typeof(long));
            types.Add(typeof(bool));
            types.Add(typeof(object));
            types.Add(typeof(string));
            types.Add(typeof(Array));
            types.Add(typeof(Vector2));
            types.Add(typeof(Vector3));
            types.Add(typeof(Quaternion));
            types.Add(typeof(GameObject));
            types.Add(typeof(UnityEngine.Object));
            types.Add(typeof(Transform));
            types.Add(typeof(RectTransform));
            types.Add(typeof(Time));
            types.Add(typeof(UnityEngine.Debug));
            //所有DLL内的类型的真实C#类型都是ILTypeInstance
            types.Add(typeof(List<ILRuntime.Runtime.Intepreter.ILTypeInstance>));

            ILRuntime.Runtime.CLRBinding.BindingCodeGenerator.GenerateBindingCode(types, "Assets/ILRuntime/Generated");
            AssetDatabase.Refresh();
        }
        //static void Initialize(ILRuntime.Runtime.Enviorment.AppDomain appdomain)
        //{
        //    // 注册委托
        //    appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.Events.UnityAction>((act) =>
        //    {
        //        return new UnityEngine.Events.UnityAction(() =>
        //        {
        //            ((Action)act)();
        //        });
        //    });

        //    // CLR 绑定
        //    CLRBindings.Initialize(appdomain);

        //    // 注册适配器
        //    appdomain.RegisterCrossBindingAdaptor(new IUIInterfaceAdapter());
        //}

        [MenuItem("Tools/ILRuntime/生成跨域继承适配器")]
        static void GenerateCrossbindAdapter()
        {
            //由于跨域继承特殊性太多，自动生成无法实现完全无副作用生成，所以这里提供的代码自动生成主要是给大家生成个初始模版，简化大家的工作
            //大多数情况直接使用自动生成的模版即可，如果遇到问题可以手动去修改生成后的文件，因此这里需要大家自行处理是否覆盖的问题

            string adaptorPath = "Assets/ILRuntime/Runtime/Adaptors/Generated/";
            string ext = "Adapter.cs";
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(adaptorPath+"Exception"+ext))
            {
                sw.WriteLine(ILRuntime.Runtime.Enviorment.CrossBindingCodeGenerator.GenerateCrossBindingAdapterCode(typeof(System.Exception), "System"));
            }
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(adaptorPath+ "ScriptableObject"+ext))
            {
                sw.WriteLine(ILRuntime.Runtime.Enviorment.CrossBindingCodeGenerator.GenerateCrossBindingAdapterCode(typeof(UnityEngine.ScriptableObject), "UnityEngine"));
            }
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(adaptorPath + "DownloadHandlerScript"+ext))
            {
                sw.WriteLine(ILRuntime.Runtime.Enviorment.CrossBindingCodeGenerator.GenerateCrossBindingAdapterCode(typeof(UnityEngine.Networking.DownloadHandlerScript), "UnityEngine.Networking"));
            }
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(adaptorPath + "HashAlgorithm"+ext))
            {
                sw.WriteLine(ILRuntime.Runtime.Enviorment.CrossBindingCodeGenerator.GenerateCrossBindingAdapterCode(typeof(System.Security.Cryptography.HashAlgorithm), "System.Security.Cryptography"));
            }
            //using (System.IO.StreamWriter sw = new System.IO.StreamWriter(adaptorPath + "FullSerializerAPI" + ext))
            //{
            //    sw.WriteLine(ILRuntime.Runtime.Enviorment.CrossBindingCodeGenerator.GenerateCrossBindingAdapterCode(typeof(FullSerializer.FullSerializerAPI), "FullSerializer"));
            //}
            AssetDatabase.Refresh();
        }
        [MenuItem("Tools/ILRuntime/Build HotFix(Debug)")]
        static void BuildHotfixDebug()
        {
            BuildHotfix("Debug");
        }
        [MenuItem("Tools/ILRuntime/Build HotFix(Release)")]
        static void BuildHotfixRelease()
        {
            BuildHotfix("Release");
        }
        static void BuildHotfix(string _c)
        {
            if (!File.Exists(msbuildExe))
            {
                UnityEngine.Debug.LogError("找不到 MSBuild 工具");
                return;
            }
            //System.IO.DirectoryInfo parent = System.IO.Directory.GetParent(System.Environment.CurrentDirectory);
            System.IO.DirectoryInfo parent = System.IO.Directory.GetParent(Application.dataPath);
            string projectPath = parent.ToString();
            ProcessCommand(msbuildExe, projectPath + "/Assets/Scripts/HotFixPro~/HotFix/HotFix/HotFix.csproj /t:Rebuild /p:Configuration=" + _c);
            UnityEngine.Debug.LogFormat("Hotfix {0} 编译完成", _c);
            CopyFile(_c);
        }
        public static void ProcessCommand(string command, string argument)
        {
            ProcessStartInfo start = new ProcessStartInfo(command);
            start.Arguments = argument;
            start.CreateNoWindow = true;
            start.ErrorDialog = true;
            start.UseShellExecute = true;
            if (start.UseShellExecute)
            {
                start.RedirectStandardOutput = false;
                start.RedirectStandardError = false;
                start.RedirectStandardInput = false;
            }
            else
            {
                start.RedirectStandardOutput = true;
                start.RedirectStandardError = true;
                start.RedirectStandardInput = true;
                start.StandardOutputEncoding = System.Text.UTF8Encoding.UTF8;
                start.StandardErrorEncoding = System.Text.UTF8Encoding.UTF8;
            }
            Process p = Process.Start(start);
            if (!start.UseShellExecute)
            {
                UnityEngine.Debug.LogFormat("--- output:{0}", p.StandardOutput.ToString());
                //printOutPut(p.StandardOutput);
                //printOutPut(p.StandardError);
            }
            p.WaitForExit();
            p.Close();
        }
        static void CopyFile(string _c)
        {
            System.IO.DirectoryInfo parent = System.IO.Directory.GetParent(Application.dataPath);
            string projectPath = parent.ToString();
            string dllPath = projectPath + "/Assets/Scripts/HotFixPro~/HotFix/HotFix/bin/" + _c+ "/"+dllName;
            string pdbPath = projectPath + "/Assets/Scripts/HotFixPro~/HotFix/HotFix/bin/" + _c+ "/"+pdbName;
            string toDllPath = Application.streamingAssetsPath + "/"+dllName;
            string topdbPath = Application.streamingAssetsPath + "/"+pdbName;
            if (File.Exists(dllPath))
                File.Copy(dllPath, toDllPath,true);
            if (File.Exists(pdbPath))
                File.Copy(pdbPath, topdbPath,true);
            AssetDatabase.Refresh();
        }
    }
}

