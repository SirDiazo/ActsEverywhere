using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using UnityEngine;
using KSP.IO;

namespace ActsEW
{
    //public class ModuleGimbalActions : PartModule
    //{
    //    [KSPAction("Enable Gimbal")]
    //    public void EnableGimbalAction(KSPActionParam param)
    //    {
    //        foreach (ModuleGimbal pm in this.part.Modules.OfType<ModuleGimbal>())
    //        {
    //            pm.FreeGimbal();
    //        }
    //    }

    //    [KSPAction("Disable Gimbal")]
    //    public void DisableGimbalAction(KSPActionParam param)
    //    {
    //        foreach (ModuleGimbal pm in this.part.Modules.OfType<ModuleGimbal>())
    //        {
    //            pm.LockGimbal();
    //        }
    //    }
    //}
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
        //[KSPAction("setLock")]
        //public void setLock(KSPActionParam param)
        //{
        //    //Debug.Log("lock set? " + ControlLockInstalled());
        //}
        //InputLockManager.
        //public static bool ControlLockInforce()
        //{
        //    try //try-catch is required as the below code returns a NullRef if AGX is not present. 
        //    {
        //        Type calledType = Type.GetType("ControlLock.ControlLock, ControlLock");
        //        return (bool)calledType.InvokeMember("IsLockSet", BindingFlags.InvokeMethod | BindingFlags.Public | BindingFlags.Static, null, null, null);
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
        //[KSPAction("unsetLock")]
        //public void unsetLock(KSPActionParam param)
        //{
        //    ControlLock.ControlLock.UnsetFullLock("TestLock");
        //}

        //[KSPAction("minEng")]
        //public void minEng(KSPActionParam param)
        //{
        //    foreach (Part p in FlightGlobals.ActiveVessel.parts)
        //    {
        //        foreach (ModuleEngines eng in p.Modules.OfType<ModuleEngines>())
        //        {
        //            print("min eng");
        //            eng.manuallyOverridden = true;
        //            eng.currentThrottle = 0f;
        //            eng.requestedThrottle = 0f;
        //        }
        //    }
        //}

        //[KSPAction("resetEng")]
        //public void resetEng(KSPActionParam param)
        //{
        //    foreach (Part p in FlightGlobals.ActiveVessel.parts)
        //    {
        //        foreach (ModuleEngines eng in p.Modules.OfType<ModuleEngines>())
        //        {
        //            print("res eng");
        //            eng.manuallyOverridden = false;
        //        }
        //    }
        //}

        //public void Update()
        //{
        //    foreach (Part p in FlightGlobals.ActiveVessel.parts)
        //    {
        //        foreach (ModuleEngines eng in p.Modules.OfType<ModuleEngines>())
        //        {
        //            print("throttle " + eng.currentThrottle + eng.requestedThrottle);

        //        }
        //    }
        //}

        //public static List<Part> AGX2VslPartsWithActions(uint flightID, int group)
        //{
        //    Type calledType = Type.GetType("ActionGroupsExtended.AGExtExternal, AGExt");
        //    List<Part> RetActs = (List<Part>)calledType.InvokeMember("AGX2VslListOfPartsInGroup", BindingFlags.InvokeMethod | BindingFlags.Public | BindingFlags.Static, null, null, new System.Object[] {flightID, group });
        //    return RetActs;
        //}
        //public static List<PartModule> AGX2VslPartModulesWithActions(uint flightID, int group)
        //{
        //    Type calledType = Type.GetType("ActionGroupsExtended.AGExtExternal, AGExt");
        //    List<PartModule> RetActs = (List<PartModule>)calledType.InvokeMember("AGX2VslListOfPartModulesInGroup", BindingFlags.InvokeMethod | BindingFlags.Public | BindingFlags.Static, null, null, new System.Object[] {flightID, group });
        //    return RetActs;
        //}

