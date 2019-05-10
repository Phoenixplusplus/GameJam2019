using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

[CreateAssetMenu(fileName = "Speed Pickup", menuName = "Pickups/Speed")]
public class SpeedPickup : AbstractPickup
{
    public override void Activate(CarController carController)
    {
        // increase the car speed
        Debug.Log("Increase the car speed");
    }

    public override void Deactivate(CarController carController)
    {
        // reset/decrease the car speed
        Debug.Log("Reset the car speed");
    }
}
