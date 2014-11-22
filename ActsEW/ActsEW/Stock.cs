using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
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
    public class ModuleControlSurfaceActions : PartModule
    {
        [KSPAction("Toggle Pitch")]
        public void TogglePitchAction(KSPActionParam param)
        {
            foreach (ModuleControlSurface pm in this.part.Modules.OfType<ModuleControlSurface>())
            {
                pm.ignorePitch = !pm.ignorePitch;
            }
        }
        [KSPAction("Enable Pitch")]
        public void EnablePitchAction(KSPActionParam param)
        {
            foreach (ModuleControlSurface pm in this.part.Modules.OfType<ModuleControlSurface>())
            {
                pm.ignorePitch = false;
            }
        }
        [KSPAction("Disable Pitch")]
        public void DisablePitchAction(KSPActionParam param)
        {
            foreach (ModuleControlSurface pm in this.part.Modules.OfType<ModuleControlSurface>())
            {
                pm.ignorePitch = true;
            }
        }
        [KSPAction("Toggle Yaw")]
        public void ToggleYawAction(KSPActionParam param)
        {
            foreach (ModuleControlSurface pm in this.part.Modules.OfType<ModuleControlSurface>())
            {
                pm.ignoreYaw = !pm.ignoreYaw;
            }
        }
        [KSPAction("Enable Yaw")]
        public void EnableYawAction(KSPActionParam param)
        {
            foreach (ModuleControlSurface pm in this.part.Modules.OfType<ModuleControlSurface>())
            {
                pm.ignoreYaw = false;
            }
        }
        [KSPAction("Disable Yaw")]
        public void DisableYawAction(KSPActionParam param)
        {
            foreach (ModuleControlSurface pm in this.part.Modules.OfType<ModuleControlSurface>())
            {
                pm.ignoreYaw = true;
            }
        }
        [KSPAction("Toggle Roll")]
        public void ToggleRollAction(KSPActionParam param)
        {
            foreach (ModuleControlSurface pm in this.part.Modules.OfType<ModuleControlSurface>())
            {
                pm.ignoreRoll = !pm.ignoreRoll;
            }
        }
        [KSPAction("Enable Roll")]
        public void EnableRollAction(KSPActionParam param)
        {
            foreach (ModuleControlSurface pm in this.part.Modules.OfType<ModuleControlSurface>())
            {
                pm.ignoreRoll = false;
            }
        }
        [KSPAction("Disable Roll")]
        public void DisableRollAction(KSPActionParam param)
        {
            foreach (ModuleControlSurface pm in this.part.Modules.OfType<ModuleControlSurface>())
            {
                pm.ignoreRoll = true;
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
            foreach(InternalSeat iseat in this.part.internalModel.seats)
            {
                if(iseat.taken && !kerbalFound)
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
        [KSPField(guiActive = false,guiActiveEditor = false,isPersistant = true)]
        public bool setupRun = false;

        [KSPField(guiActive = false, guiActiveEditor = false, isPersistant = true)]
        public bool allowCrossfeed = false;

        [KSPEvent(guiActive = true, guiActiveEditor = true,guiName = "Crossfeeding")]
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
            if(!setupRun)
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
        [KSPAction("Enable Resource")]
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
        [KSPAction("Enable Electricity")]
        public void EnableElec(KSPActionParam param)
        {
            lockEC = false;
            SetResourceFlow();
        }
        [KSPAction("Disable Electricity")]
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
            if (this.part.Resources.Contains("ElectricCharge") && this.part.Resources.Count >= 2 || !this.part.Resources.Contains("ElectricCharge") && this.part.Resources.Count >= 1 )
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
            print("Check " + showEC + showRes);    
            foreach (PartResource pr in this.part.Resources)
                {
                    if(pr.resourceName != "ElectricCharge")
                    {
                        if(lockResource)
                        {
                            pr.flowMode = PartResource.FlowMode.None;
                        }
                        else
                        {
                            pr.flowMode = PartResource.FlowMode.Both;
                        }
                    }
                    else if(pr.resourceName == "ElectricCharge")
                    {
                        if(lockEC)
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
            foreach(ModuleWheel mWheel in this.part.Modules.OfType<ModuleWheel>())
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
    
}
