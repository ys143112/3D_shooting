using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //플레이어가 총알을 회피한 횟수
    public float voidTime = 0f;

    public GameObject bullet = null;

    private float repeatLock = 0f;

    void Start()
    {
        
    }

    void Update()
    {
        repeatLock++;
        if(repeatLock>=30)
            SpawnBullet();

    }
    
    void SpawnBullet()
    {
        GameObject child = Instantiate(bullet) as GameObject;
        child.transform.SetParent(gameObject.transform, true);
        child.transform.position = new Vector3(Random.Range(-50, 50), Random.Range(-7.5f, 92.5f),300);
        repeatLock = 0;
        
    }

    public void PlusVoid(int value)
    {
        voidTime += value;
    }
}
