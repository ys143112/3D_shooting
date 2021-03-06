using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Mathf;
using UnityEngine.UI;
using DG.Tweening;

public class CharacterCtrl : SingleTon<CharacterCtrl>
{
    public float spd = 25f;

    public float hp = 3f;

    public float barrier = 1f;

    public enum CharacterStateType { Idle, Die }

    public CharacterStateType CharacterState = CharacterStateType.Idle;

    public GameObject gameOverPanel = null;
    public GameObject ingameUI = null;
    public Image ingameImage = null;

    public Animator animationMecanim = null;
    public GameObject barrierCheck = null;

    void Start()
    {
        
    }

    void Update()
    {
        StateCheck();
        CheckBullet();
        Move();
    }

    void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        bool sflag = true;
        if (horizontal !=0 || vertical != 0)
        { 
            sflag = false;
        }
        animationMecanim.SetBool("StateBool", sflag);
        var position = transform.position;

        position += new Vector3(horizontal, vertical, 0) * spd * Time.deltaTime;
        position.x = Clamp(position.x, -38, 38);
        position.y = Clamp(position.y, 0, 80);

        transform.position=position;
        //Vector3 rotateVal =new Vector3(0,0, horizontal);
        //transform.Rotate(rotateVal);
    }



    void StateCheck()
    {
        if (hp <= 0)
        {
            CharacterState = CharacterStateType.Die;
        }
        else
        {
            CharacterState = CharacterStateType.Idle;
        }

        switch (CharacterState)
        {
            case CharacterStateType.Idle:
                break;
            case CharacterStateType.Die:
                gameOverPanel.SetActive(true);
                ingameUI.SetActive(false);
                break;
            default:
                break;
        }

    }

    IEnumerator BarrierCheck()
    {
        barrierCheck.SetActive(true);
        yield return new WaitForSeconds(1f);
        barrierCheck.SetActive(false);
    }


    void CheckBullet()
    {
        
        Vector3 trans = new Vector3(transform.position.x+3,transform.position.y+5,transform.position.z);
        RaycastHit hit = new RaycastHit();
        Ray ray = new Ray(trans, Vector3.forward);
        
        if (Physics.Raycast(ray,out hit,Mathf.Infinity))
        {

            Debug.DrawRay(trans, Vector3.forward*100,Color.white);
            float distance = (hit.transform.position-transform.position ).magnitude;
            if(distance<=20)
            {
                if (barrier > 0)
                {
                    StartCoroutine(BarrierCheck());
                    barrier -= 1;
                }
                else
                {
                    StartCoroutine(DrawHit());
                    hp -= 1;

                }
                Destroy(hit.transform.gameObject);
            }
        }

    }

    IEnumerator DrawHit()
    {
        ingameImage.color = new Color(255, 0, 0, 155);
        yield return new WaitForSeconds(0.3f);
        ingameImage.color = new Color(255,255,255, 0);

    }
}
