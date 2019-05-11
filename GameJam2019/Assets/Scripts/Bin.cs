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

    [SerializeField]
    private ParticleSystem particleSystem;

    [SerializeField]
    private Transform pickupHeight;

    [SerializeField]
    private Transform targetDrop;
    
    private Material outlineMaterial;
    private float timePerAnimation;

    private AudioSource audioSource;

    #region Unity API
    private void Awake()
    {
        outlineMaterial = circularOutlineMeshRenderer.material;
        timePerAnimation = colorAnimationTime * 0.5f;
        audioSource = GetComponent<AudioSource>();
    }
    #endregion

    public void PickupRubbish(Rubbish rubbish)
    {
        rubbish.enabled = false; // disable the rubbish so that the last touching player registers as the rewarded player
        rubbish.gameObject.GetComponent<Collider>().enabled = false;

        audioSource.Play();

        StartCoroutine(AnimateOutline());
        StartCoroutine(AnimatePickup(rubbish.gameObject));
        // Trigger score
        Debug.Log("Bin just collected some rubbish!");
    }

    private IEnumerator AnimateOutline()
    {
        float timeElapsed = 0.0f;
        float curveSample = 0.0f;
        Color initialColor = outlineMaterial.color;

        particleSystem.Play();

        while (timeElapsed < colorAnimationTime)
        {
            curveSample = animationCurve.Evaluate(timeElapsed / timePerAnimation);
            outlineMaterial.color = Color.Lerp(initialColor, collectionOutlineColor, curveSample);

            yield return null;
            timeElapsed += Time.deltaTime;
        }
        particleSystem.Stop();
    }

    private IEnumerator AnimatePickup(GameObject pickupObject)
    {
        float timeElapsed = 0.0f;
        float pickupTime = 1.0f;
        float dropTime = 0.5f;

        Vector3 targetPosition = pickupObject.transform.position;
        Vector3 startPosition = pickupObject.transform.position;
        targetPosition.y = pickupHeight.position.y;

        while(timeElapsed < pickupTime)
        {
            pickupObject.transform.position = Vector3.Lerp(startPosition, targetPosition, timeElapsed / pickupTime);

            yield return null;
            timeElapsed += Time.deltaTime;
        }

        pickupObject.transform.position = startPosition = targetPosition;
        timeElapsed = 0.0f;

        while(timeElapsed < dropTime)
        {
            pickupObject.transform.position = Vector3.Lerp(startPosition, targetDrop.position, timeElapsed / dropTime);

            yield return null;
            timeElapsed += Time.deltaTime;
        }
        Destroy(pickupObject);
    }

}
