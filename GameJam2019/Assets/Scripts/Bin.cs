using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bin : MonoBehaviour
{
    [SerializeField]
    private MeshRenderer circularOutlineMeshRenderer;

    [SerializeField]
    private Color collectionOutlineColor;

    [SerializeField]
    private float colorAnimationTime = 1.0f;

    [SerializeField]
    private AnimationCurve animationCurve;
    
    private Material outlineMaterial;
    private float timePerAnimation;

    #region Unity API
    private void Awake()
    {
        outlineMaterial = circularOutlineMeshRenderer.material;
        timePerAnimation = colorAnimationTime * 0.5f;
    }
    #endregion

    public void PickupRubbish(GameObject pickedUpObject)
    {
        Destroy(pickedUpObject);
        StartCoroutine(AnimateOutline());
        // Trigger score
        Debug.Log("Bin just collected some rubbish!");
    }

    private IEnumerator AnimateOutline()
    {
        float timeElapsed = 0.0f;
        float curveSample = 0.0f;
        Color initialColor = outlineMaterial.color;

        while (timeElapsed < colorAnimationTime)
        {
            curveSample = animationCurve.Evaluate(timeElapsed / timePerAnimation);
            outlineMaterial.color = Color.Lerp(initialColor, collectionOutlineColor, curveSample);

            yield return null;
            timeElapsed += Time.deltaTime;
        }
    }

    private IEnumerator AnimatePickup()
    {
        float timeElapsed = 0.0f;

        yield return null;
    }

}
