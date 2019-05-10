using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bin : MonoBehaviour
{
    [SerializeField]
    private MeshRenderer circularOutlineMeshRenderer;


    public void PickupRubbish(GameObject pickedUpObject)
    {
        Destroy(pickedUpObject);
        // Trigger score
        Debug.Log("Bin just collected some rubbish!");
    }

    private IEnumerator AnimateOutline()
    {
        const float totalTime = 3.0f;
        float timeElapsed = 0.0f;

        while(timeElapsed < totalTime)
        {
            yield return null;
        }
        
    }

}
