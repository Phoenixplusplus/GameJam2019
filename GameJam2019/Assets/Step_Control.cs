using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Step_Control : MonoBehaviour
{
    public float cutoff = 1f;
    public float ForceMultiplier = 1;
    [SerializeField]
    private Vector3 MyDisp;
    [SerializeField]
    private Vector3 OldPos;

    void Start ()
    {
        MyDisp = Vector3.zero;
        OldPos = transform.position;
    }

    void Update()
    {
        MyDisp = transform.position - OldPos;
        if (MyDisp.sqrMagnitude > cutoff)
        {
            MyDisp = Vector3.zero;
        }
        OldPos = transform.position;

    }

    private void OnCollisionStay(Collision collision)
    {
        //IMoveable<Vector3> thing = collision as IMoveable<Vector3>;

        IMoveable<Vector3> thing = collision.gameObject.GetComponent<IMoveable<Vector3>>();

        if (thing != null)
        {
            thing.MoveBy(MyDisp * ForceMultiplier);
        }
        Debug.Log("Still Here");
    }

    private void OnCollisionEnter(Collision collision)
    {
        IMoveable<Vector3> thing = collision.gameObject.GetComponent<IMoveable<Vector3>>();

        if (thing != null)
        {
            thing.MoveBy(MyDisp * ForceMultiplier);
        }
        Debug.Log("Boing");
    }





}
