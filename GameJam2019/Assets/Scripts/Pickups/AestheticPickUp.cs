using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AestheticPickUp : MonoBehaviour
{
    private Vector3 startPos;
    private bool movingUp = true;

    public float bounceHeight = 0.5f;
    public float rotateRate = 90f;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward, Time.fixedDeltaTime * rotateRate);
        Bounce(bounceHeight);
    }

    // bounce animation
    void Bounce(float distance)
    {
        if (movingUp == true)
        {
            transform.position += new Vector3(0, Time.fixedDeltaTime / 3, 0);
            if (transform.position.y > startPos.y + distance) movingUp = !movingUp;
        }
        else
        {
            transform.position -= new Vector3(0, Time.fixedDeltaTime / 3, 0);
            if (transform.position.y < startPos.y) movingUp = !movingUp;
        }
    }
}
