using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rubbish : MonoBehaviour
{
    public Player LastTouchedPlayer { get; private set; }
    public int PlayerID;
    public GC gc;

    //private void Awake()
    //{
    //    gc = GC.Instance;
    //}

    private void OnCollisionEnter(Collision collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if(player != null)
        {
            LastTouchedPlayer = player;
            PlayerID = player.PlayerID;
        }
    }

    public void scoreMe()
    {
        gc.score(PlayerID);
    }

}
