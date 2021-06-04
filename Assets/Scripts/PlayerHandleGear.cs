using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandleGear : MonoBehaviour
{
    public HandSocketManager rightHandSocket, leftHandSocket;

    private void Start()
    {
        foreach(HandSocketManager hand in GetComponentsInChildren<HandSocketManager>())
        {
            if (hand.GetHand == HandSocketManager.Hand.LeftHand)
                leftHandSocket = hand;
            else if (hand.GetHand == HandSocketManager.Hand.RightHand)
                rightHandSocket = hand;
        }
    }
    void Update()
    {
        HandleGearUsage();
    }

    void HandleGearUsage()
    {
        if (leftHandSocket == null || rightHandSocket == null)
            return;

        if (Input.GetButtonDown("Fire1"))
            rightHandSocket.ExecuteWeaponPressAction();
        else if (Input.GetButton("Fire1"))
            rightHandSocket.ExecuteWeaponHeldAction();
        else if (Input.GetButtonUp("Fire1"))
            rightHandSocket.ExecuteWeaponReleaseAction();

        if (Input.GetButtonDown("Fire2"))
            leftHandSocket.ExecuteWeaponPressAction();
        else if (Input.GetButton("Fire2"))
            leftHandSocket.ExecuteWeaponHeldAction();
        else if (Input.GetButtonUp("Fire2"))
            leftHandSocket.ExecuteWeaponReleaseAction();
    }

    public void EquipGear(GameObject gearToEquip)
    {
        GearBehaviour gearBehaviour = gearToEquip.GetComponent<GearBehaviour>();

        if (gearBehaviour == null)
            return;

        switch (gearBehaviour.GetGearHandType)
        {
            case GearBehaviour.GearType.TwoHanded:
                DropGear(HandSocketManager.Hand.LeftHand);
                DropGear(HandSocketManager.Hand.RightHand);
                EquipTwoHanded(gearBehaviour);
                break;
            case GearBehaviour.GearType.LeftHanded:
                DropGear(HandSocketManager.Hand.LeftHand);
                EquipOneHanded(gearBehaviour, HandSocketManager.Hand.LeftHand);
                break;
            case GearBehaviour.GearType.RightHanded:
                DropGear(HandSocketManager.Hand.RightHand);
                EquipOneHanded(gearBehaviour, HandSocketManager.Hand.RightHand);
                break;
        }
    }

    void EquipTwoHanded(GearBehaviour gear)
    {
        gear.OnEquip(this.gameObject, rightHandSocket.gameObject);

        rightHandSocket.currentGear = gear;
        leftHandSocket.currentGear = gear;
    }

    void EquipOneHanded(GearBehaviour gear, HandSocketManager.Hand handToEquipTo)
    {

        switch (handToEquipTo)
        {
            case HandSocketManager.Hand.LeftHand:
                gear.OnEquip(this.gameObject, leftHandSocket.gameObject);
                leftHandSocket.currentGear = gear;
                break;
            case HandSocketManager.Hand.RightHand:
                gear.OnEquip(this.gameObject, rightHandSocket.gameObject);
                rightHandSocket.currentGear = gear;
                break;
        }
    }

    public void DropGear(HandSocketManager.Hand handToDropGear)
    {
        if ((handToDropGear == HandSocketManager.Hand.RightHand && rightHandSocket.currentGear == null) || (handToDropGear == HandSocketManager.Hand.LeftHand && leftHandSocket.currentGear == null))
            return;

        switch (handToDropGear)
        {
            case HandSocketManager.Hand.RightHand:
                if (rightHandSocket.currentGear.GetGearHandType == GearBehaviour.GearType.TwoHanded)
                    DropTwoHanded();
                else
                    DropOneHanded(rightHandSocket);
                break;
            case HandSocketManager.Hand.LeftHand:
                if (leftHandSocket.currentGear.GetGearHandType == GearBehaviour.GearType.TwoHanded)
                    DropTwoHanded();
                else
                    DropOneHanded(leftHandSocket);
                break;

        }
    }

    void DropTwoHanded()
    {
        rightHandSocket.currentGear.OnUnequip();
        rightHandSocket.currentGear = null;
        leftHandSocket.currentGear = null;
    }

    void DropOneHanded(HandSocketManager handSocketToManage)
    {
        handSocketToManage.currentGear.OnUnequip();
        handSocketToManage.currentGear = null;
    }
}