        //public static List<Part> AGXPartsWithActions(int group)
        //{
        //    Type calledType = Type.GetType("ActionGroupsExtended.AGExtExternal, AGExt");
        //    List<Part> RetActs = (List<Part>)calledType.InvokeMember("AGXListOfPartsInGroup", BindingFlags.InvokeMethod | BindingFlags.Public | BindingFlags.Static, null, null, new System.Object[] { group });
        //    return RetActs;
        //}
        //public static List<PartModule> AGXPartModulessWithActions(int group)
        //{
        //    Type calledType = Type.GetType("ActionGroupsExtended.AGExtExternal, AGExt");
        //    List<PartModule> RetActs = (List<PartModule>)calledType.InvokeMember("AGXListOfPartModulesInGroup", BindingFlags.InvokeMethod | BindingFlags.Public | BindingFlags.Static, null, null, new System.Object[] { group });
        //    return RetActs;
        //}

        [KSPAction("Control From Here")]
        public void ControlFromHere(KSPActionParam param)
        {
            this.part.vessel.SetReferenceTransform(this.part);
        }
        [KSPAction("RCS On")]
        public void RCSOn(KSPActionParam param)
        {
            this.part.vessel.ActionGroups.SetGroup(KSPActionGroup.RCS, true);
        }
        [KSPAction("RCS Off")]
        public void RCSOff(KSPActionParam param)
        {
            this.part.vessel.ActionGroups.SetGroup(KSPActionGroup.RCS, false);
        }
        [KSPAction("SAS Off")]
        public void SASOff(KSPActionParam param)
        {
            this.part.vessel.ActionGroups.SetGroup(KSPActionGroup.SAS, false);
        }
        [KSPAction("SAS Steady")]
        public void SASSteady(KSPActionParam param)
        {
            if (this.part.vessel.Autopilot.CanSetMode(VesselAutopilot.AutopilotMode.StabilityAssist))
            {
                this.part.vessel.ActionGroups.SetGroup(KSPActionGroup.SAS, true);
                this.part.vessel.Autopilot.SetMode(VesselAutopilot.AutopilotMode.StabilityAssist);
                setSASUI(0);
            }
        }
        [KSPAction("SAS +Pro")]
        public void SASPrograde(KSPActionParam param)
        {
            if (this.part.vessel.Autopilot.CanSetMode(VesselAutopilot.AutopilotMode.Prograde))
            {
                //this.part.vessel.Autopilot.Enable(VesselAutopilot.AutopilotMode.Prograde);
                this.part.vessel.ActionGroups.SetGroup(KSPActionGroup.SAS, true);
                this.part.vessel.Autopilot.SetMode(VesselAutopilot.AutopilotMode.Prograde);
                setSASUI(1);
            }
        }
        [KSPAction("SAS -Pro")]
        public void SASRetrograde(KSPActionParam param)
        {
            if (this.part.vessel.Autopilot.CanSetMode(VesselAutopilot.AutopilotMode.Retrograde))
            {
                //this.part.vessel.Autopilot.Enable(VesselAutopilot.AutopilotMode.Retrograde);
                this.part.vessel.ActionGroups.SetGroup(KSPActionGroup.SAS, true);
                this.part.vessel.Autopilot.SetMode(VesselAutopilot.AutopilotMode.Retrograde);
                setSASUI(2);
            }
        }
        [KSPAction("SAS +Norm")]
        public void SASNormal(KSPActionParam param)
        {
            if (this.part.vessel.Autopilot.CanSetMode(VesselAutopilot.AutopilotMode.Normal))
            {
                this.part.vessel.ActionGroups.SetGroup(KSPActionGroup.SAS, true);
                this.part.vessel.Autopilot.SetMode(VesselAutopilot.AutopilotMode.Normal);
                setSASUI(3);
            }
        }
        [KSPAction("SAS -Norm")]
        public void SASAntinormal(KSPActionParam param)
        {
            if (this.part.vessel.Autopilot.CanSetMode(VesselAutopilot.AutopilotMode.Antinormal))
            {
                this.part.vessel.ActionGroups.SetGroup(KSPActionGroup.SAS, true);
                this.part.vessel.Autopilot.SetMode(VesselAutopilot.AutopilotMode.Antinormal);
                setSASUI(4);
            }
        }
        [KSPAction("SAS +Rad")]
        public void SASRadialIn(KSPActionParam param)
        {
            if (this.part.vessel.Autopilot.CanSetMode(VesselAutopilot.AutopilotMode.RadialIn))
            {
                this.part.vessel.ActionGroups.SetGroup(KSPActionGroup.SAS, true);
                this.part.vessel.Autopilot.SetMode(VesselAutopilot.AutopilotMode.RadialIn);
                setSASUI(5);
            }
        }
        [KSPAction("SAS -Rad")]
        public void SASRadialOut(KSPActionParam param)
        {
            if (this.part.vessel.Autopilot.CanSetMode(VesselAutopilot.AutopilotMode.RadialOut))
            {
                this.part.vessel.ActionGroups.SetGroup(KSPActionGroup.SAS, true);
                this.part.vessel.Autopilot.SetMode(VesselAutopilot.AutopilotMode.RadialOut);
                setSASUI(6);
            }
        }
        [KSPAction("SAS Maneuver")]
        public void SASManeuver(KSPActionParam param)
        {
            if (this.part.vessel.Autopilot.CanSetMode(VesselAutopilot.AutopilotMode.Maneuver))
            {
                this.part.vessel.ActionGroups.SetGroup(KSPActionGroup.SAS, true);
                this.part.vessel.Autopilot.SetMode(VesselAutopilot.AutopilotMode.Maneuver);
                setSASUI(9);
            }
        }
        [KSPAction("SAS Target")]
        public void SASTarget(KSPActionParam param)
        {
            if (this.part.vessel.Autopilot.CanSetMode(VesselAutopilot.AutopilotMode.Target))
            {
                this.part.vessel.ActionGroups.SetGroup(KSPActionGroup.SAS, true);
                this.part.vessel.Autopilot.SetMode(VesselAutopilot.AutopilotMode.Target);
                setSASUI(7);
            }
        }
        [KSPAction("SAS -Target")]
        public void SASAntitarget(KSPActionParam param)
        {
            if (this.part.vessel.Autopilot.CanSetMode(VesselAutopilot.AutopilotMode.AntiTarget))
            {
                this.part.vessel.ActionGroups.SetGroup(KSPActionGroup.SAS, true);
                this.part.vessel.Autopilot.SetMode(VesselAutopilot.AutopilotMode.AntiTarget);
                setSASUI(8);
            }
        }
        public void setSASUI(int mode)
        {
            RUIToggleButton[] SASbtns = FindObjectOfType<VesselAutopilotUI>().modeButtons;
            SASbtns.ElementAt<RUIToggleButton>(mode).SetTrue(true, true);
        }

    }
    public class ModuleControlSurfaceActions : PartModule
    {
        [KSPField(guiName = "NotShown", isPersistant = true, guiActiveEditor = false, guiActive = false)]
        public float FARpitch = 100f;
        [KSPField(guiName = "NotShown", isPersistant = true, guiActiveEditor = false, guiActive = false)]
        public float FARyaw = 100f;
        [KSPField(guiName = "NotShown", isPersistant = true, guiActiveEditor = false, guiActive = false)]
        public float FARroll = 100f;



        [KSPAction("Toggle Pitch")]
        public void TogglePitchAction(KSPActionParam param)
        {

            foreach (PartModule pm in this.part.Modules)
            {
                if (pm.moduleName == "ModuleControlSurface")
                {
                    ModuleControlSurface CS = (ModuleControlSurface)pm;
                    if (param.type == KSPActionType.Activate)
                    {
                        CS.ignorePitch = false;
                    }
                    else
                    {
                        CS.ignorePitch = true;
                    }
                }
                if (pm.moduleName == "FARControllableSurface")
                {
                    int i;
                    if (int.TryParse(pm.Fields.GetValue("pitchaxis").ToString(), out i)) //true if FAR installed, false if NEAR installed
                    {
                        if ((float)pm.Fields.GetValue("pitchaxis") != 0f)
                        {
                            FARpitch = (float)pm.Fields.GetValue("pitchaxis");
                        }
                        if (param.type == KSPActionType.Activate)
                        {
                            pm.Fields.SetValue("pitchaxis", FARpitch);
                        }
                        else
                        {
                            pm.Fields.SetValue("pitchaxis", 0f);
                        }
                    }
                    else
                    {
                        pm.Fields.SetValue("pitchaxis", !(bool)pm.Fields.GetValue("pitchaxis"));
                        //print("tog pitch" + pm.part.flightID.ToString());
                    }
                }
            }
        }
        [KSPAction("Enable Pitch")]
        public void EnablePitchAction(KSPActionParam param)
        {
            foreach (PartModule pm in this.part.Modules)
            {
                if (pm.moduleName == "ModuleControlSurface")
                {
                    ModuleControlSurface CS = (ModuleControlSurface)pm;
                    CS.ignorePitch = false;
                }
                if (pm.moduleName == "FARControllableSurface")
                {
                    int i;
                    if (int.TryParse(pm.Fields.GetValue("pitchaxis").ToString(), out i)) //true if FAR installed, false if NEAR installed
                    {
                        if ((float)pm.Fields.GetValue("pitchaxis") != 0f)
                        {
                            FARpitch = (float)pm.Fields.GetValue("pitchaxis");
                        }
                        pm.Fields.SetValue("pitchaxis", FARpitch);
                    }
                    else
                    {
                        pm.Fields.SetValue("pitchaxis", true);
                        //print("en pitch" + pm.part.flightID.ToString());
                    }
                }
            }

        }
        [KSPAction("Disable Pitch")]
        public void DisablePitchAction(KSPActionParam param)
        {
            foreach (PartModule pm in this.part.Modules)
            {
                if (pm.moduleName == "ModuleControlSurface")
                {
                    ModuleControlSurface CS = (ModuleControlSurface)pm;
                    CS.ignorePitch = true;
                }

                if (pm.moduleName == "FARControllableSurface")
                {
                    int i;
                    if (int.TryParse(pm.Fields.GetValue("pitchaxis").ToString(), out i)) //true if FAR installed, false if NEAR installed
                    {
                        if ((float)pm.Fields.GetValue("pitchaxis") != 0f)
                        {
                            FARpitch = (float)pm.Fields.GetValue("pitchaxis");
                        }
                        pm.Fields.SetValue("pitchaxis", 0f);
                    }
                    else
                    {
                        pm.Fields.SetValue("pitchaxis", false);
                        //print("dis pitch" + pm.part.flightID.ToString());

                    }
                }
            }
        }
        [KSPAction("Toggle Yaw")]
        public void ToggleYawAction(KSPActionParam param)
        {
            foreach (PartModule pm in this.part.Modules)
            {
                if (pm.moduleName == "ModuleControlSurface")
                {
                    ModuleControlSurface CS = (ModuleControlSurface)pm;
                    if (param.type == KSPActionType.Activate)
                    {
                        CS.ignoreYaw = false;
                    }
                    else
                    {
                        CS.ignoreYaw = true;
                    }
                }
                if (pm.moduleName == "FARControllableSurface")
                {
                    int i;
                    if (int.TryParse(pm.Fields.GetValue("yawaxis").ToString(), out i)) //true if FAR installed, false if NEAR installed
                    {
                        if ((float)pm.Fields.GetValue("yawaxis") != 0f)
                        {
                            FARyaw = (float)pm.Fields.GetValue("yawaxis");
                        }
                        if (param.type == KSPActionType.Activate)
                        {
                            pm.Fields.SetValue("yawaxis", FARyaw);
                        }
                        else
                        {
                            pm.Fields.SetValue("yawaxis", 0f);
                        }
                    }
                    else
                    {
                        pm.Fields.SetValue("yawaxis", !(bool)pm.Fields.GetValue("yawaxis"));
                    }
                }

            }
        }
        [KSPAction("Enable Yaw")]
        public void EnableYawAction(KSPActionParam param)
        {
            foreach (PartModule pm in this.part.Modules)
            {
                if (pm.moduleName == "ModuleControlSurface")
                {
                    ModuleControlSurface CS = (ModuleControlSurface)pm;
                    CS.ignoreYaw = false;
                }
                if (pm.moduleName == "FARControllableSurface")
                {

                    int i;
                    if (int.TryParse(pm.Fields.GetValue("yawaxis").ToString(), out i)) //true if FAR installed, false if NEAR installed
                    {
                        if ((float)pm.Fields.GetValue("yawaxis") != 0f)
                        {
                            FARyaw = (float)pm.Fields.GetValue("yawaxis");
                        }
                        pm.Fields.SetValue("yawaxis", FARyaw);
                    }
                    else
                    {
                        pm.Fields.SetValue("yawaxis", true);
                    }
                }
            }

        }
        [KSPAction("Disable Yaw")]
        public void DisableYawAction(KSPActionParam param)
        {
            foreach (PartModule pm in this.part.Modules)
            {
                if (pm.moduleName == "ModuleControlSurface")
                {
                    ModuleControlSurface CS = (ModuleControlSurface)pm;
                    CS.ignoreYaw = true;
                }
                if (pm.moduleName == "FARControllableSurface")
                {
                    int i;
                    if (int.TryParse(pm.Fields.GetValue("yawaxis").ToString(), out i)) //true if FAR installed, false if NEAR installed
                    {
                        if ((float)pm.Fields.GetValue("yawaxis") != 0f)
                        {
                            FARyaw = (float)pm.Fields.GetValue("yawaxis");
                        }
                        pm.Fields.SetValue("yawaxis", 0f);
                    }
                    else
                    {
                        pm.Fields.SetValue("yawaxis", false);
                    }
                }
            }
        }
        [KSPAction("Toggle Roll")]
        public void ToggleRollAction(KSPActionParam param)
        {
            foreach (PartModule pm in this.part.Modules)
            {
                if (pm.moduleName == "ModuleControlSurface")
                {
                    ModuleControlSurface CS = (ModuleControlSurface)pm;
                    if (param.type == KSPActionType.Activate)
                    {
                        CS.ignoreRoll = false;
                    }
                    else
                    {
                        CS.ignoreRoll = true;
                    }
                }
                if (pm.moduleName == "FARControllableSurface")
                {

                    int i;
                    if (int.TryParse(pm.Fields.GetValue("rollaxis").ToString(), out i)) //true if FAR installed, false if NEAR installed
                    {
                        if ((float)pm.Fields.GetValue("rollaxis") != 0f)
                        {
                            FARroll = (float)pm.Fields.GetValue("rollaxis");
                        }
                        if (param.type == KSPActionType.Activate)
                        {
                            pm.Fields.SetValue("rollaxis", FARroll);
                        }
                        else
                        {
                            pm.Fields.SetValue("rollaxis", 0f);
                        }
                    }
                    else
                    {
                        pm.Fields.SetValue("rollaxis", !(bool)pm.Fields.GetValue("rollaxis"));
                    }
                }
            }
        }
        [KSPAction("Enable Roll")]
        public void EnableRollAction(KSPActionParam param)
        {
            foreach (PartModule pm in this.part.Modules)
            {
                if (pm.moduleName == "ModuleControlSurface")
                {
                    ModuleControlSurface CS = (ModuleControlSurface)pm;
                    CS.ignoreRoll = false;
                }
                if (pm.moduleName == "FARControllableSurface")
                {
                    int i;
                    if (int.TryParse(pm.Fields.GetValue("rollaxis").ToString(), out i)) //true if FAR installed, false if NEAR installed
                    {
                        if ((float)pm.Fields.GetValue("rollaxis") != 0f)
                        {
                            FARroll = (float)pm.Fields.GetValue("rollaxis");
                        }
                        pm.Fields.SetValue("rollaxis", FARroll);
                    }
                    else
                    {
                        pm.Fields.SetValue("rollaxis", true);
                    }

                }

            }
        }
        [KSPAction("Disable Roll")]
        public void DisableRollAction(KSPActionParam param)
        {
            foreach (PartModule pm in this.part.Modules)
            {
                if (pm.moduleName == "ModuleControlSurface")
                {
                    ModuleControlSurface CS = (ModuleControlSurface)pm;
                    CS.ignoreRoll = true;
                }
                if (pm.moduleName == "FARControllableSurface")
                {
                    int i;
                    if (int.TryParse(pm.Fields.GetValue("rollaxis").ToString(), out i)) //true if FAR installed, false if NEAR installed
                    {
                        if ((float)pm.Fields.GetValue("rollaxis") != 0f)
                        {
                            FARroll = (float)pm.Fields.GetValue("rollaxis");
                        }
                        pm.Fields.SetValue("rollaxis", 0f);
                    }
                    else
                    {
                        pm.Fields.SetValue("rollaxis", false);
                    }
                }
            }
        }
    }
    public class ModuleGoEvaActions : PartModule
    {
        [KSPAction("Go on EVA")]
        public void KerbalOnEVA(KSPActionParam param)
        {
            bool kerbalFound = false;
            Kerbal kerbalToEva = null;
            foreach (InternalSeat iseat in this.part.internalModel.seats)
            {
                if (iseat.taken && !kerbalFound)
                {
                    kerbalToEva = iseat.kerbalRef;
                    kerbalFound = true;
                }
            }
            if (kerbalFound)
            {
                FlightEVA.SpawnEVA(kerbalToEva);
            }
            else
            {
                ScreenMessages.PostScreenMessage("No Kerbal found on this part", 10F, ScreenMessageStyle.UPPER_CENTER);
            }

        }
    }
    public class ModuleFuelCrossfeedActions : PartModule
    {
        [KSPField(guiActive = false, guiActiveEditor = false, isPersistant = true)]
        public bool setupRun = false;

        [KSPField(guiActive = false, guiActiveEditor = false, isPersistant = true)]
        public bool allowCrossfeed = false;

        [KSPEvent(guiActive = true, guiActiveEditor = true, guiName = "Crossfeeding")]
        public void ToggleCrossfeedEvent()
        {
            allowCrossfeed = !allowCrossfeed;
            SetCrossfeedValue();
        }

        [KSPAction("Toggle Crossfeed")]
        public void ToggleCrossfeed(KSPActionParam param)
        {
            allowCrossfeed = !allowCrossfeed;
            SetCrossfeedValue();
        }
        [KSPAction("Enable Crossfeed")]
        public void EnableCrossfeed(KSPActionParam param)
        {
            allowCrossfeed = true;
            SetCrossfeedValue();
        }
        [KSPAction("Disable Crossfeed")]
        public void DisableCrossfeed(KSPActionParam param)
        {
            allowCrossfeed = false;
            SetCrossfeedValue();
        }

        public void DoSetup()
        {
            allowCrossfeed = this.part.fuelCrossFeed;
            setupRun = true;
            SetCrossfeedValue();
        }

        public override void OnStart(StartState state)
        {
            if (!setupRun)
            {
                DoSetup();
            }
            else
            {
                SetCrossfeedValue();
            }
        }
        public void OnLoad(ConfigNode node)
        {
            if (!setupRun)
            {
                DoSetup();
            }
            else
            {
                SetCrossfeedValue();
            }
        }
        public void Load(ConfigNode node)
        {
            if (!setupRun)
            {
                DoSetup();
            }
            else
            {
                SetCrossfeedValue();
            }
        }
        public void OnInitialize()
        {
            if (!setupRun)
            {
                DoSetup();
            }
            else
            {
                SetCrossfeedValue();
            }
        }
        public void SetCrossfeedValue()
        {
            this.part.fuelCrossFeed = allowCrossfeed;
            if (allowCrossfeed)
            {
                this.Events["ToggleCrossfeedEvent"].guiName = "Crossfeed: On";
            }
            else
            {
                this.Events["ToggleCrossfeedEvent"].guiName = "Crossfeed: Off";
            }
        }
    }
    public class ModuleResourceActions : PartModule
    {
        [KSPField(guiActive = false, guiActiveEditor = false, isPersistant = true)]
        public bool setupRun = false;

        [KSPField(guiActive = false, guiActiveEditor = false, isPersistant = true)]
        public bool lockResource = false;

        [KSPField(guiActive = false, guiActiveEditor = false, isPersistant = true)]
        public bool lockEC = false;

        [KSPField(guiActive = false, guiActiveEditor = false, isPersistant = true)]
        public bool showRes = false;

        [KSPField(guiActive = false, guiActiveEditor = false, isPersistant = true)]
        public bool showEC = false;

        public PartResource.FlowMode resFlowMode = PartResource.FlowMode.Both;
        public PartResource.FlowMode ecFlowMode = PartResource.FlowMode.Both;

        [KSPEvent(guiActive = true, guiActiveEditor = true, guiName = "Resource Lock")]
        public void ToggleResourceEvent()
        {
            lockResource = !lockResource;
            SetResourceFlow();
        }
        [KSPEvent(guiActive = true, guiActiveEditor = true, guiName = "Elec Charge Lock")]
        public void ToggleElectricityEvent()
        {
            lockEC = !lockEC;
            SetResourceFlow();
        }

        [KSPAction("Toggle Resource")]
        public void ToggleResource(KSPActionParam param)
        {
            lockResource = !lockResource;
            SetResourceFlow();
        }
        [KSPAction("Allow Resource")]
        public void EnableResource(KSPActionParam param)
        {
            lockResource = false;
            SetResourceFlow();
        }
        [KSPAction("Lock Resource")]
        public void DisableResource(KSPActionParam param)
        {
            lockResource = true;
            SetResourceFlow();
        }
        [KSPAction("Toggle Electricity")]
        public void ToggleElec(KSPActionParam param)
        {
            lockEC = !lockEC;
            SetResourceFlow();
        }
        [KSPAction("Allow Electricity")]
        public void EnableElec(KSPActionParam param)
        {
            lockEC = false;
            SetResourceFlow();
        }
        [KSPAction("Lock Electricity")]
        public void DisableElec(KSPActionParam param)
        {
            lockEC = true;
            SetResourceFlow();
        }



        public void DoSetup()
        {
            lockResource = false;
            lockEC = false;
            if (this.part.Resources.Contains("ElectricCharge"))
            {
                showEC = true;
            }
            else
            {
                showEC = false;
            }
            if (this.part.Resources.Contains("ElectricCharge") && this.part.Resources.Count >= 2 || !this.part.Resources.Contains("ElectricCharge") && this.part.Resources.Count >= 1)
            {
                showRes = true;
            }
            else
            {
                showRes = false;
            }
            setupRun = true;
            SetResourceFlow();

        }

        public override void OnStart(StartState state)
        {
            if (!setupRun)
            {
                DoSetup();
            }
            else
            {
                SetResourceFlow();
            }
        }
        public void OnLoad(ConfigNode node)
        {
            if (!setupRun)
            {
                DoSetup();
            }
            else
            {
                SetResourceFlow();
            }
        }
        public void Load(ConfigNode node)
        {
            if (!setupRun)
            {
                DoSetup();
            }
            else
            {
                SetResourceFlow();
            }
        }
        //public void OnInitialize()
        //{
        //    if (!setupRun)
        //    {
        //        DoSetup();
        //    }
        //    else
        //    {
        //        SetResourceFlow();
        //    }
        //}
        public void SetResourceFlow()
        {
            //print("Check " + showEC + showRes);    
            foreach (PartResource pr in this.part.Resources)
            {
                if (pr.resourceName != "ElectricCharge")
                {
                    if (lockResource)
                    {
                        pr.flowMode = PartResource.FlowMode.None;
                    }
                    else
                    {
                        pr.flowMode = PartResource.FlowMode.Both;
                    }
                }
                else if (pr.resourceName == "ElectricCharge")
                {
                    if (lockEC)
                    {
                        pr.flowMode = PartResource.FlowMode.None;
                    }
                    else
                    {
                        pr.flowMode = PartResource.FlowMode.Both;
                    }
                }
            }

            if (showRes)
            {
                this.Actions["ToggleResource"].active = true;
                this.Actions["EnableResource"].active = true;
                this.Actions["DisableResource"].active = true;
                this.Events["ToggleResourceEvent"].active = true;
                this.Events["ToggleResourceEvent"].guiActive = true;
                if (lockResource)
                {
                    this.Events["ToggleResourceEvent"].guiName = "Resource Lock: On";
                }
                else
                {
                    this.Events["ToggleResourceEvent"].guiName = "Resource Lock: Off";
                }
            }
            else
            {
                this.Actions["ToggleResource"].active = false;
                this.Actions["EnableResource"].active = false;
                this.Actions["DisableResource"].active = false;
                this.Events["ToggleResourceEvent"].guiActive = false;
                this.Events["ToggleResourceEvent"].active = false;
            }
            if (showEC)
            {
                this.Actions["ToggleElec"].active = true;
                this.Actions["EnableElec"].active = true;
                this.Actions["DisableElec"].active = true;
                this.Events["ToggleElectricityEvent"].active = true;
                this.Events["ToggleElectricityEvent"].guiActive = true;
                if (lockEC)
                {
                    this.Events["ToggleElectricityEvent"].guiName = "Electricity Lock: On";
                }
                else
                {
                    this.Events["ToggleElectricityEvent"].guiName = "Electricity Lock: Off";
                }
            }
            else
            {
                this.Actions["ToggleElec"].active = false;
                this.Actions["EnableElec"].active = false;
                this.Actions["DisableElec"].active = false;
                this.Events["ToggleElectricityEvent"].guiActive = false;
                this.Events["ToggleElectricityEvent"].active = false;
            }
        }
    }
    public class ModuleWheelActions : PartModule
    {
        [KSPAction("Add/Rem Brakes")]
        public void AddRemBrakes(KSPActionParam param)
        {
            foreach (ModuleWheel mWheel in this.part.Modules.OfType<ModuleWheel>())
            {
                BaseAction whlBrakes = mWheel.Actions.Find(ba => ba.name == "BrakesAction");
                if ((whlBrakes.actionGroup & KSPActionGroup.Brakes) == KSPActionGroup.Brakes)
                {
                    whlBrakes.actionGroup &= ~KSPActionGroup.Brakes;
                }
                else
                {
                    whlBrakes.actionGroup = whlBrakes.actionGroup | KSPActionGroup.Brakes;
                }
            }
        }
        [KSPAction("Add Brakes")]
        public void AddBrakes(KSPActionParam param)
        {
            foreach (ModuleWheel mWheel in this.part.Modules.OfType<ModuleWheel>())
            {
                BaseAction whlBrakes = mWheel.Actions.Find(ba => ba.name == "BrakesAction");
                whlBrakes.actionGroup = whlBrakes.actionGroup | KSPActionGroup.Brakes;
            }
        }
        [KSPAction("Remove Brakes")]
        public void RemBrakes(KSPActionParam param)
        {
            foreach (ModuleWheel mWheel in this.part.Modules.OfType<ModuleWheel>())
            {
                BaseAction whlBrakes = mWheel.Actions.Find(ba => ba.name == "BrakesAction");
                whlBrakes.actionGroup &= ~KSPActionGroup.Brakes;
            }
        }
    }
    public class ModuleScienceLabActions : PartModule
    {
        [KSPAction("Clean Experiments")]
        public void CleanExperiments(KSPActionParam param)
        {
            foreach (ModuleScienceLab sciLab in this.part.Modules.OfType<ModuleScienceLab>())
            {
                sciLab.CleanModulesEvent();
            }
        }
    }
}
