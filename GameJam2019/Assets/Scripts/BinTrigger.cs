using UnityEngine;

public class BinTrigger : MonoBehaviour
{
    [SerializeField]
    private Bin bin;

    private void OnTriggerEnter(Collider other)
    {
        RubbishMovement rm = other.gameObject.GetComponent<RubbishMovement>();
        if (rm != null)
        {
            bin.PickupRubbish(rm.gameObject);
        }
    }
}
