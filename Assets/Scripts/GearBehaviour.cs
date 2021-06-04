using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearBehaviour : MonoBehaviour
{
    public Animator wielderAnimator;
    protected GearType gearType;
    protected BoxCollider physicsBoxCollider;
    protected CapsuleCollider triggerCapsuleCollider;
    protected Rigidbody rb;
    protected PickupBehaviour pickupBehaviour;

    public GearType GetGearHandType
    {
        get
        {
            return gearType;
        }
    }

    protected virtual void Start()
    {
        gearType = GearType.TwoHanded;
        physicsBoxCollider = GetComponentInChildren<BoxCollider>();
        triggerCapsuleCollider = GetComponent<CapsuleCollider>();
        rb = GetComponent<Rigidbody>();
        pickupBehaviour = GetComponent<PickupBehaviour>();
    }

    public virtual void LeftHandActionPress()
    {

    }
    public virtual void RightHandActionPress()
    {

    }

    public virtual void LeftHandActionHold()
    {

    }
    public virtual void RightHandActionHold()
    {

    }
    public virtual void LeftHandActionRelease()
    {

    }
    public virtual void RightHandActionRelease()
    {

    }

    public virtual void OnEquip(GameObject equipperGO, GameObject socketToParentTo)
    {
        pickupBehaviour.pickupDisabled = true;
        physicsBoxCollider.enabled = false;
        //triggerCapsuleCollider.enabled = false;
        rb.isKinematic = true;
        rb.useGravity = false;

        wielderAnimator = equipperGO.GetComponent<Animator>();

        this.gameObject.transform.SetParent(socketToParentTo.transform);
        this.gameObject.transform.localPosition = Vector3.zero;
        this.gameObject.transform.localRotation = Quaternion.identity;
    }

    public virtual void OnUnequip()
    {
        this.gameObject.transform.SetParent(null);
        physicsBoxCollider.enabled = true;
        //triggerCapsuleCollider.enabled = true;
        rb.isKinematic = false;
        rb.useGravity = true;
        rb.AddForce(Camera.main.transform.forward * 10, ForceMode.Impulse);
        Invoke("EnablePickupBehaviour", 1f);
    }

    void EnablePickupBehaviour()
    {
        pickupBehaviour.pickupDisabled = false;
    }
    public enum GearType { LeftHanded, RightHanded, TwoHanded }
}
