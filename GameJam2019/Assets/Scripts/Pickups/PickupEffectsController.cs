using System;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class PickupEffectsController : MonoBehaviour
{
    [SerializeField]
    private CarController carController;

    private Dictionary<Type, PickupReference> pickupsWithType;

    private AudioSource audioSource;

    private void Awake()
    {
        pickupsWithType = new Dictionary<Type, PickupReference>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        List<Type> typesToRemove = new List<Type>();

        foreach(var keyValuePair in pickupsWithType)
        {
            if(!keyValuePair.Value.IsStillEffective())
            {
                typesToRemove.Add(keyValuePair.Key);
                keyValuePair.Value.Effect.Deactivate(carController);
            }
        }

        foreach(Type type in typesToRemove)
        {
            pickupsWithType.Remove(type);
        }
    }

    public void AddPickup(PickupReference pickupReference)
    {
        Type effectType = pickupReference.Effect.GetType();
        PickupReference previousReference;

        audioSource.Play();

        if (pickupsWithType.TryGetValue(effectType, out previousReference))
        {
            if(pickupReference.TimeLeft > previousReference.TimeLeft)
            {
                pickupsWithType[effectType] = pickupReference;
            }
        }
        else
        {
            pickupsWithType.Add(effectType, pickupReference);
            pickupReference.Effect.Activate(carController);
        }
    }
}
