using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //플레이어가 총알을 회피한 횟수
    public float voidTime = 0f;

    public GameObject bullet = null;

    void Start()
    {
        
    }

    void Update()
    {
        Check();
    }

    void Check()
    {
        if(bullet!=null)
        {
            if (bullet.transform.position.z <= 0)
            {
                voidTime++;
                Destroy(bullet.gameObject);
            }
        }
    }
}
