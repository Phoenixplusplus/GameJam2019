using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

[CreateAssetMenu(fileName = "Turn Pickup", menuName = "Pickups/Turn Speed")]
public class TurnPickup : AbstractPickup
{
    public override void Activate(CarController carController)
    {
        // increase the car speed
        Debug.Log("Increase the turn speed");
    }

    public override void Deactivate(CarController carController)
    {
        // reset/decrease the car speed
        Debug.Log("Reset the turn speed");
    }
}
