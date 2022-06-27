using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinShip : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(Vector3.forward, Time.deltaTime*15);
    }
}
