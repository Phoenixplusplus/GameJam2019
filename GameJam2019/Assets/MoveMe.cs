﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMe : MonoBehaviour, IMoveable<Vector3>
{
    [SerializeField]
    private Rigidbody RB;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>();
    }

    public void MoveBy(Vector3 disp)
    {
        Debug.Log("Move CAr by" + disp.ToString());
        RB.isKinematic = true;
        transform.Translate(disp);
        RB.isKinematic = false;

    }

}

