using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBehaviour : MonoBehaviour
{
    public bool pickupDisabled = false;
    private void OnTriggerEnter(Collider other)
    {
        if (pickupDisabled)
            return;

        if (other.gameObject.GetComponent<PlayerHandleGear>() == null)
            return;

        other.gameObject.GetComponent<PlayerHandleGear>().EquipGear(this.gameObject);
    }
}
