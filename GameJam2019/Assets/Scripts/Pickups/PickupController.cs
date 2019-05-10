using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : MonoBehaviour
{
    [SerializeField]
    private AbstractPickup abstractPickup;

    private bool destroying = false;

    private void OnCollisionEnter(Collision collision)
    {
        if(!destroying)
        {
            PickupEffectsController pec = collision.gameObject.GetComponent<PickupEffectsController>();
            if(pec != null)
            {
                pec.AddPickup(new PickupReference(abstractPickup));
                destroying = true;
                Destroy(gameObject);
            }
        }
    }
}
