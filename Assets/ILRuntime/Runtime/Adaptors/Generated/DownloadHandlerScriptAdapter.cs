using System;
using ILRuntime.CLR.Method;
using ILRuntime.Runtime.Enviorment;
using ILRuntime.Runtime.Intepreter;

namespace UnityEngine.Networking
{   
    public class DownloadHandlerScriptAdapter : CrossBindingAdaptor
    {
        static CrossBindingFunctionInfo<System.Byte[]> mGetData_0 = new CrossBindingFunctionInfo<System.Byte[]>("GetData");
        static CrossBindingFunctionInfo<System.String> mGetText_1 = new CrossBindingFunctionInfo<System.String>("GetText");
        static CrossBindingFunctionInfo<System.Byte[], System.Int32, System.Boolean> mReceiveData_2 = new CrossBindingFunctionInfo<System.Byte[], System.Int32, System.Boolean>("ReceiveData");
        static CrossBindingMethodInfo<System.Int32> mReceiveContentLength_3 = new CrossBindingMethodInfo<System.Int32>("ReceiveContentLength");
        static CrossBindingMethodInfo mCompleteContent_4 = new CrossBindingMethodInfo("CompleteContent");
        static CrossBindingFunctionInfo<System.Single> mGetProgress_5 = new CrossBindingFunctionInfo<System.Single>("GetProgress");
        public override Type BaseCLRType
        {
            get
            {
                return typeof(UnityEngine.Networking.DownloadHandlerScript);
            }
        }

        public override Type AdaptorType
        {
            get
            {
                return typeof(Adapter);
            }
        }

        public override object CreateCLRInstance(ILRuntime.Runtime.Enviorment.AppDomain appdomain, ILTypeInstance instance)
        {
            return new Adapter(appdomain, instance);
        }

        public class Adapter : UnityEngine.Networking.DownloadHandlerScript, CrossBindingAdaptorType
        {
            ILTypeInstance instance;
            ILRuntime.Runtime.Enviorment.AppDomain appdomain;

            public Adapter()
            {

            }

            public Adapter(ILRuntime.Runtime.Enviorment.AppDomain appdomain, ILTypeInstance instance)
            {
                this.appdomain = appdomain;
                this.instance = instance;
            }

            public ILTypeInstance ILInstance { get { return instance; } }

            protected override System.Byte[] GetData()
            {
                if (mGetData_0.CheckShouldInvokeBase(this.instance))
                    return base.GetData();
                else
                    return mGetData_0.Invoke(this.instance);
            }

            protected override System.String GetText()
            {
                if (mGetText_1.CheckShouldInvokeBase(this.instance))
                    return base.GetText();
                else
                    return mGetText_1.Invoke(this.instance);
            }

            protected override System.Boolean ReceiveData(System.Byte[] data, System.Int32 dataLength)
            {
                if (mReceiveData_2.CheckShouldInvokeBase(this.instance))
                    return base.ReceiveData(data, dataLength);
                else
                    return mReceiveData_2.Invoke(this.instance, data, dataLength);
            }

            protected override void ReceiveContentLength(System.Int32 contentLength)
            {
                if (mReceiveContentLength_3.CheckShouldInvokeBase(this.instance))
                    base.ReceiveContentLength(contentLength);
                else
                    mReceiveContentLength_3.Invoke(this.instance, contentLength);
            }

            protected override void CompleteContent()
            {
                if (mCompleteContent_4.CheckShouldInvokeBase(this.instance))
                    base.CompleteContent();
                else
                    mCompleteContent_4.Invoke(this.instance);
            }

            protected override System.Single GetProgress()
            {
                if (mGetProgress_5.CheckShouldInvokeBase(this.instance))
                    return base.GetProgress();
                else
                    return mGetProgress_5.Invoke(this.instance);
            }

            public override string ToString()
            {
                IMethod m = appdomain.ObjectType.GetMethod("ToString", 0);
                m = instance.Type.GetVirtualMethod(m);
                if (m == null || m is ILMethod)
                {
                    return instance.ToString();
                }
                else
                    return instance.Type.FullName;
            }
        }
    }
}

