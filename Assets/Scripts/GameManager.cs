using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingleTon<GameManager>
{
    //플레이어가 총알을 회피한 횟수
    public float voidTime = 0f;

    public GameObject bullet = null;

    private float repeatLock = 0f;

    public float nowDistance = 0f;

    public GameObject InGame = null;

    public float ctrlDistance = 10f;

    private float cnt = 0f;

    private float Times = 0f;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (InGame.activeSelf == true)
            LockSpawn();
    }

    void LockSpawn()
    {
        repeatLock++;
        if (repeatLock >= 15)
            SpawnBullet();
        nowDistance += Time.fixedDeltaTime * ctrlDistance;
    }

    IEnumerator GiftMoney()
    {
        
        yield return null;
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
