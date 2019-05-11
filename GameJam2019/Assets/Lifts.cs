using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifts : MonoBehaviour
{

    public float Top = 16f;
    public float Bottom  = -12.463f;

    public float speed = 1;
    public int floor = 0;
    public bool goingUp = true;

    public float Wait = 5;


    // Start is called before the first frame update
    void Start()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, Bottom, transform.localPosition.z);

        StartCoroutine(waitFor());
    }

    

    IEnumerator waitFor()

    {
        float delay = Random.Range(0f, 1f) * Wait;

        Debug.Log("Wait for "+delay.ToString());

        yield return new WaitForSeconds(delay);
        StartCoroutine(move());
    }

    IEnumerator move()
    {
        Debug.Log("Move Started ");
        if (floor == 0) goingUp = true;
        if (floor == 1) goingUp = false;

        if (goingUp)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
            Vector3 t = transform.localPosition;
            float height = transform.localPosition.y;
            if (height > Top)
            {
                transform.localPosition = new Vector3(t.x, Top, t.z);
                yield return new WaitForSeconds(Wait);
                floor = 1;
            }

        }

        if (!goingUp)
        {
            transform.Translate(Vector3.up * -speed * Time.deltaTime);
            Vector3 t = transform.localPosition;
            float height = transform.localPosition.y;
            if (height < Bottom)
            {
                transform.localPosition = new Vector3(t.x, Bottom, t.z);
                yield return new WaitForSeconds(Wait);
                floor = 0;
            }
        }



    }



}
