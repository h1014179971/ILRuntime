using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Foundation
{
    public class AutoResGCMgr : Singleton<AutoResGCMgr>
    {
        public int AutoGCInterval = 30;
        private float gcTick = 0;

        public void Update(float dt)
        {
            gcTick += dt;
            if (gcTick >= AutoGCInterval)
            {
                Resources.UnloadUnusedAssets();
                GC.Collect();
                gcTick = 0;
            }
        }
    }
}

