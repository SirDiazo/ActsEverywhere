using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using UnityEngine;
using KSP.IO;

namespace ActsEW
{
    //[KSPAddon(KSPAddon.Startup.Flight,false)]
    //public class StockActions : PartModule
    //{
    //    //public void Start()
    //    //{
    //    //    print("TEST started okay");
    //    //    foreach (Assembly a in AppDomain.CurrentDomain.GetAssemblies())
    //    //    {
    //    //        foreach (Type t in a.GetTypes())
    //    //        {
    //    //           if(t.GetType() == PartModule)
    //    //        }
    //    //    }
    //    //    //PartModule[] allPMs = GameObject.FindObjectsOfType<PartModule>();
    //    //    //foreach (PartModule pm in allPMs)
    //    //    //{
    //    //    //    print(pm.name + " " + pm.moduleName);
    //    //    //}
    //    //}

    //    public void Update()
    //    {
    //        if (DateTime.Now.Second == 30)
    //        {
    //            print("Toggle Gimbal");
    //            foreach (Part p in FlightGlobals.ActiveVessel.Parts)
    //            {
    //                foreach(PartModule pm in p.Modules.OfType<ModuleGimbal>())
    //                {
    //                    print("Part count " + pm.Actions.Count);
    //                    KSPActionParam actParam = new KSPActionParam(KSPActionGroup.None, KSPActionType.Activate);
    //                    foreach (BaseAction ba in pm.Actions)
    //                    {
    //                        print("Invoking " + ba.guiName);
    //                        ba.Invoke(actParam);
    //                    }
    //                }
    //            }
    //        }

    //    }
    //}
    
    public class ModuleGimbalActions :PartModule
    {

        //public void OnStart()
        //{
        //    DisableActions();
        //}
        //public override void OnLoad(ConfigNode node)
        //{
        //    DisableActions();
        //}

        //public void DisableActions()
        //{
        //    print("Disabling actions");
        //    foreach (ModuleGimbal pm in this.part.Modules.OfType<ModuleGimbal>())
        //    {
        //        foreach (BaseAction ba in pm.Actions.Where(ba2 => ba2.name == "ToggleAction"))
        //        {
        //            print("Disabling " + ba.guiName);
        //            ba.active = false;
        //        }
        //    }
        //}


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

        //[KSPAction("Tog Gimbal")]
        //public void TogGimbalAction(KSPActionParam param)
        //{
        //    foreach (ModuleGimbal pm in this.part.Modules.OfType<ModuleGimbal>())
        //    {
        //        if (pm.gimbalLock)
        //        {
        //            pm.FreeGimbal();
        //        }
        //        else
        //        {
        //            pm.LockGimbal();
        //        }
        //    }
        //}
        
    }
    public class ModuleDockingNodeActions : PartModule
    {
        [KSPAction("Control From Here")]
        public void ControlFromHere(KSPActionParam param)
        {
            this.part.vessel.SetReferenceTransform(this.part);
        }
    }

    public class ModuleCommandActions : PartModule
    {
        [KSPAction("Control From Here")]
        public void ControlFromHere(KSPActionParam param)
        {
            this.part.vessel.SetReferenceTransform(this.part);
        }
    }
}
