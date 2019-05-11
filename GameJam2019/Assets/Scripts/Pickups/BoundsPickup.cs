using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

[CreateAssetMenu(fileName = "Plough Pickup", menuName = "Pickups/Plough")]
public class BoundsPickup : AbstractPickup
{
    public override void Activate(CarController carController)
    {
        // increase the plough bounds
        Debug.Log("Increase the car plough bounds");
        carController.PloughPowerOn(new Vector3(5f, 0f, 0f));
    }

    public override void Deactivate(CarController carController)
    {
        // reset/decrease the car speed
        Debug.Log("Reset the car plough bounds");
        carController.PloughPowerOff();
    }
}
