using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public abstract class AbstractPickup : ScriptableObject
{
    public float EffectTime { get { return effectTime; } }

    [SerializeField]
    private float effectTime;

    public abstract void Activate(CarController carController);
    public abstract void Deactivate(CarController carController);
}