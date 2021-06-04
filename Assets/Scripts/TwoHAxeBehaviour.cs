using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoHAxeBehaviour : TwoHWeaponBehaviour
{
    public override void LeftHandActionPress()
    {
        base.LeftHandActionPress();
        wielderAnimator.SetTrigger(leftHandPressTriggerName);
    }

    public override void LeftHandActionRelease()
    {
        base.LeftHandActionRelease();
        wielderAnimator.ResetTrigger(leftHandPressTriggerName);
    }

}
