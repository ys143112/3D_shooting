using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnglishTest : MonoBehaviour
{
    public Transform ang;

    private void Start()
    {
        ang = GetComponent<Transform>();
    }
    private void Update()
    {
        ang= transform.transform;
    }
}
