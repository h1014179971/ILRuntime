using System;
using ILRuntime.CLR.Method;
using ILRuntime.Runtime.Enviorment;
using ILRuntime.Runtime.Intepreter;

namespace System.Security.Cryptography
{   
    public class HashAlgorithmAdapter : CrossBindingAdaptor
    {
        static CrossBindingFunctionInfo<System.Int32> mget_HashSize_0 = new CrossBindingFunctionInfo<System.Int32>("get_HashSize");
        static CrossBindingFunctionInfo<System.Byte[]> mget_Hash_1 = new CrossBindingFunctionInfo<System.Byte[]>("get_Hash");
        static CrossBindingFunctionInfo<System.Int32> mget_InputBlockSize_2 = new CrossBindingFunctionInfo<System.Int32>("get_InputBlockSize");
        static CrossBindingFunctionInfo<System.Int32> mget_OutputBlockSize_3 = new CrossBindingFunctionInfo<System.Int32>("get_OutputBlockSize");
        static CrossBindingFunctionInfo<System.Boolean> mget_CanTransformMultipleBlocks_4 = new CrossBindingFunctionInfo<System.Boolean>("get_CanTransformMultipleBlocks");
        static CrossBindingFunctionInfo<System.Boolean> mget_CanReuseTransform_5 = new CrossBindingFunctionInfo<System.Boolean>("get_CanReuseTransform");
        static CrossBindingMethodInfo<System.Boolean> mDispose_6 = new CrossBindingMethodInfo<System.Boolean>("Dispose");
        static CrossBindingMethodInfo mInitialize_7 = new CrossBindingMethodInfo("Initialize");
        static CrossBindingMethodInfo<System.Byte[], System.Int32, System.Int32> mHashCore_8 = new CrossBindingMethodInfo<System.Byte[], System.Int32, System.Int32>("HashCore");
        static CrossBindingFunctionInfo<System.Byte[]> mHashFinal_9 = new CrossBindingFunctionInfo<System.Byte[]>("HashFinal");
        public override Type BaseCLRType
        {
            get
            {
                return typeof(System.Security.Cryptography.HashAlgorithm);
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

        public class Adapter : System.Security.Cryptography.HashAlgorithm, CrossBindingAdaptorType
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

            protected override void Dispose(System.Boolean disposing)
            {
                if (mDispose_6.CheckShouldInvokeBase(this.instance))
                    base.Dispose(disposing);
                else
                    mDispose_6.Invoke(this.instance, disposing);
            }

            public override void Initialize()
            {
                mInitialize_7.Invoke(this.instance);
            }

            protected override void HashCore(System.Byte[] array, System.Int32 ibStart, System.Int32 cbSize)
            {
                mHashCore_8.Invoke(this.instance, array, ibStart, cbSize);
            }

            protected override System.Byte[] HashFinal()
            {
                return mHashFinal_9.Invoke(this.instance);
            }

            public override System.Int32 HashSize
            {
            get
            {
                if (mget_HashSize_0.CheckShouldInvokeBase(this.instance))
                    return base.HashSize;
                else
                    return mget_HashSize_0.Invoke(this.instance);

            }
            }

            public override System.Byte[] Hash
            {
            get
            {
                if (mget_Hash_1.CheckShouldInvokeBase(this.instance))
                    return base.Hash;
                else
                    return mget_Hash_1.Invoke(this.instance);

            }
            }

            public override System.Int32 InputBlockSize
            {
            get
            {
                if (mget_InputBlockSize_2.CheckShouldInvokeBase(this.instance))
                    return base.InputBlockSize;
                else
                    return mget_InputBlockSize_2.Invoke(this.instance);

            }
            }

            public override System.Int32 OutputBlockSize
            {
            get
            {
                if (mget_OutputBlockSize_3.CheckShouldInvokeBase(this.instance))
                    return base.OutputBlockSize;
                else
                    return mget_OutputBlockSize_3.Invoke(this.instance);

            }
            }

            public override System.Boolean CanTransformMultipleBlocks
            {
            get
            {
                if (mget_CanTransformMultipleBlocks_4.CheckShouldInvokeBase(this.instance))
                    return base.CanTransformMultipleBlocks;
                else
                    return mget_CanTransformMultipleBlocks_4.Invoke(this.instance);

            }
            }

            public override System.Boolean CanReuseTransform
            {
            get
            {
                if (mget_CanReuseTransform_5.CheckShouldInvokeBase(this.instance))
                    return base.CanReuseTransform;
                else
                    return mget_CanReuseTransform_5.Invoke(this.instance);

            }
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

