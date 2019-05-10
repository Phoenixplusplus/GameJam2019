using UnityEngine;

public class PickupReference
{
    public readonly AbstractPickup Effect;

    public float TimeLeft { get; private set; }

    public PickupReference(AbstractPickup abstractPickup)
    {
        Effect = abstractPickup;
        TimeLeft = Effect.EffectTime;
    }

    /// <summary>
    /// Decrements time left and checks if the time left is still above 0
    /// </summary>
    /// <returns></returns>
    public bool IsStillEffective()
    {
        TimeLeft -= Time.deltaTime;
        return TimeLeft > 0.0f;
    }
}