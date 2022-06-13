using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMove : MonoBehaviour
{
    public float scrollSpd = 5f;
    private Vector3 firstPos =Vector3.zero;
    void Start()
    {
        firstPos = transform.position;
    }

    void Update()
    {
        if(transform.position.z<=-250)
        {
            transform.position = firstPos;
        }
        transform.Translate(-transform.forward*Time.deltaTime*(scrollSpd*100));
    }
}
