using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using KSP.IO;

namespace ActsEW
{
    public class ModuleGimbalActions :PartModule
    {
        
        
        [KSPAction("Enable Gimbal")]
        public void EnableGimbalAction(KSPActionParam param)
        {
            foreach (ModuleGimbal pm in this.part.Modules.OfType<ModuleGimbal>())
            {
                pm.FreeGimbal();
            }
        }

        [KSPAction("Disable Gimbal")]
        public void DisableGimbalAction(KSPActionParam param)
        {
            foreach (ModuleGimbal pm in this.part.Modules.OfType<ModuleGimbal>())
            {
                pm.LockGimbal();
            }
        }
    }
}
