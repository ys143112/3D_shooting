using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingleTon<GameManager>
{
    public float voidTime = 0f;

    public GameObject bullet = null;

    private float repeatLock = 0f;

    public float nowDistance = 0f;

    public float ctrlDistance = 10f;

    public float money = 0f;

    public GameObject statUI = null;

    public GameObject player = null;

    public GameObject gameOverUI = null;

    public GameObject ingameCamera = null;


    void Start()
    {
        InvokeRepeating("GiftMoney", 15, 15);

    }

    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (ingameCamera.activeSelf== true)
            LockSpawn();
    }

    void LockSpawn()
    {
        repeatLock++;
        if (repeatLock >= 15)
            SpawnBullet();
        nowDistance += Time.fixedDeltaTime * ctrlDistance;
    }

    void GiftMoney()
    {
        if(gameOverUI.activeSelf==false)
        {
            money += 40;
            statUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void CloseStatUI()
    {
        Time.timeScale = 1f;
        statUI.SetActive(false);
    }

    void SpawnBullet()
    {
        GameObject child = Instantiate(bullet) as GameObject;
        child.transform.SetParent(gameObject.transform, true);
        child.transform.position = new Vector3(Random.Range(-50, 50), Random.Range(-7.5f, 92.5f),300);

        float pos = Random.Range(10, 20);
        child.transform.localScale = new Vector3(pos, pos, pos);
        repeatLock = 0;
        
    }

    public void PlusVoid(int value)
    {
        voidTime += value;
    }

}
