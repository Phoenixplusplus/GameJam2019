using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveable<Vector3>
{
    void MoveBy(Vector3 disp);
}
