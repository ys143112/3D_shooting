using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMove : MonoBehaviour
{
    public float scrollSpd = 0.05f;
    float Offset;
    MeshRenderer mesh = null;
    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        Offset = Mathf.Repeat(Time.deltaTime*scrollSpd,50);
        mesh.material.mainTextureOffset = new Vector3( 0,Offset );
    }
}
