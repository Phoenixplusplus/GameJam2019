using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rubbish : MonoBehaviour
{
    public Player LastTouchedPlayer { get; private set; }

    private void OnCollisionEnter(Collision collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if(player != null)
        {
            LastTouchedPlayer = player;
        }
    }
}
