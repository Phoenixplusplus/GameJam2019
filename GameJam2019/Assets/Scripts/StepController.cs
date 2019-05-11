using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepController : MonoBehaviour
{

    public float speed;

    private int size;
    [SerializeField]
    private float travel = 0;
    [SerializeField]
    private Transform[] _childList;
    [SerializeField]
    private Vector3[] _startPositions;


    // Start is called before the first frame update
    void Start()
    {

        Transform[] temp = GetComponentsInChildren<Transform>();
        size = temp.GetLength(0);
        _childList = new Transform[size];
        _startPositions = new Vector3[size];
        for (int i = 0; i < size -1; i++)
        {
            _childList[i] = temp[i+1];
            _startPositions[i] = new Vector3(_childList[i].localPosition.x, _childList[i].localPosition.y, _childList[i].localPosition.z);
        }

    }

    // Update is called once per frame
    void Update()
    {

        travel += speed * Time.deltaTime;
        travel = travel % 1;
        if (travel < 0) travel += 1;


        for (int i = 0; i < size-2; i= i+2)
        {
            float z = _childList[i].localPosition.z;
            _childList[i].localPosition = Vector3.Lerp(_startPositions[i], _startPositions[i + 2], travel);
            _childList[i].localPosition = new Vector3(_childList[i].localPosition.x, _childList[i].localPosition.y, z);
        }
        for (int i = 1; i < size - 3; i= i+2)
        {
            float z = _childList[i].localPosition.z;
            _childList[i].localPosition = Vector3.Lerp(_startPositions[i], _startPositions[i + 2], travel);
            _childList[i].localPosition = new Vector3(_childList[i].localPosition.x, _childList[i].localPosition.y, z);
        }



    }
}
