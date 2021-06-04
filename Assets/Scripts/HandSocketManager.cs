using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandSocketManager : MonoBehaviour
{
    [SerializeField]
    Hand hand;
    public GearBehaviour currentGear;

    public Hand GetHand
    {
        get
        {
            return hand;
        }
    }

    public void ExecuteWeaponPressAction()
    {
        if (currentGear == null)
            return;

        switch (hand)
        {
            case Hand.LeftHand:
                currentGear.LeftHandActionPress();
                break;
            case Hand.RightHand:
                currentGear.RightHandActionPress();
                break;
        }
    }
    public void ExecuteWeaponHeldAction()
    {
        if (currentGear == null)
            return;

        switch (hand)
        {
            case Hand.LeftHand:
                currentGear.LeftHandActionHold();
                break;
            case Hand.RightHand:
                currentGear.RightHandActionHold();
                break;
        }
    }
    public void ExecuteWeaponReleaseAction()
    {
        if (currentGear == null)
            return;

        switch (hand)
        {
            case Hand.LeftHand:
                currentGear.LeftHandActionRelease();
                break;
            case Hand.RightHand:
                currentGear.RightHandActionRelease();
                break;
        }
    }

    public enum Hand{ LeftHand, RightHand };
}
