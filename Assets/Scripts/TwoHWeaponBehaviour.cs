using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoHWeaponBehaviour : GearBehaviour
{
    public string leftHandPressTriggerName, rightHandPressTriggerName, leftHandHeldTriggerName, rightHandHeldTriggerName, leftHandReleaseTriggerName, rightHandReleaseTriggerName;

    protected override void Start()
    {
        base.Start();
        gearType =  GearType.TwoHanded;
    }

    public override void LeftHandActionPress()
    {
        Debug.Log("left press");
    }
    public override void RightHandActionPress()
    {

        Debug.Log("right press");
    }

    public override void LeftHandActionHold()
    {

        Debug.Log("left hold");
    }

    public override void RightHandActionHold()
    {

        Debug.Log("right hold");
    }
    public override void LeftHandActionRelease()
    {

        Debug.Log("left release");
    }

    public override void RightHandActionRelease()
    {
        Debug.Log("right release");
        wielderAnimator.SetTrigger(rightHandReleaseTriggerName);
    }
}
