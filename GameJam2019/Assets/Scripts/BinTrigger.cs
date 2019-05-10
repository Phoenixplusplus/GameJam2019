using UnityEngine;

public class BinTrigger : MonoBehaviour
{
    [SerializeField]
    private Bin bin;

    private void OnTriggerEnter(Collider other)
    {
        Rubbish rubbish = other.gameObject.GetComponent<Rubbish>();
        if (rubbish != null)
        {
            bin.PickupRubbish(rubbish);
        }
    }
}
