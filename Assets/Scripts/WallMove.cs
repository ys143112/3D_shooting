using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMove : MonoBehaviour
{
    public float scrollSpd = 0.05f;
    void Start()
    {
    }

    void Update()
    {
        if(transform.position.z>=200)
        {
        }
        transform.Translate(-transform.forward);
    }
}
